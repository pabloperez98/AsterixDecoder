using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class Mode3A
    {
        public string V;
        public string G;
        public string L;
        public string CH; // CAT62
        public string Reply;

        public List<string> TableM3A = new List<string>();
        
        public Mode3A()
        {
            this.V = "N/A";
            this.G = "N/A";
            this.L = "N/A";
            this.CH = "N/A";
            this.Reply = "N/A";
        }

        public Mode3A(List<string> BinMode3A, string category)
        {
            List<string> defaultV = new List<string>() { "Code validated", "Code not validated" };
            List<string> defaultG = new List<string>() { "Default", "Garbled code" };
            List<string> defaultL = new List<string>() { "Mode-3/A code derived from the reply of the transponder", "Mode-3/A code not extracted during the last scan" };
            List<string> defaultCH = new List<string>() { "No Change", "Mode 3/A has changed" };

            this.V = defaultV[Convert.ToInt32(BinMode3A[0], 2)];
            this.G = defaultG[Convert.ToInt32(BinMode3A[1], 2)];
            if (category == "62")
                this.CH = defaultCH[Convert.ToInt32(BinMode3A[2], 2)];
            else
                this.L = defaultL[Convert.ToInt32(BinMode3A[2], 2)];
            this.Reply = Convert.ToString(Convert.ToInt32(string.Join("", BinMode3A.GetRange(4, 12)), 2), 8).PadLeft(4, '0');
            
            this.TableM3A.Add("V"); this.TableM3A.Add(this.V);
            this.TableM3A.Add("G"); this.TableM3A.Add(this.G);
            if (category == "62")
            { this.TableM3A.Add("CH"); this.TableM3A.Add(this.CH); }
            else
            { this.TableM3A.Add("L"); this.TableM3A.Add(this.L); }
        }
    }
}
