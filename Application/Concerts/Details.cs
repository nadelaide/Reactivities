using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Concerts
{
    public class Details
    {
        public class Query : IRequest<Concert>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Concert>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Concert> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Concerts.FindAsync(request.Id);
            }
        }
    }
}