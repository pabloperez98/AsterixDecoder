using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class FlightCategory
    {
        public string GAT_OAT;
        public string FR1_FR2;
        public string RVSM;
        public string HPR;

        public List<string> TableFC = new List<string>();

        public FlightCategory()
        {
            this.GAT_OAT = "N/A";
            this.FR1_FR2 = "N/A";
            this.RVSM = "N/A";
            this.HPR = "N/A";
        }

        public FlightCategory(List<string> BinFC)
        {
            List<string> defaultGAT_OAT = new List<string>() { "Unknown", "General Air Traffic", "Operational Air Traffic", "Not applicable" };
            List<string> defaultFR1_FR2 = new List<string>() { "Instrument Flight Rules", "Visual Flight Rules", "Not applicable", "Controlled Visual Flight Rules" };
            List<string> defaultRVSM = new List<string>() { "Unknown", "Approved", "Exempt", "Not Approved" };
            List<string> defaultHPR = new List<string>() { "Normal Priority Flight", "High Priority Flight" };

            this.GAT_OAT = defaultGAT_OAT[Convert.ToInt32(string.Join("", BinFC.GetRange(0, 2)), 2)];
            this.FR1_FR2 = defaultFR1_FR2[Convert.ToInt32(string.Join("", BinFC.GetRange(2, 2)), 2)];
            this.RVSM = defaultRVSM[Convert.ToInt32(string.Join("", BinFC.GetRange(4, 2)), 2)];
            this.HPR = defaultHPR[Convert.ToInt32(string.Join("", BinFC.GetRange(6, 1)), 2)];

            this.TableFC.Add("GAT/OAT"); this.TableFC.Add(this.GAT_OAT);
            this.TableFC.Add("FR1/FR2"); this.TableFC.Add(this.FR1_FR2);
            this.TableFC.Add("RVSM"); this.TableFC.Add(this.RVSM);
            this.TableFC.Add("HPR"); this.TableFC.Add(this.HPR);
        }
    }
}
