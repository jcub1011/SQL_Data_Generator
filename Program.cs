namespace SQL_Data_Generator
{
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
        }
    }
}