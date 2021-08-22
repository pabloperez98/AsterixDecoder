using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class MOPSversion
    {
        public string VNS;
        public string VN;
        public string LTT;
        public List<string> TableMOPS = new List<string>();
        public string version;

        public MOPSversion(List<string> BinaryMOPSVersion)
        {
            List<string> defaultVNS = new List<string>() { "The MOPS Version is supported by the GS", "The MOPS Version is not supported by the GS" };
            List<string> defaultVN = new List<string>() { "0: ED012/BO.260[Ref. 8]", "1: DO-260A[Ref .9]", "2: ED102A/DO-260B [Ref .11]" };
            List<string> defaultLTT = new List<string>() { "Other", "UAT", "1090 ES", "VDL 4", "Not assigned", "Not assigned", "Not assigned", "Not assigned" };

            this.VNS = defaultVNS[Convert.ToInt32(BinaryMOPSVersion[1], 2)];
            this.VN = defaultVN[Convert.ToInt32(BinaryMOPSVersion[2] + BinaryMOPSVersion[3] + BinaryMOPSVersion[4], 2)];
            this.version = Convert.ToInt32(BinaryMOPSVersion[2] + BinaryMOPSVersion[3] + BinaryMOPSVersion[4], 2).ToString();
            this.LTT = defaultLTT[Convert.ToInt32(BinaryMOPSVersion[5] + BinaryMOPSVersion[6] + BinaryMOPSVersion[7], 2)];
            this.TableMOPS.Add("VNS"); this.TableMOPS.Add(this.VNS);
            this.TableMOPS.Add("VN"); this.TableMOPS.Add(this.VN);
            this.TableMOPS.Add("LTT"); this.TableMOPS.Add(this.LTT);
        }
        public MOPSversion()
        {
            this.VNS = "N/A";
            this.VN = "N/A";
            this.LTT = "N/A";
            this.version = "N/A";
        }
    }
}
