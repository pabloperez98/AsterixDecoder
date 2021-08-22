using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class Presence
    {
        public string REP;
        public string DRHO;
        public string DTheta;

        public List<string> TableP = new List<string>();

        public Presence(List<string> BinPresence)
        {
            this.REP = Convert.ToInt32(string.Join("", BinPresence.GetRange(0, 8)), 2).ToString();
            for (int i = 0; i < Convert.ToInt32(this.REP); i++)
            {
                this.DRHO = Convert.ToInt32(string.Join("", BinPresence.GetRange(8 + 16 * i, 8)), 2).ToString();
                this.DTheta = (Convert.ToInt32(string.Join("", BinPresence.GetRange(16 + 16 * i, 8)), 2) * 0.15).ToString();
                this.TableP.Add(this.DRHO); this.TableP.Add(this.DTheta);
            }
        }
        public Presence()
        {
            this.REP = "N/A";
            this.DRHO = "N/A";
            this.DTheta = "N/A";
        }
    }
}
