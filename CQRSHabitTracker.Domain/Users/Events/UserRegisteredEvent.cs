using CQRSHabitTracker.Domain.Abstractions;

namespace CQRSHabitTracker.Domain.Users.Events;

public sealed record UserRegisteredEvent(Guid UserId) : IDomainEvent;
