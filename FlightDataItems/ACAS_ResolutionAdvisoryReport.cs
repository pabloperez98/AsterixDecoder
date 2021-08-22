using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class ACAS_ResolutionAdvisoryReport
    {
        public string TYP;
        public string STYP;
        public string ARA;
        public string RAC;
        public string RAT;
        public string MTE;
        public string TTI;
        public string TID;

        public List<string> TableACAS_RAR = new List<string>();

        public ACAS_ResolutionAdvisoryReport()
        {
            this.TYP = "N/A";
            this.STYP = "N/A";
            this.ARA = "N/A";
            this.RAC = "N/A";
            this.RAT = "N/A";
            this.MTE = "N/A";
            this.TTI = "N/A";
            this.TID = "N/A";
        }

        public ACAS_ResolutionAdvisoryReport(List<string> BinaryACAS_RAR)
        {
            this.TYP = Convert.ToString(Convert.ToInt32(string.Join("",BinaryACAS_RAR.GetRange(0, 5)), 2));
            this.STYP = Convert.ToString(Convert.ToInt32(string.Join("", BinaryACAS_RAR.GetRange(5, 3)), 2));
            this.ARA = Convert.ToString(Convert.ToInt32(string.Join("", BinaryACAS_RAR.GetRange(8, 14)), 2));
            this.RAC = Convert.ToString(Convert.ToInt32(string.Join("", BinaryACAS_RAR.GetRange(22, 4)), 2));
            this.RAT = Convert.ToString(Convert.ToInt32(string.Join("", BinaryACAS_RAR.GetRange(26, 1)), 2));
            this.MTE = Convert.ToString(Convert.ToInt32(string.Join("", BinaryACAS_RAR.GetRange(27, 1)), 2));
            this.TTI = Convert.ToString(Convert.ToInt32(string.Join("", BinaryACAS_RAR.GetRange(28, 2)), 2));
            this.TID = Convert.ToString(Convert.ToInt32(string.Join("", BinaryACAS_RAR.GetRange(30, 26)), 2));
            
            TableACAS_RAR.Add("TYP"); TableACAS_RAR.Add(this.TYP);
            TableACAS_RAR.Add("STYP"); TableACAS_RAR.Add(this.STYP);
            TableACAS_RAR.Add("ARA"); TableACAS_RAR.Add(this.ARA);
            TableACAS_RAR.Add("RAC"); TableACAS_RAR.Add(this.RAC);
            TableACAS_RAR.Add("RAT"); TableACAS_RAR.Add(this.RAT);
            TableACAS_RAR.Add("MTE"); TableACAS_RAR.Add(this.MTE);
            TableACAS_RAR.Add("TTI"); TableACAS_RAR.Add(this.TTI);
            TableACAS_RAR.Add("TID"); TableACAS_RAR.Add(this.TID);
        }
    }
}
