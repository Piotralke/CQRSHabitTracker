using CQRSHabitTracker.Domain.Abstractions;
using CQRSHabitTracker.Domain.Habits.Agregates;

namespace CQRSHabitTracker.Domain.Users.Agregates
{
	public sealed class User : Entity
	{
		public string Username { get; private set; }

		private readonly List<Habit> _habits = new();
		public IReadOnlyCollection<Habit> Habits => _habits.AsReadOnly();
		private User(Guid id, string username) : base(id)
		{
			Username = username;
		}
		public static User Create(string username)
		{
			ArgumentException.ThrowIfNullOrEmpty(username, nameof(username));

			return new User(
				Guid.NewGuid(),
				username
				);
		}
		public void AddHabit(Habit habit)
		{
			ArgumentNullException.ThrowIfNull(habit, nameof(habit));
			_habits.Add(habit);
		}
		public void RemoveHabit(Habit habit)
		{
			ArgumentNullException.ThrowIfNull(habit, nameof(habit));
			_habits.Remove(habit);
		}	
	}
}
