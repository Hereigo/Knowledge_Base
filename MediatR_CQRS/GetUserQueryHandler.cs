using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_CQRS
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new User() { id = "123", Name = "Aivengo" });
        }
    }
}
