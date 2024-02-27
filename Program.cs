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
            var result = EntityGenerator.GenerateBooks(10);
            PrintList(result);
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