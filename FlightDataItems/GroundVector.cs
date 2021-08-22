using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class GroundVector
    {
        public double GroundSpeed;
        public double TrackAngle;
        
        public GroundVector()
        {
            this.GroundSpeed = 0;
            this.TrackAngle = 0;
        }

        public GroundVector(List<string> BinaryGroundVector, string FRN)
        {
            double modGS = Math.Pow(2, -14) * 3600; // [kt]
            double modTA = 360 / Math.Pow(2, 16);
            if (FRN =="16") //CAT 21 v023
                this.GroundSpeed = binTwosComplementToSignedDecimal(string.Join("", BinaryGroundVector.GetRange(0,16)), 16) * modGS;
            if (FRN == "26") //CAT 21 v2.1
                this.GroundSpeed = Convert.ToInt32(string.Join("", BinaryGroundVector.GetRange(1, 15)), 2) * modGS;
            this.TrackAngle = Convert.ToInt32(string.Join("", BinaryGroundVector.GetRange(16, 16)), 2) * modTA;
        }

        public static double binTwosComplementToSignedDecimal(string binary, int significantBits)
        {
            double power = Math.Pow(2, significantBits - 1);
            double sum = 0;
            int i;
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
