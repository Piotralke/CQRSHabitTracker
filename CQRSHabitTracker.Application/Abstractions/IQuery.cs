using CQRSHabitTracker.Common;
using Mediator;

namespace CQRSHabitTracker.Application.Abstractions;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
