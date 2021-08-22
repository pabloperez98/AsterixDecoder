using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDataItems
{
    public class DataAges
    {
        public string AOS;
        public string TRD;
        public string M3A;
        public string QI;
        public string TI;
        public string MAM;
        public string GH;
        public string FL;
        public string ISA;
        public string FSA;
        public string AS;
        public string TAS;
        public string MH;
        public string BVR;
        public string GVR;
        public string GV;
        public string TAR;
        public string TId;
        public string TS;
        public string MET;
        public string ROA;
        public string ARA;
        public string SCC;
        public List<string> TableDA = new List<string>();
        public DataAges()
        {
            this.AOS = "N/A"; this.TRD = "N/A"; this.M3A = "N/A"; this.QI = "N/A"; this.TI = "N/A"; this.MAM = "N/A"; this.GH = "N/A"; this.FL = "N/A"; this.ISA = "N/A";
            this.FSA = "N/A"; this.AS = "N/A"; this.TAS = "N/A"; this.MH = "N/A"; this.BVR = "N/A"; this.GVR = "N/A"; this.GV = "N/A"; this.TAR = "N/A"; this.TId = "N/A";
            this.TS = "N/A"; this.MET = "N/A"; this.ROA = "N/A"; this.ARA = "N/A"; this.SCC = "N/A"; 
        }

        public void InsertMetInfoInTable(string field, string value)
        {
            this.TableDA.Add(field);
            this.TableDA.Add(value);
        }
    }
}