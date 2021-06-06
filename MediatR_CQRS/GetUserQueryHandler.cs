using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_CQRS
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
