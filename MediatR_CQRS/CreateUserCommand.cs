using MediatR;

namespace MediatR_CQRS
{
    public class CreateUserCommand : IRequest<string>
    {
        public string id { get; set; }
        public string Name { get; set; }
    }
}