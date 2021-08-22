using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class StandardDeviationPosition
    {
        public string x;
        public string y;
        public string xy;

        public StandardDeviationPosition()
        {
            this.x = "N/A";
            this.y = "N/A";
            this.xy = "N/A";
        }

        public StandardDeviationPosition(List<string> BinSDoP)
        {
            double mod = 0.25;
            this.x = Convert.ToString(Convert.ToInt32(string.Join("", BinSDoP.GetRange(0, 8)), 2) * mod);
            this.y = Convert.ToString(Convert.ToInt32(string.Join("", BinSDoP.GetRange(8, 8)), 2) * mod);
            this.xy = Convert.ToString(binTwosComplementToSignedDecimal(string.Join("", BinSDoP.GetRange(16, 16)), 16) * mod);
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
