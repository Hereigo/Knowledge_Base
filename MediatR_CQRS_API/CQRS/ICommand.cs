using MediatR;

namespace MediatR_CQRS_API.CQRS
{
    public interface ICommand<T> : IRequest<T>
    {
    }
}
