using System;
using System.Threading.Tasks;
using Application.Comments;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediator;
        public ChatHub(IMediator mediator) //add mediatr like api controllers
        {
            _mediator = mediator;
        }

        //send a comment
        public async Task SendComment(Create.Command command) //what we call a method is super important, client can invoke methods within SignalR hub
        {
            var comment = await _mediator.Send(command); //sending properties contained in Create (activityID, body)
            //shaped by mapper into commentDTO => send to anyone connected to that activity in the hub, including the commenter
            await Clients.Group(command.ActivityId.ToString()) //add to string because ID is guid
            .SendAsync("ReceiveComment", comment.Value); //value because comment is a result object
        }

        //when a client connects to the hub, we want them to join a group
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var activityId = httpContext.Request.Query["activityId"];
            await Groups.AddToGroupAsync(Context.ConnectionId, activityId); //named group activityId
            var result = await _mediator.Send(new List.Query{ActivityId = Guid.Parse(activityId)}); //send down list of comments to client
            await Clients.Caller.SendAsync("LoadComments", result.Value);
            //SUMMARY: whenever a client connects, we join them to a group of teh name ActivityID, and send them a list of comments that we get from 
            // the database. Anytime a comment is added to the group, it will be added here.
        }
    }
}