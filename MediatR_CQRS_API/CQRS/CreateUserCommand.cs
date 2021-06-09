namespace MediatR_CQRS_API.CQRS
{
    public class CreateUserCommand : ICommand<string>
    {
        public string id { get; set; }
        public string Name { get; set; }
    }
}