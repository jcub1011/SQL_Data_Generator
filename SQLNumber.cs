using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator
{
    public readonly struct SQLNumber: ISQLDataType
    {
        readonly int _value;

        public SQLNumber(int value)
        {
            _value = value;
        }

        public string GetValue()
        {
            return $"{_value}";
        }
    }
}
