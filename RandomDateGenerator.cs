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
        public static DateTime GetRandPastDate(int minYear, int minMonth, int minDay)
        {
            /// Thanks to https://stackoverflow.com/questions/194863/random-date-in-c-sharp
            /// for the algorithm.
            DateTime start = new(minYear, minMonth, minDay);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_rand.Next(range));
        }


        public static DateTime GetRandDateBetween(DateTime startTime, DateTime endTime, int startHour, int endHour, int minuteIncrement)
        {
            int dayDif = (endTime - startTime).Days;
            startTime.AddDays(_rand.Next(dayDif+1));
            long miliStart = startHour * 3600000;
            long miliEnd = endHour * 3600000;
            long displacement = (long)(_rand.NextDouble() * (miliEnd - miliStart));
            displacement -= displacement % (minuteIncrement * 60000);
            return startTime.AddDays(_rand.Next(dayDif)).AddMilliseconds(displacement + miliStart);
        }

        /// <summary>
        /// Creates a random date starting from [today - dayRange] to 
        /// [today + dayRange].
        /// </summary>
        /// <param name="dayRange"></param>
        /// <returns></returns>
        public static DateTime GetRandDateWithinRange(int dayRange)
        {
            DateTime middle = DateTime.Today;
            int range = _rand.Next(dayRange * 2);

            return middle.AddDays(range - dayRange);
        }
    }
}
