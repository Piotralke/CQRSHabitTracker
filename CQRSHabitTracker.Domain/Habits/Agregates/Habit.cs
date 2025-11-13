using CQRSHabitTracker.Domain.Abstractions;
using CQRSHabitTracker.Domain.Habits.Enums;
using CQRSHabitTracker.Domain.Habits.ValueObjects;

namespace CQRSHabitTracker.Domain.Habits.Agregates
{
	public sealed class Habit : Entity
	{
		public string Name { get; private set; }
		public Guid UserId { get; private set; }
		public HabitType Type { get; private set; }
		public HabitSchedule Schedule { get; private set; }
		public HabitGoal Goal { get; private set; }
		private readonly List<HabitRecord> _entries = new();
		public IReadOnlyCollection<HabitRecord> Entries => _entries.AsReadOnly();

		private Habit(Guid id, Guid userId, string name, HabitType type, HabitSchedule schedule, HabitGoal goal) : base(id)
		{
			UserId = userId;
			Name = name;
			Type = type;
			Schedule = schedule;
			Goal = goal;
		}
		public static Habit CreateQuantityBased(Guid userId, string name, HabitSchedule schedule, HabitGoal goal)
		{
			ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
			ArgumentNullException.ThrowIfNull(userId, nameof(userId));
			ArgumentNullException.ThrowIfNull(schedule, nameof(schedule));
			ArgumentNullException.ThrowIfNull(goal, nameof(goal));

			if (goal.Type != GoalType.CountBased)
				throw new ArgumentException("Goal must be count-based for a quantity habit.", nameof(goal));

			var h = new Habit(Guid.NewGuid(), userId, name, HabitType.QuantityBased, schedule, goal);
			return h;
		}
		public static Habit CreateDurationBased(Guid userId, string name, HabitSchedule schedule, HabitGoal goal)
		{
			ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
			ArgumentNullException.ThrowIfNull(userId, nameof(userId));
			ArgumentNullException.ThrowIfNull(schedule, nameof(schedule));
			ArgumentNullException.ThrowIfNull(goal, nameof(goal));

			if (goal.Type != GoalType.DurationBased)
				throw new ArgumentException("Goal must be duration-based for a duration habit.", nameof(goal));

			var h = new Habit(Guid.NewGuid(), userId, name, HabitType.DurationBased, schedule, goal);
			return h;
		}
		public void RecordEntry(HabitRecord entry)
		{
			ArgumentNullException.ThrowIfNull(entry, nameof(entry));
			_entries.Add(entry);
		}
	}
}
