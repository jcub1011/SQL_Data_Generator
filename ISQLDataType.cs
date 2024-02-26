using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator
{
    public interface ISQLDataType
    {
        public string GetValue();
    }
}
