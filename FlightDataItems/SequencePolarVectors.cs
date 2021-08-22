using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class SequencePolarVectors
    {
        public string REP;
        public string startRange;
        public string endRange;
        public string azimuth;

        public List<string> TableSPV = new List<string>();

        public SequencePolarVectors()
        {
            this.REP = "N/A";
            this.startRange = "N/A"; ;
            this.endRange = "N/A";
            this.azimuth = "N/A";
        }

        public SequencePolarVectors(List<string> BinarySPV)
        {
            this.REP = Convert.ToInt32(string.Join("", BinarySPV.GetRange(0, 8)), 2).ToString();
            for (int i = 0; i < Convert.ToInt32(this.REP); i++)
            {
                this.startRange = (Convert.ToInt32(string.Join("", BinarySPV.GetRange(8 + 32 * i, 8)), 2) * Math.Pow(2, 0)).ToString(); // [NM]
                this.endRange = (Convert.ToInt32(string.Join("", BinarySPV.GetRange(16 + 32 * i, 8)), 2) * Math.Pow(2, 0)).ToString(); // [NM]
                this.azimuth = (Convert.ToInt32(string.Join("", BinarySPV.GetRange(24 + 32 * i, 16)), 2) * 360 / Math.Pow(2, 16)).ToString(); // [º]
                this.TableSPV.Add(this.startRange); this.TableSPV.Add(this.endRange); this.TableSPV.Add(Math.Round(Convert.ToDouble(this.azimuth), 2).ToString());
            }
        }
    }
}
