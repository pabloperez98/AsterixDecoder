using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class Mode1
    {
        public string V;
        public string G;
        public string L;
        public string Reply;

        public List<string> TableM1 = new List<string>();
        public Mode1()
        {
            this.V = "N/A";
            this.G = "N/A";
            this.L = "N/A";
            this.Reply = "N/A";
        }
        public Mode1(List<string> BinMode1)
        {
            List<string> defaultV = new List<string>() { "Code validated", "Code not validated" };
            List<string> defaultG = new List<string>() { "Default", "Garbled code" };
            List<string> defaultL = new List<string>() { "Mode-1 code as derived from the reply of the transponder", "Smoothed Mode-1 code as provided by a local tracker" };

            this.V = defaultV[Convert.ToInt32(BinMode1[0], 2)];
            this.G = defaultG[Convert.ToInt32(BinMode1[1], 2)];
            this.L = defaultL[Convert.ToInt32(BinMode1[2], 2)];
            this.Reply = Convert.ToString(Convert.ToInt32(string.Join("", BinMode1.GetRange(3, 5)), 2), 8);

            this.TableM1.Add("V"); this.TableM1.Add(this.V);
            this.TableM1.Add("G"); this.TableM1.Add(this.G);
            this.TableM1.Add("L"); this.TableM1.Add(this.L);
        }
    }
}
