using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class TrackVelocityCartesianCoordinates
    {
        public double Vx;
        public double Vy;

        public TrackVelocityCartesianCoordinates()
        {
            this.Vx = 0;
            this.Vy = 0;
        }

        public TrackVelocityCartesianCoordinates(List<string> BinTrackVelocityCartesian)
        {
            double mod = 0.25;
            this.Vx = binTwosComplementToSignedDecimal(string.Join("", BinTrackVelocityCartesian.GetRange(0, BinTrackVelocityCartesian.Count / 2)), BinTrackVelocityCartesian.Count / 2) * mod;
            this.Vy = binTwosComplementToSignedDecimal(string.Join("", BinTrackVelocityCartesian.GetRange(BinTrackVelocityCartesian.Count / 2, BinTrackVelocityCartesian.Count / 2)), BinTrackVelocityCartesian.Count / 2) * mod;
        }

        private static double binTwosComplementToSignedDecimal(string Binary, int significantBits)
        {
            double power = Math.Pow(2, significantBits - 1);
            double sum = 0;
            int i;
            char[] binary = Binary.ToCharArray();
            for (i = 0; i < significantBits; ++i)
            {
                if (i == 0 && binary[i] != '0')
                    sum = power * -1;
                else
                    sum += (binary[i] - '0') * power;
                power /= 2;
            }
            return sum;
        }
    }
}
