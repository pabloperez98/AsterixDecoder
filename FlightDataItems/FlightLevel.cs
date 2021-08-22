using System;
using System.Collections.Generic;


namespace FlightDataItems
{
    public class FlightLevel
    {
        public string V;
        public string G;
        public string FL;
        public double altitude;

        public List<string> TableFL = new List<string>();
        public FlightLevel()
        {
            this.V = "N/A";
            this.G = "N/A";
            this.FL = "N/A";
            this.altitude = 0;
        }
        public FlightLevel(List<string> BinaryFL)
        {
            List<string> defaultV = new List<string>() { "Code validated", "Code not validated" };
            List<string> defaultG = new List<string>() { "Default", "Garbled code" };
            this.V = defaultV[Convert.ToInt32(BinaryFL[0], 2)];
            this.G = defaultG[Convert.ToInt32(BinaryFL[1], 2)];
            this.TableFL.Add("V"); this.TableFL.Add(this.V);
            this.TableFL.Add("G"); this.TableFL.Add(this.G);
            this.FL = (binTwosComplementToSignedDecimal(string.Join("", BinaryFL.GetRange(2, 14)), 14)/4.0).ToString();
            this.altitude = (binTwosComplementToSignedDecimal(string.Join("", BinaryFL.GetRange(2, 14)), 14) / 4.0) * 30.48; //m
            if (this.altitude < 0)
                this.altitude = 0;
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
