using MediatR_CQRS_API.Models;

namespace MediatR_CQRS_API.CommandsQueries
{
    public class GetUserQuery : IQuery<User>
    {
        public string id { get; set; }
    }
}
