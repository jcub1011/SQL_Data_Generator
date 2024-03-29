﻿using System;
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
    public static string CreateBooksInsert(List<BookRow> rows)
    {
        var result = new StringBuilder();

        foreach(var row in rows)
        {
            result.AppendLine(SQLRowCreator.CreateRow("books",
                row.ISBN.AsSQLInt(),
                row.Title.AsSQLString(),
                row.Author.AsSQLString()));
        }

        return result.ToString();
    }

    public static string CreateInventoryInsert(List<BookRow> rows)
    {
        var result = new StringBuilder();

        foreach(var row in rows)
        {
            result.AppendLine(SQLRowCreator.CreateRow("inventory",
                row.ISBN.AsSQLInt(),
                _rand.Next(10).AsSQLInt()));
        }

        return result.ToString();
    }

    public static string CreateBorrowerInsert(List<BorrowerRow> rows)
    {
        var result = new StringBuilder();

        foreach (var row in rows)
        {
            result.AppendLine(SQLRowCreator.CreateRow("borrowers",
                row.ID.AsSQLInt(),
                row.LastName.AsSQLString(),
                row.FirstName.AsSQLString(),
                row.DOB.AsSQLDate()));
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
                    borrower.ID.AsSQLInt(),
                    PickRand(books).ISBN.AsSQLInt(),
                    RandomDateGenerator.GetRandDateWithinRange(15).AsSQLDate()));
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
                room.RoomNumber.AsSQLInt(),
                PickRand(borrowers).ID.AsSQLInt(),
                RandomDateGenerator.GetRandDateWithinRange(5).AsSQLDate()));
        }

        return result.ToString();
    }

    static T? PickRand<T> (List<T> source)
    {
        if (source.Count == 0) return default;

        return source[_rand.Next(source.Count - 1)];
    }
}
