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
            var books = EntityGenerator.GenerateBooks(10);
            PrintList(books);
            var booksInsert = TableInsertGenerator.CreateBooksInsert(books);
            Console.WriteLine(booksInsert);

            var people = EntityGenerator.GenerateBorrowers(10);
            PrintList(people);
            var borrowerInsert = TableInsertGenerator.CreateBorrowerInsert(people);
            Console.WriteLine(borrowerInsert);

            var rooms = EntityGenerator.GenerateStudyRoom(10);
            PrintList(rooms);
            var studroomsInsert = TableInsertGenerator.CreateStudyRoomInsert(rooms, people);
            Console.WriteLine(studroomsInsert);

            var inventoryInsert = TableInsertGenerator.CreateInventoryInsert(books);
            Console.WriteLine(inventoryInsert);

            var loansInsert = TableInsertGenerator.CreateLoansInsert(people, books);
            Console.WriteLine(loansInsert);
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