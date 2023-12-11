using System;
using System.Globalization;

namespace FroumSite.Utilities
{
    public static class DateConverter
    {
        public static string ToShamsi(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();

            return $"{pc.GetYear(date)}/" +
                   $"{pc.GetMonth(date).ToString("00")}/" +
                   $"{pc.GetDayOfMonth(date).ToString("00")}";

        }
    }
}
