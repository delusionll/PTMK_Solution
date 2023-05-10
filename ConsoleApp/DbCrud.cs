using DAL;

using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
	{
	public class DbCrud
		{
		public static void InitializeDB()
			{
			DbContextOptions<ConsoleAppContext> options = new DbContextOptionsBuilder<ConsoleAppContext>()
				.UseInMemoryDatabase("ConsoleAppContext")
				.Options; //Using inmemory DB
			using(var db = new ConsoleAppContext())
				{
				db.Database.EnsureCreated();
				}
			}
		public static void CreateEntry<T>(T entry) where T : class
			{
			using(var db = new ConsoleAppContext())
				{
				db.Set<T>().Add(entry);
				db.SaveChanges();
				}
			}

		public static T GetEntryById<T>(Guid id) where T : class
			{
			using(var db = new ConsoleAppContext())
				{
				return db.Find<T>(id);
				}
			}
		}
	}
