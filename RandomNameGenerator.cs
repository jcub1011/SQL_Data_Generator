namespace SQL_Data_Generator;

/// <summary>
/// This class requires a 'Names.txt' file in the application root directory.
/// </summary>
public static class RandomNameGenerator
{
    static List<string>? _names;
    static Random _rand = new();

    /// <summary>
    /// Returns (firstName, lastName)
    /// </summary>
    /// <returns></returns>
    static public (string first, string last) GetName()
    {
        _names ??= GetNames();

        if (_names.Count == 0) return ("Dave", "Duncan");

        return (_names[_rand.Next(_names.Count - 1)], _names[_rand.Next(_names.Count - 1)]);

    }

    static List<string> GetNames()
    {
        const string FILE_NAME = "Names.txt";
        List<string> names = new();

        using (var sr = new StreamReader(SQLFileManager.ConvertToPath(FILE_NAME)))
        {
            string? text = sr.ReadLine();
            while (text != null) {
                names.Add(text.Split(',')[0]);
                text = sr.ReadLine();
            }
        }

        return names;
    }
}
