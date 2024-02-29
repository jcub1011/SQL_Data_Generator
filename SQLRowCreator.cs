using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator;

public static class SQLRowCreator
{
    /// <summary>
    /// Creates an sql insert row. 
    /// Requires the strings to have already been formatted as an sql datatype.
    /// </summary>
    /// <param name="tableName"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static string CreateRow(string tableName, params string[] values)
    {
        if (values == null
            || values.Length == 0
            || tableName == null) return "";

        StringBuilder returnValue = new();

        returnValue.Append($"INSERT INTO {tableName} VALUES(");

        int iterator = 0;
        returnValue.Append(values[iterator++]);

        while (iterator < values.Length)
        {
            returnValue.Append($", {values[iterator++]}");
        }

        returnValue.Append(");");
        return returnValue.ToString();
    }

    /// <summary>
    /// Creates an sql insert row. 
    /// Supports int, double, DateTime, and string. 
    /// Returns an empty string if values contians an unsupported type.
    /// </summary>
    /// <param name="tableName"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static string CreateRow(string tableName, params object[] values)
    {
        string[] returnList = new string[values.Length];
        int i = 0;
        string? result;

        foreach(var obj in values)
        {
            result = obj.ToSQLValue();
            if (result is null) return "";
            else returnList[i++] = result;
        }

        return CreateRow(tableName, returnList);
    }
}
