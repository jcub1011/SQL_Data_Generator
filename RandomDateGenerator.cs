﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator
{
    public static class RandomDateGenerator
    {
        static Random _rand = new();

        /// <summary>
        /// Creates a random date starting from the min date to today.
        /// </summary>
        /// <param name="minYear"></param>
        /// <param name="minMonth"></param>
        /// <param name="minDay"></param>
        /// <returns></returns>
        public static DateTime GetRandDate(int minYear, int minMonth, int minDay)
        {
            /// Thanks to https://stackoverflow.com/questions/194863/random-date-in-c-sharp
            /// for the algorithm.
            DateTime start = new(minYear, minMonth, minDay);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_rand.Next(range));
        }
    }
}