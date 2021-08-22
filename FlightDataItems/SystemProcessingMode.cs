using System.Collections.Generic;

namespace FlightDataItems
{
    public class SystemProcessingMode
    {
        //COM Subfield
        public string RED_RDP;
        public string RED_XMT;
        //PSR Subfield
        public string POL;
        public string RED_RAD_PSR;
        public string STC;
        //SSR Subfield
        public string RED_RAD_SSR;
        //MDS Subfield
        public string RED_RAD_MDS;
        public string CLU;

        public List<string> TableSPM = new List<string>();

        public SystemProcessingMode()
        {
            //COM Subfield
            this.RED_RDP = "N/A";
            this.RED_XMT = "N/A";
            //PSR Subfield
            this.POL = "N/A";
            this.RED_RAD_PSR = "N/A";
            this.STC = "N/A";
            //SSR Subfield
            this.RED_RAD_SSR = "N/A";
            //MDS Subfield
            this.RED_RAD_MDS = "N/A";
            this.CLU = "N/A";
    }

        public void InsertSPMinfoInTable(string field, string value)
        {
            this.TableSPM.Add(field);
            this.TableSPM.Add(value);
        }
    }
}
