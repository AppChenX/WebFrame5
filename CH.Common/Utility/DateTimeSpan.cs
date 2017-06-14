using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH.Common
{
   public static class DateTimeSpan
    {

       public static double ToTimestamp(this DateTime value)
        {
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return (double)span.TotalSeconds;
        }

       public static DateTime ConvertTimestamp(this double timestamp)
        {
            DateTime converted = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime newDateTime = converted.AddSeconds(timestamp);
            return newDateTime.ToLocalTime();
        } 
    }
}
