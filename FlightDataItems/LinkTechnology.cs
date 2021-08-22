using System.Collections.Generic;

namespace FlightDataItems
{
    public class LinkTechnololy
    {
        public string DTI;
        public string MDS;
        public string UAT;
        public string VDL;
        public string OTR;

        public List<string> TableLT = new List<string>();
        public LinkTechnololy(List<string> BinLinkTechnology)
        {
            List<string> defaultLTI = new List<string> { "Unknown", "Aircraft equiped with CDTI", "Not used", "Used" };
            if (BinLinkTechnology[3] == "1")
                this.DTI = defaultLTI[1];
            else
                this.DTI = defaultLTI[0];
            if (BinLinkTechnology[4] == "1")
                this.MDS = defaultLTI[3];
            else
                this.MDS = defaultLTI[2];
            if (BinLinkTechnology[5] == "1")
                UAT = defaultLTI[3];
            else
                UAT = defaultLTI[2];
            if (BinLinkTechnology[6] == "1")
                VDL = defaultLTI[3];
            else
                VDL = defaultLTI[2];
            if (BinLinkTechnology[7] == "1")
                OTR = defaultLTI[3];
            else if (BinLinkTechnology[7] == "0")
                OTR = defaultLTI[2];

            this.TableLT.Add("DTI"); this.TableLT.Add(this.DTI);
            this.TableLT.Add("MDS"); this.TableLT.Add(this.MDS);
            this.TableLT.Add("UAT"); this.TableLT.Add(this.UAT);
            this.TableLT.Add("VDL"); this.TableLT.Add(this.VDL);
            this.TableLT.Add("OTR"); this.TableLT.Add(this.OTR);
        }
        public LinkTechnololy()
        {
            DTI = "N/A";
            MDS = "N/A";
            UAT = "N/A";
            VDL = "N/A";
            OTR = "N/A";
        }
    }
}
