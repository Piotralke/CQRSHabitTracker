using CQRSHabitTracker.Domain.Abstractions;

namespace CQRSHabitTracker.Domain.Habits.Events;
public sealed record HabitRecordAddedEvent(Guid HabitId, DateTime OccuredAt) : IDomainEvent;
