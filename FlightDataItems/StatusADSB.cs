using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class StatusADSB
    {
        public string AC;
        public string MN;
        public string DC;
        public string GBS;
        public string STAT;

        public List<string> TableSADSB = new List<string>();

        public StatusADSB()
        {
            this.AC = "N/A";
            this.MN = "N/A";
            this.DC = "N/A";
            this.GBS = "N/A";
            this.STAT = "N/A";
        }

        public StatusADSB(List<string> BinaryACAS_RAR)
        {
            List<string> defaultAC = new List<string>() { "Unknown", "ACAS not operational", "ACAS operational", "Invalid" };
            List<string> defaultMN = new List<string>() { "Unknown", "Multiple navigational aids not operating", "Multiple navigational aids operating", "Invalid" };
            List<string> defaultDC = new List<string>() { "Unknown", "Differential correction ", "No differential correction", "Invalid" };
            List<string> defaultGBS = new List<string>() { "Transponder Ground Bit not set or unknown", "Transponder Ground Bit set" };
            List<string> defaultSTAT = new List<string>() { "No emergency", "General emergency", "Lifeguard/medical", "Minimum fuel", "No communications", "Unlawful interference", "“Downed” Aircraft", "Unknown" };

            this.AC = defaultAC[Convert.ToInt32(string.Join("", BinaryACAS_RAR.GetRange(0, 2)), 2)];
            this.MN = defaultMN[Convert.ToInt32(string.Join("", BinaryACAS_RAR.GetRange(2, 2)), 2)];
            this.DC = defaultDC[Convert.ToInt32(string.Join("", BinaryACAS_RAR.GetRange(4, 2)), 2)];
            this.GBS = defaultGBS[Convert.ToInt32(BinaryACAS_RAR[6], 2)];
            this.STAT = defaultSTAT[Convert.ToInt32(string.Join("", BinaryACAS_RAR.GetRange(13, 3)), 2)];

            TableSADSB.Add("AC"); TableSADSB.Add(this.AC);
            TableSADSB.Add("MN"); TableSADSB.Add(this.MN);
            TableSADSB.Add("DC"); TableSADSB.Add(this.DC);
            TableSADSB.Add("GBS"); TableSADSB.Add(this.GBS);
            TableSADSB.Add("STAT"); TableSADSB.Add(this.STAT);
        }
    }
}
