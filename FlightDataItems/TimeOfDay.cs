using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightDataItems
{
    public class TimeOfDay
    {
        public string timeUTC;
        public double seconds;
        public double decimalSeconds;

        public TimeOfDay()
        {
            this.timeUTC = "N/A";
        }
        public TimeOfDay(List<string> BinTimeOfDay, string category, int numberOf512s)
        {
            double DoubleSeconds;
            if (BinTimeOfDay.Count() == 8 * 4) // Time High Precision (4 octets)
            {
                DoubleSeconds = Convert.ToInt32(string.Join("", BinTimeOfDay.GetRange(2, 30)), 2) * Math.Pow(2, -30);
                if (BinTimeOfDay[0] + BinTimeOfDay[1] == "10")
                    DoubleSeconds -= 1;
                if (BinTimeOfDay[0] + BinTimeOfDay[1] == "11")
                    DoubleSeconds += 1;
            }
            else
            { 
                DoubleSeconds = Convert.ToInt32(string.Join("", BinTimeOfDay), 2) * 1 / 128.0;
                if (category == "01")
                    DoubleSeconds += 512 * numberOf512s;
            } 
            this.seconds = Math.Truncate(DoubleSeconds);
            this.decimalSeconds = DoubleSeconds;
            this.timeUTC = obtainTimeUTC(DoubleSeconds) + "." + Convert.ToString(Math.Truncate((decimalSeconds - Math.Truncate(decimalSeconds)) * 1000)).PadLeft(3, '0');
        }

        public static string obtainTimeUTC(double seconds)
        {
            Int32 hours = Convert.ToInt32(Math.Truncate(seconds)) / 3600;
            Int32 minutes = (Convert.ToInt32(Math.Truncate(seconds)) - hours * 3600) / 60;
            double segundos = Convert.ToInt32(Math.Truncate(seconds)) - (hours * 3600 + minutes * 60);
            return string.Concat(Convert.ToString(hours).PadLeft(2, '0'), ":", Convert.ToString(minutes).PadLeft(2, '0'), ":", Convert.ToString(segundos).PadLeft(2, '0'));
        }
    }  
}