using CQRSHabitTracker.Domain.Habits.Enums;

namespace CQRSHabitTracker.Domain.Habits.ValueObjects
{
	public class HabitSchedule
	{
		public ScheduleType Type { get; private set; }
		public int? TiemsPerPeriod { get; private set; }
		public TimeSpan? Interval { get; private set; }
		public Period Period { get; private set; }

	}
}
