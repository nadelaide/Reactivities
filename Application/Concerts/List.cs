using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Concerts
{
    public class List
    {
        public class Query : IRequest<List<Concert>> { } //request list of Concerts
        //to return the list

        public class Handler : IRequestHandler<Query, List<Concert>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Concert>> Handle(Query request, CancellationToken cancellationToken)
            {

                return await _context.Concerts.ToListAsync(cancellationToken);
            }
        }
    }
}