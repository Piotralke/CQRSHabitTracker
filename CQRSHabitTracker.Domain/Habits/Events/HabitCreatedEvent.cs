using CQRSHabitTracker.Domain.Abstractions;

namespace CQRSHabitTracker.Domain.Habits.Events;
public sealed record HabitCreatedEvent(Guid HabitId, Guid UserId) : IDomainEvent;