using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class PositionCartesianCoordinates
    {
        public double x;
        public double y;

        public PositionCartesianCoordinates()
        {
            this.x = 0;
            this.y = 0;
        }

        public PositionCartesianCoordinates(List<string> BinPositionCartesian, string category)
        {
            double positionMod = 1 / 1852.0; // CAT10 [m -> NM]
            if (category == "48")
                positionMod = 1 / 128.0;
            if (category == "62")
                positionMod = 0.5 / 1852.0; // [m -> NM]
            this.x = binTwosComplementToSignedDecimal(string.Join("", BinPositionCartesian.GetRange(0, BinPositionCartesian.Count / 2)), BinPositionCartesian.Count / 2) * positionMod; // [NM]
            this.y = binTwosComplementToSignedDecimal(string.Join("", BinPositionCartesian.GetRange(BinPositionCartesian.Count / 2, BinPositionCartesian.Count / 2)), BinPositionCartesian.Count / 2) * positionMod; // [NM]
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
                    sum += (binary[i] - '0') * power;//The -0 is needed
                power /= 2;
            }
            return sum;
        }
    }
}
