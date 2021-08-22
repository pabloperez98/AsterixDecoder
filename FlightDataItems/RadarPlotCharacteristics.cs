using System.Collections.Generic;

namespace FlightDataItems
{
    public class RadarPlotCharacteristics
    {
        public string SRL;
        public string SRR;
        public string SAM;
        public string PRL;
        public string PAM;
        public string RPD;
        public string APD;

        public List<string> TableRPC = new List<string>();

        public RadarPlotCharacteristics()
        {
            this.SRL = "N/A";
            this.SRR = "N/A";
            this.SAM = "N/A";
            this.PRL = "N/A";
            this.PAM = "N/A";
            this.RPD = "N/A";
            this.APD = "N/A";
        }
        public void InsertSCSinfoInTable(string field, string value)
        {
            this.TableRPC.Add(field);
            this.TableRPC.Add(value);
        }
    }
}
