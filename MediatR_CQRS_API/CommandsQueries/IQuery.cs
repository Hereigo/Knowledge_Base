using MediatR;

namespace MediatR_CQRS_API.CommandsQueries
{
    public interface IQuery<T> : IRequest<T>
    {
    }
}
