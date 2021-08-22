using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class ProcessingStatus
    {
        public string f;
        public string R;
        public string Q;

        public ProcessingStatus()
        {
            this.f = "N/A";
            this.R = "N/A";
            this.Q = "N/A";
        }

        public ProcessingStatus(List<string> BinaryProcessingStatus)
        {
            this.f = binTwosComplementToSignedDecimal(string.Join("", BinaryProcessingStatus.GetRange(0, 5)), 5).ToString();
            this.R = Convert.ToInt32(string.Join("", BinaryProcessingStatus.GetRange(5, 3)), 2).ToString();
            this.Q = Convert.ToInt32(string.Join("", BinaryProcessingStatus.GetRange(8, 15)), 2).ToString();
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
