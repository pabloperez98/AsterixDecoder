using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class ModeOfMovement
    {
        public string TRANS;
        public string LONG;
        public string VERT;
        public string ADF;

        public List<string> TableMoM = new List<string>();

        public ModeOfMovement()
        {
            this.TRANS = "N/A";
            this.LONG = "N/A";
            this.VERT = "N/A";
            this.ADF = "N/A";
        }

        public ModeOfMovement(List<string> BInMoM)
        {
            List<string> defaultTRANS = new List<string> { "Constant Course", "Right Turn", "Left Turn", "Undetermined" };
            List<string> defaultLONG = new List<string> { "Constant Groundspeed", "Increasing Groundspeed", "Decreasing Groundspeed", "Undetermined" };
            List<string> defaultVERT = new List<string> { "Level", "Climb", "Descent", "Undetermined" };
            List<string> defaultADF = new List<string> { "No altitude discrepancy", "Altitude discrepancy" };

            this.TRANS = defaultTRANS[Convert.ToInt32(string.Join("", BInMoM.GetRange(0, 2)), 2)];
            this.LONG = defaultLONG[Convert.ToInt32(string.Join("", BInMoM.GetRange(2, 2)), 2)];
            this.VERT = defaultVERT[Convert.ToInt32(string.Join("", BInMoM.GetRange(4, 2)), 2)];
            this.ADF = defaultADF[Convert.ToInt32(string.Join("", BInMoM.GetRange(6, 1)), 2)];

            TableMoM.Add("TRANS"); TableMoM.Add(this.TRANS);
            TableMoM.Add("LONG"); TableMoM.Add(this.LONG);
            TableMoM.Add("VERT"); TableMoM.Add(this.VERT);
            TableMoM.Add("ADF"); TableMoM.Add(this.ADF);
        }
    }
}
