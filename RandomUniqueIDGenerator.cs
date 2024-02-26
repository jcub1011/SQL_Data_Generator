using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator;

public class RandomUniqueIDGenerator
{
    HashSet<int> _existingNums;
    Random _rand;

    public RandomUniqueIDGenerator()
    {
        _existingNums = new();
        _rand = new((int)DateTime.Now.Ticks);
    }

    public int GetUniqueID(int maxValue = int.MaxValue)
    {
        int value = _rand.Next(maxValue);

        while (_existingNums.Contains(value))
        {
            _rand.Next(maxValue);
        }

        _existingNums.Add(value);
        return value;
    }
}
