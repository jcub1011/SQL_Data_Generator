using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator
{
    public readonly struct SQLString: ISQLDataType
    {
        readonly string _value;

        public SQLString(string value)
        {
            _value = value;
        }

        public string GetValue()
        {
            return $"'{_value}'";
        }
    }
}
