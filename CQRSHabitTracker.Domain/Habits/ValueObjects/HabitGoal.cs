using CQRSHabitTracker.Domain.Habits.Enums;

namespace CQRSHabitTracker.Domain.Habits.ValueObjects
{
	public class HabitGoal
	{
		public GoalType Type { get; private set; }
		public int? TargetCount { get; private set; }
		public TimeSpan? TargetDuration { get; private set; }
	}
}
