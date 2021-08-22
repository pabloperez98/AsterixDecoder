using System.Collections.Generic;

namespace FlightDataItems
{
    public class SystemConfigurationStatus
    {
        //COM Subfield
        public string NOGO;
        public string RDPC;
        public string RDPR;
        public string OVL_RDP;
        public string OVL_XMT;
        public string MSC_COM;
        public string TSV;
        //PSR Subfield
        public string ANT_PSR;
        public string CH_A_B_PSR;
        public string OVL_PSR;
        public string MSC_PSR;
        //SSR Subfield
        public string ANT_SSR;
        public string CH_A_B_SSR;
        public string OVL_SSR;
        public string MSC_SSR;
        //MDS Subfield
        public string ANT_MDS;
        public string CH_A_B_MDS;
        public string OVL_SUR;
        public string MSC_MDS;
        public string SCF;
        public string DLF;
        public string OVL_SCF;
        public string OVL_DLF;

        public List<string> TableSCS = new List<string>();

        public SystemConfigurationStatus()
        {
            //COM Subfield
            this.NOGO = "N/A";
            this.RDPC = "N/A";
            this.RDPR = "N/A";
            this.OVL_RDP = "N/A";
            this.OVL_XMT = "N/A";
            this.MSC_COM = "N/A";
            this.TSV = "N/A";
            //PSR Subfield
            this.ANT_PSR = "N/A";
            this.CH_A_B_PSR = "N/A";
            this.OVL_PSR = "N/A";
            this.MSC_PSR = "N/A";
            //SSR Subfield
            this.ANT_SSR = "N/A";
            this.CH_A_B_SSR = "N/A";
            this.OVL_SSR = "N/A";
            this.MSC_SSR = "N/A";
            //MDS Subfield
            this.ANT_MDS = "N/A";
            this.CH_A_B_MDS = "N/A";
            this.OVL_SUR = "N/A";
            this.MSC_MDS = "N/A";
            this.SCF = "N/A";
            this.DLF = "N/A";
            this.OVL_SCF = "N/A";
            this.OVL_DLF = "N/A";
        }

        public void InsertSCSinfoInTable(string field, string value)
        {
            this.TableSCS.Add(field);
            this.TableSCS.Add(value);
        }
    }
}
