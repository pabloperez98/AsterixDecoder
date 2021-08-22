using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class SequenceContourPoints
    {
        public string REP;
        public string x;
        public string y;

        public List<string> TableSCP = new List<string>();

        public SequenceContourPoints()
        {
            this.REP = "N/A";
            this.x = "N/A";
            this.y = "N/A";
        }

        public SequenceContourPoints(List<string> BinarySCP)
        {
            this.REP = Convert.ToInt32(string.Join("", BinarySCP.GetRange(0, 8)), 2).ToString();
            for (int i = 0; i < Convert.ToInt32(this.REP); i++)
            {
                this.x = (binTwosComplementToSignedDecimal(string.Join("", BinarySCP.GetRange(8 + 16 * i, 8)), 8) * Math.Pow(2, -6)).ToString(); // [NM]
                this.y = (binTwosComplementToSignedDecimal(string.Join("", BinarySCP.GetRange(16 + 16 * i, 8)), 8) * Math.Pow(2, -6)).ToString(); // [NM]
                this.TableSCP.Add(this.x); this.TableSCP.Add(this.y);
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
