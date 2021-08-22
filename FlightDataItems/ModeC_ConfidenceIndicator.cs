using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class ModeC_ConfidenceIndicator
    {
        public string V;
        public string G;
        public string grayHeight;
        public string qualityPulse;

        public List<string> TableMCC = new List<string>();
        public ModeC_ConfidenceIndicator()
        {
            this.V = "N/A";
            this.G = "N/A";
            this.grayHeight = "N/A";
        }
        public ModeC_ConfidenceIndicator(List<string> BinModeC)
        {
            List<string> defaultV = new List<string>() { "Code validated", "Code not validated" };
            List<string> defaultG = new List<string>() { "Default", "Garbled code" };

            this.V = defaultV[Convert.ToInt32(BinModeC[0], 2)];
            this.G = defaultG[Convert.ToInt32(BinModeC[1], 2)];
            this.grayHeight = Convert.ToString(Convert.ToInt32(string.Join("", BinModeC.GetRange(4, 12)), 2), 8);
            this.qualityPulse = Convert.ToString(Convert.ToInt32(string.Join("", BinModeC.GetRange(20, 12)), 2), 8);
            while (qualityPulse.Length < this.grayHeight.Length)
                this.qualityPulse = this.qualityPulse.Insert(0, "0");
            this.TableMCC.Add("V"); this.TableMCC.Add(this.V);
            this.TableMCC.Add("G"); this.TableMCC.Add(this.G);
            this.TableMCC.Add("Quality Pulse"); this.TableMCC.Add(this.qualityPulse);
        }
    }
}
