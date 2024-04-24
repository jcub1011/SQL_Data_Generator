using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator;

public interface IEntity: IEnumerable
{
    /// <summary>
    /// Sets the value for the given column in the entity.
    /// This value is converted into a string with the proper format for SQL.
    /// If the provided value is null, it will be inserted as NULL.
    /// </summary>
    /// <param name="column"></param>
    /// <param name="value"></param>
    public void Add(string column, string? value);

    /// <summary>
    /// Sets the value for the given column in the entity.
    /// This value is converted into a string with the proper format for SQL.
    /// </summary>
    /// <param name="column"></param>
    /// <param name="value"></param>
    public void Add(string column, double value);

    /// <summary>
    /// Sets the value for the given column in the entity.
    /// This value is converted into a string with the proper format for SQL.
    /// </summary>
    /// <param name="column"></param>
    /// <param name="value"></param>
    public void Add(string column, int value);

    /// <summary>
    /// Sets the value for the given column in the entity.
    /// This value is converted into a string with the proper format for SQL.
    /// </summary>
    /// <param name="column"></param>
    /// <param name="value"></param>
    public void Add(string column, DateOnly value);

    /// <summary>
    /// Sets the value for the given column in the entity.
    /// This value is converted into a string with the proper format for SQL.
    /// </summary>
    /// <param name="column"></param>
    /// <param name="value"></param>
    public void Add(string column, DateTime value);

    /// <summary>
    /// Sets the value for the given column in the entity.
    /// This value is converted into a string with the proper format for SQL.
    /// </summary>
    /// <param name="column"></param>
    /// <param name="value"></param>
    public void Add(string column, TimeOnly value);

    /// <summary>
    /// Deletes the column from the entity. This also removes its corresponding value.
    /// </summary>
    /// <param name="column"></param>
    public void RemoveColumn(string column);

    /// <summary>
    /// Check if the given column exists.
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    public bool HasColumn(string column);

    /// <summary>
    /// Gets the columns the entity has.
    /// </summary>
    /// <returns></returns>
    public string[] GetColumns();

    /// <summary>
    /// Gets the current column order. If one is not set, it will return an empty array.
    /// </summary>
    /// <returns></returns>
    public string[] GetColumnOrder();

    /// <summary>
    /// Gets the value assigned to the provided column. Returns null if column does not exist.
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    public string? GetValue(string column);

    /// <summary>
    /// Creates a table insert of the form 'INSERT INTO {tableName} VALUES(...)'.
    /// </summary>
    /// <param name="tableName">Name of table to insert into.</param>
    /// <returns></returns>
    public string GetEntitySQLInsert(string tableName);

    /// <summary>
    /// This sets the order of columns to the order provided. Any columns not defined will not be included in the final sql row insert.
    /// Any columns that don't already exist will be created and initialized to NULL.
    /// </summary>
    /// <param name="columnNames"></param>
    public void SetColumnOrder(params string[] columnNames);

    /// <summary>
    /// Deletes any previously set column order.
    /// </summary>
    public void DeleteColumnOrder();
}

public static class EntityDefaultImplementationExtensions
{
    public static string ConvertToSQLInsert(this IEntity entity, string tableName)
    {
        StringBuilder sb = new();
        sb.Append($"INSERT INTO {tableName} VALUES(");

        string[] keys;
        if (entity.GetColumnOrder().Length > 0)
        {
            keys = entity.GetColumnOrder();
        }
        else
        {
            keys = entity.GetColumns();
        }
        
        if (keys.Length > 0)
        {
            int iterator = 1;

            sb.Append(entity.GetValue(keys[0]) ?? "NULL");
            while (iterator < keys.Length)
            {
                sb.Append($", {(entity.GetValue(keys[iterator++]) ?? "NULL")}");
            }
        }
        sb.Append(");");
        return sb.ToString();
    }
}

public class Entity : IEntity
{
    protected Dictionary<string, string?> _kvp;
    protected string[] _columnOrder;

    public Entity(Dictionary<string, string?> intialValues)
    {
        _kvp = new();
        foreach(var kvp in intialValues)
        {
            _kvp[kvp.Key] = kvp.Value;
        }
        _columnOrder = Array.Empty<string>();
    }

    public Entity(params (string column, string? value)[] initialValues)
    {
        _kvp = new();
        foreach(var (column, value) in initialValues)
        {
            _kvp[column] = value;
        }
        _columnOrder = Array.Empty<string>();
    }

    #region For Collection Initalizers
    public IEnumerator GetEnumerator()
    {
        return _kvp.GetEnumerator();
    }

    public void Add(string column, string? value)
    {
        _kvp[column] = value == null ? "NULL" : value.ToSQLValue();
    }

    public void Add(string column, int value)
    {
        _kvp[column] = value.ToSQLValue();
    }

    public void Add(string column, double value)
    {
        _kvp[column] = value.ToSQLValue();
    }

    public void Add(string column, DateOnly value)
    {
        _kvp[column] = value.ToSQLValue();
    }

    public void Add(string column, TimeOnly value)
    {
        _kvp[column] = value.ToSQLValue();
    }

    public void Add(string column, DateTime value)
    {
        _kvp[column] = value.ToSQLValue();
    }
    #endregion

    public string[] GetColumns()
    {
        return _kvp.Keys.ToArray();
    }

    public string? GetValue(string column)
    {
        if (_kvp.TryGetValue(column, out var value)) return value;
        else return null;
    }

    public void RemoveColumn(string column)
    {
        if (_columnOrder.Contains(column)) throw new 
                ArgumentException($"Column '{column}' cannot be removed as it is defined in the column order. " +
                $"Set the column order to something that doesn't contain this column before removing it.");
        _kvp.Remove(column);
    }

    public bool HasColumn(string column) => _kvp.ContainsKey(column);

    public string GetEntitySQLInsert(string tableName)
    {
        return this.ConvertToSQLInsert(tableName);
    }

    public void DeleteColumnOrder() => _columnOrder = Array.Empty<string>();

    public void SetColumnOrder(params string[] columnNames)
    {
        _columnOrder = columnNames;
        foreach(var column in columnNames)
        {
            if (!_kvp.ContainsKey(column))
            {
                _kvp.Add(column, null);
            }
        }
    }

    public string[] GetColumnOrder() => _columnOrder;
}

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
