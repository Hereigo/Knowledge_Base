namespace MediatR_CQRS_API.CommandsQueries
{
    public class CreateUserCommand : ICommand<string>
    {
        public string id { get; set; }
        public string Name { get; set; }
    }
}