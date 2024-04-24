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

    /// <summary>
    /// No time zone is specified. Up to second resolution.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string AsSQLDateTime(this DateTime value)
    {
        return $"'{value.Year}-{value.Month}-{value.Day} {value.Hour}:{value.Minute}:{value.Second}'";
    }

    /// <summary>
    /// Up to second resolution.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string AsSQLDateOnly(this DateOnly value)
    {
        return $"'{value.Year}-{value.Month}-{value.Day}'";
    }

    /// <summary>
    /// Up to second resolution.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string AsSQLTimeOnly(this TimeOnly value)
    {
        return $"'{value.Hour}:{value.Minute}:{value.Second}'";
    }

    public static string AsISODate(this DateTime value)
    {
        return value.ToString("s");
    }

    public static string AsSQLString(this string value)
    {
        return $"'{value}'";
    }

    public static string AsSQLDoublePrecision(this double value)
    {
        return value.ToString();
    }

    /// <summary>
    /// Attempts to convert to an sql value and returns null if no definition exists.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string? ToSQLValue(this object value)
    {
        if (value is int num) return num.AsSQLInt();
        else if (value is string str) return str.AsSQLString();
        else if (value is double d) return d.AsSQLDoublePrecision();
        else if (value is DateTime timestamp) return timestamp.AsSQLDateTime();
        else if (value is TimeOnly time) return time.AsSQLTimeOnly();
        else if (value is DateOnly date) return date.AsSQLDateOnly();
        else return null;
    }
}
