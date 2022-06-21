using MediatR;

namespace Ordering.Application.Behaviours
{
    public interface IUnhandledExceptionBehaviour<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
    }
}