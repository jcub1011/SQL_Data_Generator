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

            //var inventoryInsert = TableInsertGenerator.CreateInventoryInsert(books);
            ////Console.WriteLine(inventoryInsert);

            //var loansInsert = TableInsertGenerator.CreateLoansInsert(people, books);
            ////Console.WriteLine(loansInsert);

            //SQLFileManager file = new("test.sql");
            //file.AppendStrings(booksInsert, borrowerInsert, studroomsInsert,
            //    inventoryInsert, loansInsert);

            // Create row automatically converts int, double, string, and DateTime to sql.
            Console.WriteLine(SQLRowCreator.CreateRow("test_table", 10, 50, "Hello World", DateTime.Now));
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