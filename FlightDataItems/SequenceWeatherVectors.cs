using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class SequenceWeatherVectors
    {
        public string REP;
        public string x1;
        public string y1;
        public string x2;
        public string y2;

        public List<string> TableSWV = new List<string>();

        public SequenceWeatherVectors()
        {
            this.REP = "N/A";
            this.x1 = "N/A";
            this.y1 = "N/A";
            this.x2 = "N/A";
            this.y2 = "N/A";
        }

        public SequenceWeatherVectors(List<string> BinarySWV)
        {
            this.REP = Convert.ToInt32(string.Join("", BinarySWV.GetRange(0, 8)), 2).ToString();
            for (int i = 0; i < Convert.ToInt32(this.REP); i++)
            {
                this.x1 = (binTwosComplementToSignedDecimal(string.Join("", BinarySWV.GetRange(8 + 32 * i, 8)), 8) * Math.Pow(2, -6)).ToString(); // [NM]
                this.y1 = (binTwosComplementToSignedDecimal(string.Join("", BinarySWV.GetRange(16 + 32 * i, 8)), 8) * Math.Pow(2, -6)).ToString(); // [NM]
                this.x2 = (binTwosComplementToSignedDecimal(string.Join("", BinarySWV.GetRange(24 + 32 * i, 8)), 8) * Math.Pow(2, -6)).ToString(); // [NM]
                this.y2 = (binTwosComplementToSignedDecimal(string.Join("", BinarySWV.GetRange(32 + 32 * i, 8)), 8) * Math.Pow(2, -6)).ToString(); // [NM]
                this.TableSWV.Add(this.x1); this.TableSWV.Add(this.y1); this.TableSWV.Add(this.x2); this.TableSWV.Add(this.y2);
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
