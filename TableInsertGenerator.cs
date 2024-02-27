using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator;

public static class TableInsertGenerator
{
    static Random _rand = new();

    /// <summary>
    /// Creates an insert using the provided list.
    /// </summary>
    /// <returns></returns>
    public static string GenerateBooksInsert(List<BookRow> rows)
    {
        var result = new StringBuilder();

        foreach(var row in rows)
        {
            result.AppendLine(SQLRowCreator.CreateRow("books",
                new SQLNumber(row.ISBN),
                new SQLString(row.Title),
                new SQLString(row.Author)));
        }

        return result.ToString();
    }

    public static string GenerateInventoryInsert(List<BookRow> rows)
    {
        var result = new StringBuilder();

        foreach(var row in rows)
        {
            result.AppendLine(SQLRowCreator.CreateRow("inventory",
                new SQLNumber(row.ISBN),
                new SQLNumber(_rand.Next(10))));
        }

        return result.ToString();
    }

    public static string GenerateBorrowerInsert(List<BorrowerRow> rows)
    {
        var result = new StringBuilder();

        foreach (var row in rows)
        {
            result.AppendLine(SQLRowCreator.CreateRow("borrowers",
                new SQLNumber(row.ID),
                new SQLString(row.FirstName),
                new SQLString(row.LastName)));
        }

        return result.ToString();
    }

    public static string CreateLoansInsert(List<BorrowerRow> borrowers,
        List<BookRow> books)
    {
        var result = new StringBuilder();
        int borrowerBookCount;

        foreach(var borrower in borrowers)
        {
            borrowerBookCount = _rand.Next(5);

            while (borrowerBookCount-- > 0)
            {
                result.AppendLine(SQLRowCreator.CreateRow("loans",
                    new SQLNumber(borrower.ID),
                    new SQLNumber(PickRand(books).ISBN)));
            }
        }

        return result.ToString();
    }

    public static string CreateStudyRoomInsert(List<StudyRoomRow> rooms, List<BorrowerRow> borrowers)
    {
        var result = new StringBuilder();

        foreach (var room in rooms)
        {
            result.AppendLine(SQLRowCreator.CreateRow("studyrooms",
                new SQLNumber(room.RoomNumber),
                new SQLNumber(PickRand(borrowers).ID)));
        }

        return result.ToString();
    }

    static T? PickRand<T> (List<T> source)
    {
        if (source.Count == 0) return default;

        return source[_rand.Next(source.Count - 1)];
    }
}
