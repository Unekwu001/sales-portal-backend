using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utility
{
    public static class DateFormater
    {
        public static string ToCustomDateString(this DateTime date)
        {
            string daySuffix = GetDaySuffix(date.Day);
            return $"{date:MMMM} {date.Day}{daySuffix}, {date:yyyy}";
        }

        private static string GetDaySuffix(int day)
        {
            switch (day % 10)
            {
                case 1 when day != 11:
                    return "st";
                case 2 when day != 12:
                    return "nd";
                case 3 when day != 13:
                    return "rd";
                default:
                    return "th";
            }
        }


        public static string FormatDateTime(DateTime dateTime)
        {
            string suffix = GetDaySuffix(dateTime.Day);
            string formattedDateTime = dateTime.ToString($"h:mmtt, d'{suffix}' MMMM, yyyy", System.Globalization.CultureInfo.InvariantCulture);
            return formattedDateTime.ToLower();
        }

        public static string ToCustomizedDateString(this DateTime dateTime)
        {
            string daySuffix = dateTime.Day switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                21 => "st",
                22 => "nd",
                23 => "rd",
                31 => "st",
                _ => "th"
            };
            return $"{dateTime.Day}{daySuffix} {dateTime:MMMM}, {dateTime:yyyy}";
        }

    }

}

