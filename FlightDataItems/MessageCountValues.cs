using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class MessageCountValues
    {
        public string REP;
        public string TYP;
        public string COUNTER;

        public List<string> TableMCV = new List<string>();

        public MessageCountValues(List<string> BinaryMOPSVersion)
        {
            List<string> defaultTYP = new List<string>() { "No detection (number of misses)", "Single PSR target reports", "Single SSR target reports (Non-Mode S)", "SSR+PSR target reports (Non-Mode S)", "Single All-Call target reports (Mode S)", "Single Roll-Call target reports (Mode S)", "All-Call + PSR (Mode S) target reports", "Roll-Call + PSR (Mode S) target reports", "Filter for Weather data", "Filter for Jamming Strobe", "Filter for PSR data", "Filter for SSR/Mode S data", "Filter for SSR/Mode S+PSR data", "Filter for Enhanced Surveillance data", "Filter for PSR+Enhanced Surveillance", "Filter for PSR+Enhanced Surveillance + SSR/Mode S data not in Area of Prime Interest", "Filter for PSR+Enhanced Surveillance + all SSR/Mode S data" };
            this.REP = Convert.ToInt32(string.Join("", BinaryMOPSVersion.GetRange(0, 8)), 2).ToString();
            for (int i = 0; i < Convert.ToInt32(this.REP); i++)
            {
                this.TYP = defaultTYP[Convert.ToInt32(string.Join("", BinaryMOPSVersion.GetRange(8 + 16 * i, 5)), 2)];
                this.COUNTER = Convert.ToInt32(string.Join("", BinaryMOPSVersion.GetRange(13 + 16 * i, 11)), 2).ToString();
                this.TableMCV.Add(this.TYP); this.TableMCV.Add(this.COUNTER);
            }
        }
        public MessageCountValues()
        {
            this.REP = "N/A";
            this.TYP = "N/A";
            this.COUNTER = "N/A";
        }
    }
}
