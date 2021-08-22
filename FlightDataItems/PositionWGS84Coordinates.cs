using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class PositionWGS84Coordinates
    {
        public double latitude;
        public double longitude;

        public PositionWGS84Coordinates()
        {
            this.latitude = 0;
            this.longitude = 0;
        }

        public PositionWGS84Coordinates(List<string> BinWGS84Coordinates, string category)
        {
            double mod = 180 / Math.Pow(2, 31); //CAT10
            if (category == "21" && BinWGS84Coordinates.Count == 8*6)
                mod = 180 / Math.Pow(2, 23);
            if (category == "21" && BinWGS84Coordinates.Count == 8*8)
                mod = 180 / Math.Pow(2, 30);
            if (category == "62")
                mod = 180 / Math.Pow(2, 25);
            this.latitude = binTwosComplementToSignedDecimal(string.Join("", BinWGS84Coordinates.GetRange(0, BinWGS84Coordinates.Count / 2)), BinWGS84Coordinates.Count / 2) * mod;
            this.longitude = binTwosComplementToSignedDecimal(string.Join("", BinWGS84Coordinates.GetRange(BinWGS84Coordinates.Count / 2, BinWGS84Coordinates.Count / 2)), BinWGS84Coordinates.Count / 2) * mod‬;
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
