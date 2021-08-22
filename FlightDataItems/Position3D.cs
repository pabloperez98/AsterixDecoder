using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class Position3D
    {
        public string height;
        public string latitude;
        public string longitude;

        public Position3D()
        {
            this.height = "N/A";
            this.latitude = "N/A";
            this.longitude = "N/A";
        }

        public Position3D(List<string> BinaryPosition3D)
        {
            this.height = Convert.ToInt32(string.Join("", BinaryPosition3D.GetRange(0, 16)), 2).ToString(); // [m]
            this.latitude = (binTwosComplementToSignedDecimal(string.Join("", BinaryPosition3D.GetRange(16, 24)), 24) * 180 / Math.Pow(2, 23)).ToString(); // [º]
            this.longitude = (binTwosComplementToSignedDecimal(string.Join("", BinaryPosition3D.GetRange(40, 24)), 24) * 180 / Math.Pow(2, 23)).ToString(); // [º]
        }

        // Convierte de binario a decimal haciendo el complemento a 2
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
