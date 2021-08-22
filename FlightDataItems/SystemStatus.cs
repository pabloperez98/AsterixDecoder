using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class SystemStatus
    {
        public string NOGO;
        public string OVL;
        public string TSV;
        public string DIV;
        public string TTF;

        public List<string> TableSS = new List<string>();
        public SystemStatus()
        {
            this.NOGO = "N/A";
            this.OVL = "N/A";
            this.TSV = "N/A";
            this.DIV = "N/A";
            this.TTF = "N/A";
        }
        public SystemStatus(List<string> BinSystemStatus)
        {
            List<string> defaultNOGO = new List<string>() { "Operational", "Degraded", "NOGO" };
            List<string> defaultOVL = new List<string>() { "No overload", "Overload" };
            List<string> defaultTSV = new List<string>() { "Valid", "Invalid" };
            List<string> defaultDIV = new List<string>() { "Normal Operation", "Diversity Degraded" };
            List<string> defaultTTF = new List<string>() { "Test Target Operative", "Test Target Failure" };
            this.NOGO = defaultNOGO[Convert.ToInt32((BinSystemStatus[0] + BinSystemStatus[1]), 2)];
            this.OVL = defaultOVL[Convert.ToInt32(BinSystemStatus[2], 2)];
            this.TSV = defaultTSV[Convert.ToInt32(BinSystemStatus[3], 2)];
            this.DIV = defaultDIV[Convert.ToInt32(BinSystemStatus[4], 2)];
            this.TTF = defaultTTF[Convert.ToInt32(BinSystemStatus[5], 2)];

            this.TableSS.Add("NOGO"); this.TableSS.Add(this.NOGO);
            this.TableSS.Add("OVL"); this.TableSS.Add(this.OVL);
            this.TableSS.Add("TSV"); this.TableSS.Add(this.TSV);
            this.TableSS.Add("DIV"); this.TableSS.Add(this.DIV);
            this.TableSS.Add("TIF"); this.TableSS.Add(this.TTF);
        }
    }
}
