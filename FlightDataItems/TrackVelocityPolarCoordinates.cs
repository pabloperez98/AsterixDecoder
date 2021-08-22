using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class TrackVelocityPolarCoordinates
    {
        public double groundSpeed;
        public double trackAngle;
        public TrackVelocityPolarCoordinates()
        {
            this.groundSpeed = 0;
            this.trackAngle = 0;
        }
        public TrackVelocityPolarCoordinates(List<string> BinTrackVelocityPolar)
        {
            double groundSpeedMod = Math.Pow(2, -14) * 3600;
            double trackAngleMod = 360 / Math.Pow(2, 16);
            this.groundSpeed = Convert.ToInt32(string.Join("", BinTrackVelocityPolar.GetRange(0, 16)), 2) * groundSpeedMod; // [kt]
            this.trackAngle = Convert.ToInt32(string.Join("", BinTrackVelocityPolar.GetRange(16, 16)), 2) * trackAngleMod; // [º]
        }    
    }
}
