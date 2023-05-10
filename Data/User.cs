//Domain model

namespace DAL
	{
	public enum Gender
		{
		Male,
		Female
		}
	public class User
		{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string? FIO { get; set; }
		public DateOnly BirthDate { get; set; }
		public Gender? Gender { get; set; }
		}
	}
