using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class PlotCountValues
    {
        public string REP;
        public string A;
        public string IDENT;
        public string COUNTER;

        public List<string> TablePCV = new List<string>();

        public PlotCountValues(List<string> BinaryMOPSVersion)
        {
            List<string> defaultA = new List<string>() { "Counter for antenna 1", "Counter for antenna 2" };
            List<string> defaultIDENT = new List<string>() { "N/A", "Sole primary plots", "Sole SSR plots", "Combined plots" };

            this.REP = Convert.ToInt32(string.Join("", BinaryMOPSVersion.GetRange(0, 8)), 2).ToString();

            for (int i = 0; i < Convert.ToInt32(this.REP); i++)
            {
                this.A = defaultA[Convert.ToInt32(BinaryMOPSVersion[8 + 16 * i], 2)];
                this.IDENT = defaultIDENT[Convert.ToInt32(string.Join("", BinaryMOPSVersion.GetRange(9 + 16 * i, 5)), 2)];
                this.COUNTER = Convert.ToInt32(string.Join("", BinaryMOPSVersion.GetRange(14 + 16 * i, 10)), 2).ToString();
                this.TablePCV.Add(this.A); this.TablePCV.Add(this.IDENT); this.TablePCV.Add(this.COUNTER);
            }
        }
        public PlotCountValues()
        {
            this.REP = "N/A";
            this.A = "N/A";
            this.IDENT = "N/A";
            this.COUNTER = "N/A";
        }
    }
}
