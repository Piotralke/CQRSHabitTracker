using CQRSHabitTracker.Common;
using Mediator;

namespace CQRSHabitTracker.Application.Abstractions;
public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;