using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class SequenceCartesianVectors
    {
        public string REP;
        public string x;
        public string y;
        public string lenght;

        public List<string> TableSQV = new List<string>();

        public SequenceCartesianVectors()
        {
            this.REP = "N/A";
            this.x = "N/A";
            this.y = "N/A";
            this.lenght = "N/A";
        }

        public SequenceCartesianVectors(List<string> BinarySCV)
        {
            this.REP = Convert.ToInt32(string.Join("", BinarySCV.GetRange(0, 8)), 2).ToString();
            for (int i = 0; i < Convert.ToInt32(this.REP); i++)
            {
                this.x = (binTwosComplementToSignedDecimal(string.Join("", BinarySCV.GetRange(8 + 24 * i, 8)), 8) * Math.Pow(2, -6)).ToString(); // [NM]
                this.y = (binTwosComplementToSignedDecimal(string.Join("", BinarySCV.GetRange(16 + 24 * i, 8)), 8) * Math.Pow(2, -6)).ToString(); // [NM]
                this.lenght = (Convert.ToInt32(string.Join("", BinarySCV.GetRange(24 + 24 * i, 8)), 2) * Math.Pow(2, -6)).ToString(); // [NM]
                this.TableSQV.Add(this.x); this.TableSQV.Add(this.y); this.TableSQV.Add(this.lenght);
            }
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
