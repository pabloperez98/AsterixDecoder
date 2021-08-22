using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class Mode2
    {
        public string V;
        public string G;
        public string L;
        public string Reply;

        public List<string> TableM2 = new List<string>();
        public Mode2()
        {
            this.V = "N/A";
            this.G = "N/A";
            this.L = "N/A";
            this.Reply = "N/A";
        }
        public Mode2(List<string> BinMode2)
        {
            List<string> defaultV = new List<string>() { "Code validated", "Code not validated" };
            List<string> defaultG = new List<string>() { "Default", "Garbled code" };
            List<string> defaultL = new List<string>() { "Mode-2 code as derived from the reply of the transponder", "Smoothed Mode-2 code as provided by a local tracker" };

            this.V = defaultV[Convert.ToInt32(BinMode2[0], 2)];
            this.G = defaultG[Convert.ToInt32(BinMode2[1], 2)];
            this.L = defaultL[Convert.ToInt32(BinMode2[2], 2)];
            this.Reply = Convert.ToString(Convert.ToInt32(string.Join("", BinMode2.GetRange(4, 12)), 2), 8);

            this.TableM2.Add("V"); this.TableM2.Add(this.V);
            this.TableM2.Add("G"); this.TableM2.Add(this.G);
            this.TableM2.Add("L"); this.TableM2.Add(this.L);
        }
    }
}
