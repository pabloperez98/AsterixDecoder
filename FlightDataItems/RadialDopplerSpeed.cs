using System.Collections.Generic;

namespace FlightDataItems
{
    public class RadialDopplerSpeed
    {
        //CAL Subfield
        public string D;
        public string CAL;
        //RDS Subfield
        public string REP;
        public string DOP;
        public string AMB;
        public string FRQ;

        public List<string> TableSCS = new List<string>();

        public RadialDopplerSpeed()
        {
            //CAL Subfield
            this.D = "N/A";
            this.CAL = "N/A";
            //RDS Subfield
            this.REP = "N/A";
            this.DOP = "N/A";
            this.AMB = "N/A";
            this.FRQ = "N/A";
        }

        public void InsertRDSinfoInTable(string field, string value)
        {
            this.TableSCS.Add(field);
            this.TableSCS.Add(value);
        }
    }
}
