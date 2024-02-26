using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator;

public static class SQLRowCreator
{
    public static string CreateRow(string tableName, List<ISQLDataType> values)
    {
        return CreateRow(tableName, values.ToArray());
    }

    public static string CreateRow(string tableName, params ISQLDataType[] values)
    {
        if (values == null
            || values.Length == 0
            || tableName == null) return "";

        StringBuilder returnValue = new();

        returnValue.Append($"insert into {tableName} values(");

        int iterator = 0;
        returnValue.Append(values[iterator++].GetValue());

        while (iterator < values.Length)
        {
            returnValue.Append($", {values[iterator++].GetValue()}");
        }

        returnValue.Append(");");
        return returnValue.ToString();
    }
}
