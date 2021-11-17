using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    class Stardate
    {
        public float CurrentStarDate { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public int BaseDate { get; set; }

        private int StarYear(int year)
        {
            return 1000 * (year - BaseDate);
        }

        private int DaysInYear(int year)
        {
            return DateTime.IsLeapYear(year) ? 365 : 364;
        }

        private int DayOfYear(int year, int month, int day)
        {
            int[] dayOfYear = new int[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
            int monthNumber = month - 1;
            monthNumber = dayOfYear[monthNumber] - 1;

            if (DateTime.IsLeapYear(year))
            {
                monthNumber++;
            }
            return monthNumber;
        }

        private int StarDay(int year, int month, int day)
        {
            return 1000 / DaysInYear(year) * DayOfYear(year, month, day);
        }

        public float GetStardate()
        {

            /*
             *   // b: base date
    // c: star date year
    // d: day
    // m: month number
    // n: number of days in year
    // y: year

    const b = 2323;
    const c = 0.00;
    const d = today.getDate();
    const m = today.getMonth() + 1;
    const n = 365;
    const y = today.getFullYear();
    const stardate = c + (1000 * (y - b)) + ((1000 / n) * (m + d - 1));
             */

            DateTime now = DateTime.Now;
            Year = now.Year + 1900;

            // Month gets 1 (January).
            Month = now.Month;

            // Day gets 13.
            Day = now.Day;

            BaseDate = 2323;

            return (StarYear(Year)) + ((1000 / DaysInYear(Year)) * (Month + Day - 1));
        }
    }
}
