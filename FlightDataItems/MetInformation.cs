using System.Collections.Generic;

namespace FlightDataItems
{
    public class MetInformation
    {
        public string WS;
        public string WD;
        public string TMP;
        public string TRB;

        public List<string> TableMI = new List<string>();

        public MetInformation()
        {
            this.WS = "N/A";
            this.WD = "N/A";
            this.TMP = "N/A";
            this.TRB = "N/A";
        }

        public void InsertMetInfoInTable(string field, string value)
        {
            this.TableMI.Add(field);
            this.TableMI.Add(value);
        }
    }
}
