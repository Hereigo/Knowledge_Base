using MediatR;

namespace MediatR_CQRS
{
    public interface ICommand<T> : IRequest<T>
    {
    }
}
