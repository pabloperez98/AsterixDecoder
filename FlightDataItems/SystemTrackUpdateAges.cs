using System.Collections.Generic;

namespace FlightDataItems
{
    public class SystemTrackUpdateAges
    {
        public string TRK; //Track Age Subfield
        public string PSR; //PSR Age Subfield
        public string SSR; //SSR Age Subfield
        public string MDS; //Mode S Age Subfield
        public string ADS; //ADS-C Age Subfield
        public string ES; //ES Age Subfield
        public string VDL; //VDL Age Subfield
        public string UAT; //UAT Age Subfield
        public string LOP; //Loop Age Subfield
        public string MLT; //Multilateration Age Subfield

        public List<string> TableSTUA = new List<string>();

        public SystemTrackUpdateAges()
        {
            this.TRK = "N/A"; //Track Age Subfield
            this.PSR = "N/A"; //PSR Age Subfield
            this.SSR = "N/A"; //SSR Age Subfield
            this.MDS = "N/A"; //Mode S Age Subfield
            this.ADS = "N/A"; //ADS-C Age Subfield
            this.ES = "N/A"; //ES Age Subfield
            this.VDL = "N/A"; //VDL Age Subfield
            this.UAT = "N/A"; //UAT Age Subfield
            this.LOP = "N/A"; //Loop Age Subfield
            this.MLT = "N/A"; //Multilateration Age Subfield
        }

        public void InsertSTUAinfoInTable(string field, string value)
        {
            this.TableSTUA.Add(field);
            this.TableSTUA.Add(value);
        }
    }
}
