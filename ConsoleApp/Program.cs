using System.Diagnostics;

using DAL;

using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
	{
	public class Program
		{
		static void Main(string[] args)
			{
			Console.Write("Hi there!\nSelect:\n1. InitializeDB()\n2. CreateEntry() => Ф И О ДатаРождения Пол"+
				"\n3. AllRows()\n4. AutoRows()\n5. SampleWithTime()\n6. SampleWithTimeOptimised()\n");
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
					case "4":
						AutoRows();
						break;
					case "5":
						SampleWithTime();
						break;
					case "6":
						SampleWithTimeOptimised();
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
		static void AutoRows()
			{
			char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
			Random random = new Random();

			for(int i = 0; i<1000000; i++)
				{
				int nameLength = 3;
				string randomName = "";

				Type type = typeof(Gender);
				Array genders = type.GetEnumValues();
				int index = random.Next(genders.Length);
				Gender randomGender = (Gender)genders.GetValue(index);

				for(int j = 0; j<nameLength; j++)
					{
					int randomIndex = random.Next(alphabet.Length);
					randomName+=alphabet[randomIndex];
					}
				string randomFIO = $"{randomName} {randomName} {randomName}";
				User user = new()
					{
					FIO=randomFIO,
					Gender=randomGender
					};

				DbCrud.CreateEntry<User>(user);
				}

			for(int k = 0; k<100; k++)
				{
				int nameLength = 2;
				string randomName = "F";

				for(int j = 0; j<nameLength; j++)
					{
					int randomIndex = random.Next(alphabet.Length);
					randomName+=alphabet[randomIndex];
					}
				string randomFIO = $"{randomName} {randomName} {randomName}";
				User user = new()
					{
					FIO=randomFIO,
					Gender=Gender.Male
					};

				DbCrud.CreateEntry<User>(user);
				}
			Console.WriteLine("AutoRows done");

			}

		static void SampleWithTime()
			{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using(var db = new ConsoleAppContext())
				{
				var sample = db.Users
					.Where(u => u.FIO.StartsWith("F")&&u.Gender.Equals(Gender.Male))
					.ToList();

				foreach(User u in sample)
					{
					Console.WriteLine($"{u.FIO} {u.BirthDate} {u.Gender}");
					}
				}
			stopwatch.Stop();
			Console.WriteLine($"Complete time was {stopwatch.ElapsedMilliseconds} milliseconds");
			}


		static void SampleWithTimeOptimised()
			{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using(var db = new ConsoleAppContext())
				{
				var sample = db.Users
					.Where(u => u.FIO.StartsWith("F")&&u.Gender.Equals(Gender.Male))
					.AsNoTracking()
					.ToList();

				foreach(User u in sample)
					{
					Console.WriteLine($"{u.FIO} {u.BirthDate} {u.Gender}");
					}
				}
			stopwatch.Stop();
			Console.WriteLine($"Complete time was {stopwatch.ElapsedMilliseconds} milliseconds");
			}
		}
	}