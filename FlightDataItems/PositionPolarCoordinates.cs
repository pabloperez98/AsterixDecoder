using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class PositionPolarCoordinates
    {
        public double rho;
        public double theta;

        public PositionPolarCoordinates()
        {
            this.rho = 0;
            this.theta = 0;
        }

        public PositionPolarCoordinates(List<string> BinMeasuredPositionPolar, string category)
        {
            double ThetaMod = 360 / Math.Pow(2, 16);
            double RhoMod = 1 / 1852.0; //CAT10 [m -> NM]
            if (category == "01")
                RhoMod = 1 / 128.0;
            if (category == "48" || category == "62")
                RhoMod = 1 / 256.0;
            this.rho = Convert.ToInt32(string.Join("", BinMeasuredPositionPolar.GetRange(0, BinMeasuredPositionPolar.Count / 2)), 2) * RhoMod; // [NM]
            this.theta = Convert.ToInt32(string.Join("", BinMeasuredPositionPolar.GetRange(BinMeasuredPositionPolar.Count / 2, BinMeasuredPositionPolar.Count / 2)), 2) * ThetaMod;  // [º]
        }
    }
}