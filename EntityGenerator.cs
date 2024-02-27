using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator;

public readonly struct BookRow
{
    public readonly int ISBN;
    public readonly string Title;
    public readonly string Author;

    public BookRow(int isbn, string title, string author)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
    }

    public override string ToString()
    {
        return $"ISBN: {ISBN}, Title: '{Title}', Author: '{Author}'";
    }
}

public readonly struct BorrowerRow
{
    public readonly int ID;
    public readonly string FirstName;
    public readonly string LastName;
    public readonly DateTime DOB;

    public BorrowerRow(int id, string firstName, string lastName, DateTime dateOfBirth)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        DOB = dateOfBirth;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: '{FirstName} {LastName}', DOB: '{DOB}'";
    }
}

public readonly struct StudyRoomRow
{
    public readonly int RoomNumber;

    public StudyRoomRow(int roomNumber)
    {
        RoomNumber = roomNumber;
    }

    public override string ToString()
    {
        return $"Room Number: {RoomNumber}";
    }
}

public static class EntityGenerator
{
    public static List<BookRow> GenerateBooks(int count)
    {
        var books = new List<BookRow>();
        RandomUniqueIDGenerator idGen = new();
        string randTitle;
        string randAuthor;
        (string first, string last) temp;

        while (count-- > 0)
        {
            temp = RandomNameGenerator.GetName();
            randTitle = temp.first + ": " + temp.last;
            temp = RandomNameGenerator.GetName();
            randAuthor = temp.first + " " + temp.last;

            books.Add(new(
                idGen.GetUniqueID(),
                randTitle,
                randAuthor));
        }

        return books;
    }

    public static List<BorrowerRow> GenerateBorrowers(int count)
    {
        var borrowers = new List<BorrowerRow>();
        RandomUniqueIDGenerator idGen = new();
        (string first, string last) temp;

        while (count-- > 0)
        {
            temp = RandomNameGenerator.GetName();

            borrowers.Add(new(
                idGen.GetUniqueID(),
                temp.first,
                temp.last,
                RandomDateGenerator.GetRandPastDate(1960, 1, 1)));
        }

        return borrowers;
    }

    public static List<StudyRoomRow> GenerateStudyRoom(int count)
    {
        var rooms = new List<StudyRoomRow>();

        while (count-- > 0)
        {
            rooms.Add(new(count));
        }

        return rooms;
    }
}
