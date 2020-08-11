using System;

namespace Core.Utils
{
    public static class DateTimeUtil
    {
        public static DateTime AddTimeToDate(DateTime date, int hours = 0, int minutes = 0, int seconds = 0)
        {
            date = date.AddHours(hours);
            date = date.AddMinutes(minutes);
            date = date.AddSeconds(seconds);
            return date;
        }
    }
}
