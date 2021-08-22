using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class ReportType
    {
        public string TYP;
        public string SIM;
        public string RAB;
        public string TST;

        public List<string> TableRT = new List<string>();

        public ReportType()
        {
            this.TYP = "N/A";
            this.SIM = "N/A";
            this.RAB = "N/A";
            this.TST = "N/A";
        }

        public ReportType(List<string> BinaryRT)
        {
            List<string> defaultTYP = new List<string>() { "No detection", "Single PSR detection", "Single SSR detection", "SSR + PSR detection", "Single ModeS All-Call", "Single ModeS Roll-Call", "ModeS All-Call + PSR", "ModeS Roll-Call + PSR" };
            List<string> defaultSIM = new List<string>() { "Actual target report", "Simulated target report" };
            List<string> defaultRAB = new List<string>() { "Report from target transponder", "Report from field monitor (fixed tranponder)" };
            List<string> defaultTST = new List<string>() { "Real target report", "Test target report" };
            
            this.TYP = defaultTYP[Convert.ToInt32(string.Join("", BinaryRT.GetRange(0, 3)), 2)];
            this.SIM = defaultSIM[Convert.ToInt32(BinaryRT[3], 2)];
            this.RAB = defaultRAB[Convert.ToInt32(BinaryRT[4], 2)];
            this.TST = defaultTST[Convert.ToInt32(BinaryRT[5], 2)];

            this.TableRT.Add("TYP"); this.TableRT.Add(this.TYP);
            this.TableRT.Add("SIM"); this.TableRT.Add(this.SIM);
            this.TableRT.Add("RAB"); this.TableRT.Add(this.RAB);
            this.TableRT.Add("TST"); this.TableRT.Add(this.TST);
        }
    }
}
