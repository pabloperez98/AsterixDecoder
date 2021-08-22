using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class TrackQuality
    {
        public string sigmaX;
        public string sigmaY;
        public string sigmaV;
        public string sigmaH;

        public TrackQuality()
        {
            this.sigmaX = "N/A";
            this.sigmaY = "N/A";
            this.sigmaV = "N/A";
            this.sigmaH = "N/A";
        }

        public TrackQuality(List<string> BinTrackQuality)
        {
            this.sigmaX = Convert.ToString(Convert.ToInt32(string.Join("", BinTrackQuality.GetRange(0, 8)), 2) * 1 / 128.0); //[NM]
            this.sigmaY = Convert.ToString(Convert.ToInt32(string.Join("", BinTrackQuality.GetRange(8, 8)), 2) * 1 / 128.0); //[NM]
            this.sigmaV = Convert.ToString(Convert.ToInt32(string.Join("", BinTrackQuality.GetRange(16, 8)), 2) * Math.Pow(2, -14)); //[NM/s]
            this.sigmaH = Convert.ToString(Convert.ToInt32(string.Join("", BinTrackQuality.GetRange(24, 8)), 2) * 360 / Math.Pow(2, 12)); //[degree]
        }
    }
}
