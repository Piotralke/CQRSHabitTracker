using CQRSHabitTracker.Domain.Abstractions;

namespace CQRSHabitTracker.Domain.Habits.Agregates
{
	public abstract class HabitRecord : Entity
	{
		public DateTime OccuredAt { get; private set; }
		protected HabitRecord(Guid id) : base(id)
		{
			OccuredAt = DateTime.Now;
		}
	}
	public class QuantityHabitRecord :HabitRecord
	{
		public int Quantity { get; private set; }
		private QuantityHabitRecord(Guid id, int quantity) : base(id)
		{
			Quantity = quantity;
		}
		public static QuantityHabitRecord Create(int quantity)
		{
			if (quantity <= 0)
				throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
			return new QuantityHabitRecord(
				Guid.NewGuid(),
				quantity
				);
		}
	}
	public class DurationHabitRecord : HabitRecord
	{
		public TimeSpan Duration { get; private set; }
		private DurationHabitRecord(Guid id, TimeSpan duration) : base(id)
		{
			Duration = duration;
		}
		public static DurationHabitRecord Create(TimeSpan duration)
		{
			if (duration <= TimeSpan.Zero)
				throw new ArgumentOutOfRangeException(nameof(duration), "Duration must be greater than zero.");
			return new DurationHabitRecord(
				Guid.NewGuid(),
				duration
				);
		}
	}
}
