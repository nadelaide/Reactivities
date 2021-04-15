using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; } //what we want to receive
        }

        public class CommandValidator : AbstractValidator<Command> //command class contains the activity
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator()); //uses Activity Validator to validate if items are empty or null
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity); //adding activity in context in memory, not in database - async not required

                var result = await _context.SaveChangesAsync() > 0; //if nothing has been written to the database this will be false

                if (!result) return Result<Unit>.Failure("Failed to create activiity");

                return Result<Unit>.Success(Unit.Value); //equivalent to nothing, lets API controller know we're finished.
            }
        }
    }
}