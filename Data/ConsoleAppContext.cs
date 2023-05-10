using Microsoft.EntityFrameworkCore;

namespace DAL
	{
	public class ConsoleAppContext:DbContext
		{
		private readonly DbContextOptions<ConsoleAppContext> _contextOptions;
		public ConsoleAppContext()
			{
			//_contextOptions=new DbContextOptionsBuilder<ConsoleAppContext>()
			//	.UseInMemoryDatabase("ConsoleAppContext")
			//	.Options;
			//this.ChangeTracker.LazyLoadingEnabled = true;
			}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			{
			optionsBuilder.UseInMemoryDatabase("ConsoleAppContext");
			}

		public DbSet<User> Users { get; set; } //Table 1 according to instructions

		protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
			modelBuilder.Entity<User>().HasIndex(u => u.Gender, "Gender index");
			modelBuilder.Entity<User>().HasIndex(u => u.FIO, "FIO index");
			}

		}
	}
