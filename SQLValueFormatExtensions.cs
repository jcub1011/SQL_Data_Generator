using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator;

public static class SQLValueFormatExtensions
{
    public static string AsSQLInt(this int value)
    {
        return value.ToString();
    }

    public static string AsSQLDate(this DateTime value)
    {
        return $"'{value.Year}-{value.Month}-{value.Day}'";
    }

    public static string AsSQLString(this string value)
    {
        return $"'{value}'";
    }

    public static string AsSQLDoublePrecision(this double value)
    {
        return value.ToString();
    }

    public static string? ToSQLValue(this object value)
    {
        if (value is int num) return num.AsSQLInt();
        else if (value is string str) return str.AsSQLString();
        else if (value is double d) return d.AsSQLDoublePrecision();
        else if (value is DateTime date) return date.AsSQLDate();
        else return null;
    }
}
