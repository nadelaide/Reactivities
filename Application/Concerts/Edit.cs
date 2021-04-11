using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Concerts
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Concert Concert { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var Concert = await _context.Concerts.FindAsync(request.Concert.Id);

                _mapper.Map(request.Concert, Concert); 

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}