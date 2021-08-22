using System.Collections.Generic;

namespace FlightDataItems
{
    public class TrackDataAges
    {
        public string MFL; //Measured Flight Level Age Subfield
        public string MD1; //Mode 1 Age Subfield
        public string MD2; //Mode 2 Age Subfield
        public string MDA; //Mode 3/A Age Subfield
        public string MD4; //Mode 4 Age Subfield
        public string MD5; //Mode 5 Age Subfield
        public string MHG; //Magnetic Heading Age Subfield
        public string IAS; //Indicated Airspeed/Mach Number Age Subfield
        public string TAS; //True Airspeed Age Subfield
        public string SAL; //Selected Altitude Age Subfield
        public string FSS; //Final State Selected Altitude Age Subfield
        public string TID; //Trajectory Intent Age Subfield
        public string COM; //Communication/ACAS Capability and Flight Status Age Subfield
        public string SAB; //Status Reported by ADS-B Age Subfield
        public string ACS; //ACAS Resolution Advisory Report Age Subfield
        public string BVR; //Barometric Vertical Rate Age Subfield
        public string GVR; //Geometrical Vertical Rate Age Subfield
        public string RAN; //Roll Angle Age Subfield
        public string TAR; //Track Angle Rate Age Subfield
        public string TAN; //Track Angle Age Subfield
        public string GSP; //Ground Speed Age Subfield
        public string VUN; //Velocity Uncertainty Age Subfield
        public string MET; //Meteorological Data Age Subfield
        public string EMC; //Emitter Category Age Subfield
        public string POS; //Position Age Subfield
        public string GAL; //Geometric Altitude Age Subfield
        public string PUN; //Position Uncertainty Age Subfield
        public string MB; //Mode S MB Data Age Subfield
        public string IAR; //Indicated Airspeed Data Age Subfield
        public string MAC; //Mach Number Data Age Subfield
        public string BPS; //Barometric Pressure Setting Age Subfield

        public List<string> TableTDA = new List<string>();

        public TrackDataAges()
        {
            this.MFL = "N/A"; //Measured Flight Level Age Subfield
            this.MD1 = "N/A"; //Mode 1 Age Subfield
            this.MD2 = "N/A"; //Mode 2 Age Subfield
            this.MDA = "N/A"; //Mode 3/A Age Subfield
            this.MD4 = "N/A"; //Mode 4 Age Subfield
            this.MD5 = "N/A"; //Mode 5 Age Subfield
            this.MHG = "N/A"; //Magnetic Heading Age Subfield
            this.IAS = "N/A"; //Indicated Airspeed/Mach Number Age Subfield
            this.TAS = "N/A"; //True Airspeed Age Subfield
            this.SAL = "N/A"; //Selected Altitude Age Subfield
            this.FSS = "N/A"; //Final State Selected Altitude Age Subfield
            this.TID = "N/A"; //Trajectory Intent Age Subfield
            this.COM = "N/A"; //Communication/ACAS Capability and Flight Status Age Subfield
            this.SAB = "N/A"; //Status Reported by ADS-B Age Subfield
            this.ACS = "N/A"; //ACAS Resolution Advisory Report Age Subfield
            this.BVR = "N/A"; //Barometric Vertical Rate Age Subfield
            this.GVR = "N/A"; //Geometrical Vertical Rate Age Subfield
            this.RAN = "N/A"; //Roll Angle Age Subfield
            this.TAR = "N/A"; //Track Angle Rate Age Subfield
            this.TAN = "N/A"; //Track Angle Age Subfield
            this.GSP = "N/A"; //Ground Speed Age Subfield
            this.VUN = "N/A"; //Velocity Uncertainty Age Subfield
            this.MET = "N/A"; //Meteorological Data Age Subfield
            this.EMC = "N/A"; //Emitter Category Age Subfield
            this.POS = "N/A"; //Position Age Subfield
            this.GAL = "N/A"; //Geometric Altitude Age Subfield
            this.PUN = "N/A"; //Position Uncertainty Age Subfield
            this.MB = "N/A"; //Mode S MB Data Age Subfield
            this.IAR = "N/A"; //Indicated Airspeed Data Age Subfield
            this.MAC = "N/A"; //Mach Number Data Age Subfield
            this.BPS = "N/A"; //Barometric Pressure Setting Age Subfield
        }

        public void InsertTDAinfoInTable(string field, string value)
        {
            this.TableTDA.Add(field);
            this.TableTDA.Add(value);
        }
    }
}
