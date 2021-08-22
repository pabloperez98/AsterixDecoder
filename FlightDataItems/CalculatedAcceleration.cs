using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class CalculatedAcceleration
    {
        public string Ax;
        public string Ay;

        public CalculatedAcceleration()
        {
            this.Ax = "N/A";
            this.Ay = "N/A";
        }

        public CalculatedAcceleration(List<string> BinCalculatedAcceleration)
        {
            this.Ax = Convert.ToString(binTwosComplementToSignedDecimal(string.Join("", BinCalculatedAcceleration.GetRange(0, BinCalculatedAcceleration.Count / 2)), BinCalculatedAcceleration.Count / 2) * 0.25);
            this.Ay = Convert.ToString(binTwosComplementToSignedDecimal(string.Join("", BinCalculatedAcceleration.GetRange(BinCalculatedAcceleration.Count / 2, BinCalculatedAcceleration.Count / 2)), BinCalculatedAcceleration.Count / 2) * 0.25);
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
