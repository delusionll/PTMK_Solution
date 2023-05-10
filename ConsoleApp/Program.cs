using DAL;

namespace ConsoleApp
	{
	public class Program
		{
		static void Main(string[] args)
			{
			Console.Write("Hi there!\nSelect:\n1. InitializeDB()\n2. CreateEntry() => Ф И О ДатаРождения Пол\n");
			string choice = Console.ReadLine();
			do
				{
				switch(choice)
					{
					case "1":
						InitializeDB();
						break;
					case "2":
						CreateEntry();
						break;
					case "3":
						AllRows();
						break;

					}
				string newChoice = Console.ReadLine();
				choice=newChoice;
				} while(choice!="0");

			}
		static void InitializeDB()
			{
			DbCrud.InitializeDB();

			Console.WriteLine("DB created");
			}
		static void CreateEntry()
			{
			string input = Console.ReadLine(); //ФИО ДатаРождения Пол
			string[] words = input.Split(" ");
			string fio = words[0]+" "+words[1]+" "+words[2];
			DateOnly birthDate = DateOnly.Parse(words[3]);
			string gender = words[4];

			User newEntry = new()
				{
				FIO=fio,
				BirthDate=birthDate
				};
			if(gender.Equals("Мужской"))
				{
				newEntry.Gender=Gender.Male;
				}
			else
				{
				newEntry.Gender=Gender.Female;
				}
			DbCrud.CreateEntry<User>(newEntry);
			Console.WriteLine("Entry created");
			}
		static void AllRows()
			{
			using(var db = new ConsoleAppContext())
				{
				var allRows = db.Users
					.OrderBy(u => u.FIO)
					.ToList();

				foreach(User u in allRows)
					{
					DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
					int dif = currentDate.DayNumber-u.BirthDate.DayNumber;
					int age = dif/(int)365.25;
					Console.WriteLine($"{u.FIO} {u.BirthDate} {u.Gender} {age}");
					}
				}
			}
		}
	}