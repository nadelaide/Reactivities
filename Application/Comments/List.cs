using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Comments
{
    public class List
    {
        public class Query : IRequest<Result<List<CommentDto>>>
        {
            //need activity associated with this comment list
            public Guid ActivityId { get; set; }

        }

        public class Handler : IRequestHandler<Query, Result<List<CommentDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<CommentDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var comments = await _context.Comments
                    .Where(x => x.Activity.Id == request.ActivityId) //list of comments from a particular activity
                    .OrderByDescending(x => x.CreatedAt) //order by particular date
                    .ProjectTo<CommentDto>(_mapper.ConfigurationProvider) //project to commentDTO
                    .ToListAsync(); //execute two lists

                return Result<List<CommentDto>>.Success(comments);
            }
        }
    }
}