namespace MediatR_CQRS
{
    public class GetUserQuery : IQuery<User>
    {
        public string id { get; set; }
    }
}
