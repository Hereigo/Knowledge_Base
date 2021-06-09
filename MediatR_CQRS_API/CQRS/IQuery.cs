using MediatR;

namespace MediatR_CQRS_API.CQRS
{
    public interface IQuery<T> : IRequest<T>
    {
    }
}
