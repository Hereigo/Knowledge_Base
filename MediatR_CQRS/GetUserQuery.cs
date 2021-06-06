using MediatR;

namespace MediatR_CQRS
{
    public class GetUserQuery : IRequest<User>
    {
        public string id { get; set; }
    }
}
