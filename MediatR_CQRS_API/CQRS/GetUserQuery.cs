namespace MediatR_CQRS_API.CQRS
{
    public class GetUserQuery : IQuery<User>
    {
        public string id { get; set; }
    }
}
