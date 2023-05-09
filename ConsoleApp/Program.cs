using System.Security.Cryptography.X509Certificates;

using DAL;

using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
	{
	public class Program
		{
		static void Main()
			{
			User userCheck = new()
				{
				FIO="Check",
				Gender = Gender.Male
				};
			var options = new DbContextOptionsBuilder<ConsoleAppContext>()
				.UseInMemoryDatabase("ConsoleAppContext")
				.Options;
			using(var db = new ConsoleAppContext(options))
				{
				db.Database.EnsureCreated();

				db.Add<User>(userCheck);
				db.SaveChanges();

				Console.WriteLine(db.ContextId);
				Console.WriteLine(db.Model);

				User userWrite = db.Users.Find(userCheck.Id);

				Console.WriteLine(userWrite.Gender);
				}
			}
		}
	}