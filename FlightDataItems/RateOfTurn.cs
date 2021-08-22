using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class RateOfTurn
    {
        public string turnIndicator;
        public string rateOfTurn;

        public RateOfTurn()
        {
            this.turnIndicator = "N/A";
            this.rateOfTurn = "N/A";
        }

        public RateOfTurn(List<string> BinaryRateOfTurn)
        {
            List<string> defaultTurnIndicator = new List<string>() {"Not available", "Left", "Right", "Straight"};
            this.turnIndicator = defaultTurnIndicator[Convert.ToInt32(string.Join("", BinaryRateOfTurn.GetRange(0, 2)), 2)];
            if (BinaryRateOfTurn.Count == 16)
                this.rateOfTurn = (binTwosComplementToSignedDecimal(string.Join("", BinaryRateOfTurn.GetRange(8, 7)), 7) / 4.0).ToString();
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
