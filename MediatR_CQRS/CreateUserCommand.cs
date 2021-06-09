namespace MediatR_CQRS
{
    public class CreateUserCommand : ICommand<string>
    {
        public string id { get; set; }
        public string Name { get; set; }
    }
}