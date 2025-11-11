using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mediator
{
	public static class MediatorServiceCollectionExtensions
	{
		public static  IServiceCollection AddMediator(this IServiceCollection services, params Assembly[] assemblies)
		{
			var types = assemblies.SelectMany(a => a.GetTypes());

			//Pobieramy wszystkie klasy handlerów implementujące IRequestHandler<,> lub INotificationHandler<>
			var handlers = types.Where(t =>
				t.GetInterfaces().Any(i =>
					i.IsGenericType &&
					(i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
					 i.GetGenericTypeDefinition() == typeof(INotificationHandler<>))));

			//Pobieramy wszystkie interfejsy i rejestrujemy je w kontenerze DI
			foreach (var handler in handlers)
			{
				var interfaces = handler.GetInterfaces()
					.Where(i => i.IsGenericType &&
						(i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
						 i.GetGenericTypeDefinition() == typeof(INotificationHandler<>)));

				foreach (var interf in interfaces)
				{
					services.AddTransient(interf, handler);
				}
			}
			// Rejestrujemy Mediatora jako singleton
			services.AddSingleton<IMediator, Mediator>();

			return services;
		}
	}
}
