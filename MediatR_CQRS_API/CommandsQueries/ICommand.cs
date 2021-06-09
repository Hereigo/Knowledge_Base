using MediatR;

namespace MediatR_CQRS_API.CommandsQueries
{
    public interface ICommand<T> : IRequest<T>
    {
    }
}
