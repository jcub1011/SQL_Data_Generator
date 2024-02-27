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
            var result = SQLRowCreator.CreateRow("takes", 
                    new SQLNumber(10),
                    new SQLString("Hello World"),
                    new SQLString("Hello World"),
                    new SQLString("Hello World"),
                    new SQLString("Hello World")
                    );
            Console.WriteLine(result);
            SQLFileManager temp = new("TestSQL.sql");

            Console.WriteLine(
            RandomNameGenerator.GetName());
        }
    }
}