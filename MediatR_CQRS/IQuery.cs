using MediatR;

namespace MediatR_CQRS
{
    public interface IQuery<T> : IRequest<T>
    {
    }
}
