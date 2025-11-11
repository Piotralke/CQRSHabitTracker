using Microsoft.Extensions.DependencyInjection;

namespace Mediator
{
	public class Mediator : IMediator
	{
		private readonly IServiceProvider _serviceProvider;
		public Mediator(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}
		public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
		{
			var handlerType = typeof(INotificationHandler<>).MakeGenericType(notification.GetType());
			var handlers = _serviceProvider.GetServices(handlerType);

			foreach (dynamic handler in handlers)
			{
				await handler.Handle((dynamic)notification, cancellationToken);
			}
		}

		public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
		{
			var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
			dynamic? handler = _serviceProvider.GetService(handlerType);

			if (handler == null)
				throw new InvalidOperationException($"Handler for {request.GetType().Name} not registered.");

			return await handler.Handle((dynamic)request, cancellationToken);
		}
	}
}
