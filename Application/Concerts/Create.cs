using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Concerts
{
    public class Create
    {
        public class Command : IRequest
        {
            public Concert Concert { get; set; } //what we want to receive
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Concerts.Add(request.Concert); //adding Concert in context in memory, not in database - async not required

                await _context.SaveChangesAsync(); 

                return Unit.Value; //equivalent to nothing, lets API controller know we're finished.
            }
        }
    }
}