using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator;

public readonly struct SQLDate : ISQLDataType
{
    readonly DateTime _date;

    public SQLDate(DateTime date)
    {
        _date = date;
    }

    public string GetValue()
    {
        return $"'{_date.Year}-{_date.Month}-{_date.Day}'";
    }
}
