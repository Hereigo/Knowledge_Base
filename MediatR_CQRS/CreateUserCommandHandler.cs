using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_CQRS
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        public Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult("User Created");
        }
    }
}