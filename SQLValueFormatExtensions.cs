using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator;

public static class SQLValueFormatExtensions
{
    public static string AsSQLNumber(this int value)
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
}
