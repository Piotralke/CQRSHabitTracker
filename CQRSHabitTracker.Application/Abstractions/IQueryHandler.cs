using CQRSHabitTracker.Common;
using Mediator;

namespace CQRSHabitTracker.Application.Abstractions;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>;

