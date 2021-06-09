using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR_CQRS_API.Models;

namespace MediatR_CQRS_API.CommandsQueries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new User() { id = "123", Name = "Ivanhoe" });
        }
    }
}
