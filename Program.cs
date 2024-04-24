using Newtonsoft.Json.Linq;

namespace SQL_Data_Generator
{
    /// <summary>
    /// Names.txt file must be placed in application base directory. 
    /// Generated sql files will be placed in the application base directory.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // This represents a possible row in a table.
            // Supported values are: strings, integers, doubles, dateonly, timeonly, and datetime.
            Entity temp = new()
            {
                {"Hello", "world" },
                {"It", 1030 },
                {"This Is Null", null },
                {"dateonly", new DateOnly(2024, 12, 20) },
                {"timeonly", new TimeOnly(12, 20, 54) },
                {"timestamp", new DateTime(2024, 6, 12, 6, 30, 20) },
                {"double", 12.5 }

            };

            // To create the insert, use this function. MyTable is the name of the fake table for demonstration purposes.
            Console.WriteLine(temp.GetEntitySQLInsert("MyTable"));
            temp.SetColumnOrder(temp.GetColumns());
            temp.RemoveColumn(temp.GetColumns()[0]);


            //var books = EntityGenerator.GenerateBooks(10000);
            ////PrintList(books);
            //var booksInsert = TableInsertGenerator.CreateBooksInsert(books);
            ////Console.WriteLine(booksInsert);

            //var people = EntityGenerator.GenerateBorrowers(1000);
            ////PrintList(people);
            //var borrowerInsert = TableInsertGenerator.CreateBorrowerInsert(people);
            ////Console.WriteLine(borrowerInsert);

            //var rooms = EntityGenerator.GenerateStudyRoom(50);
            ////PrintList(rooms);
            //var studroomsInsert = TableInsertGenerator.CreateStudyRoomInsert(rooms, people);
            ////Console.WriteLine(studroomsInsert);

            //var usesInsert = TableInsertGenerator.CreateUsesInsert(rooms, people);
            ////Console.WriteLine(inventoryInsert);

            //var loansInsert = TableInsertGenerator.CreateLoansInsert(people, books);
            ////Console.WriteLine(loansInsert);

            //SQLFileManager file = new("test.sql");
            //file.AppendStrings(booksInsert, borrowerInsert, studroomsInsert,
            //    usesInsert, loansInsert);

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(RandomDateGenerator.GetRandDateBetween(new DateTime(2024, 4, 1), new(2024, 4, 5), 8, 16, 15).AsISODate());
            //}

            //Random rand = new();
            //while(true)
            //{
            //    Console.WriteLine("Insert JSON Below:");
            //    string json = Console.ReadLine();
            //    JObject obj = JObject.Parse(json);
            //    foreach (var evt in obj["events"])
            //    {
            //        DateTime start = RandomDateGenerator.GetRandDateBetween(new DateTime(2024, 4, 1), new(2024, 4, 5), 8, 16, 15);
            //        evt["start_time"] = start.AsISODate();
            //        evt["end_time"] = start.AddMinutes(15 * rand.Next(13));
            //    }
            //    Console.WriteLine(obj.ToString());
            //}

            // Create row automatically converts int, double, string, and DateTime to sql.
            //Console.WriteLine(SQLRowCreator.CreateRow("test_table", 10, 50, "Hello World", DateTime.Now));
        }

        static void PrintList<T>(List<T> list) where T : struct
        {
            foreach(var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}