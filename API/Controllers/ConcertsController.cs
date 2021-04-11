using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Concerts;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ConcertsController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Concert>>> GetConcerts()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] // concerts/id
        public async Task<ActionResult<Concert>> GetConcert(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateConcert(Concert concert) //recognizes it needs to look inside the body of the request to find this object
        {
            return Ok(await Mediator.Send(new Create.Command {Concert = concert}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditConcert(Guid id, Concert concert)
        {
            concert.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Concert = concert}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcert(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}