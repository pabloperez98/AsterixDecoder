using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class SelectedAltitude
    {
        public string SAS;
        public string Source;
        public string Altitude;

        public List<string> TableSA = new List<string>();

        public SelectedAltitude()
        {
            this.SAS = "N/A";
            this.Source = "N/A";
            this.Altitude = "N/A";
        }

        public SelectedAltitude(List<string> BinarySelectedAltitude)
        {
            List<string> defaultSAS = new List<string>() { "No source information", "Source Information Provider" };
            List<string> defaultSource = new List<string>() { "Unknown", "Aircraft Altitude", "FCU/MSP Selected Altitude", "FMS Selected Altitude" };
            this.SAS = defaultSAS[Convert.ToInt32(BinarySelectedAltitude[0], 2)];
            this.Source = defaultSource[Convert.ToInt32(string.Join("", BinarySelectedAltitude.GetRange(1,2)), 2)];
            this.Altitude = Convert.ToString(binTwosComplementToSignedDecimal(string.Join("", BinarySelectedAltitude.GetRange(3, 13)), 13) * 25); // [ft]
            this.TableSA.Add("SAS"); this.TableSA.Add(this.SAS);
            this.TableSA.Add("Source"); this.TableSA.Add(this.Source);
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