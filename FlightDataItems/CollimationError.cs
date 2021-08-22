using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDataItems
{
    public class CollimationError
    {
        public string rangeError;
        public string azimuthError;

        public CollimationError(List<string> BinaryDynamicWindow, string category)
        {
            double modAzimuth = 360.0 / Math.Pow(2, 16); //CAT02
            if (category == "34")
            {
                modAzimuth = 360.0 / Math.Pow(2, 14);
            }
            this.rangeError = (binTwosComplementToSignedDecimal(string.Join("", BinaryDynamicWindow.GetRange(0, 8)), 8) * 1 / 128.0).ToString(); // [NM]
            this.azimuthError = (binTwosComplementToSignedDecimal(string.Join("", BinaryDynamicWindow.GetRange(8, 8)), 8) * modAzimuth).ToString(); // [º]
        }

        public CollimationError()
        {
            this.rangeError = "N/A";
            this.azimuthError = "N/A";
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
