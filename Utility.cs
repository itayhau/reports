using System;
using System.Collections.Generic;
using System.Text;

namespace CORD
{
    public static class Utility
    {
        public static DateTime ConvertToDateTime(string formattedDateTime)
        {
            string[] dateTimeSections = formattedDateTime.Split('.');
            int dayOffset = Convert.ToInt32(dateTimeSections[0]);

            string[] timeSections = dateTimeSections[1].Split(':');
            int hour = Convert.ToInt32(timeSections[0]);
            int minutes = Convert.ToInt32(timeSections[1]);

            DateTime dateTime = new DateTime();
            dateTime = dateTime.AddDays(dayOffset);
            dateTime = dateTime.AddHours(hour);
            dateTime = dateTime.AddMinutes(minutes);

            return dateTime;
        }
    }
}
