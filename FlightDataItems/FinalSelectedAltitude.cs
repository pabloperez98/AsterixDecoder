using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class FinalSelectedAltitude
    {
        public string MV;
        public string AH;
        public string AM;
        public string Altitude;

        public List<string> TableFSA = new List<string>();

        public FinalSelectedAltitude()
        {
            this.MV = "N/A";
            this.AH = "N/A";
            this.AM = "N/A";
            this.Altitude = "N/A";
        }

        public FinalSelectedAltitude(List<string> BinaryFinalSelectedAltitude)
        {
            List<string> defaultMV = new List<string>() { "Not Active", "Active" };
            List<string> defaultAH = new List<string>() { "Not active", "Active" };
            List<string> defaultAM = new List<string>() { "Not active", "Active" };
            this.MV = defaultMV[Convert.ToInt32(BinaryFinalSelectedAltitude[0], 2)];
            this.AH = defaultAH[Convert.ToInt32(BinaryFinalSelectedAltitude[1], 2)];
            this.AM = defaultAM[Convert.ToInt32(BinaryFinalSelectedAltitude[2], 2)];
            this.Altitude = Convert.ToString(binTwosComplementToSignedDecimal(string.Join("", BinaryFinalSelectedAltitude.GetRange(3, 13)), 13) * 25); // [ft]

            this.TableFSA.Add("MV"); this.TableFSA.Add(this.MV);
            this.TableFSA.Add("AH"); this.TableFSA.Add(this.AH);
            this.TableFSA.Add("AM"); this.TableFSA.Add(this.AM);

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
