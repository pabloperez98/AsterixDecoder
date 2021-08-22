using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class Mode5Summary
    {
        public string M5;
        public string ID;
        public string DA;
        public string M1;
        public string M2;
        public string M3;
        public string MC;
        public string X;

        public List<string> TableM5S = new List<string>();

        public Mode5Summary()
        {
            this.M5 = "N/A";
            this.ID = "N/A";
            this.DA = "N/A";
            this.M1 = "N/A";
            this.M2 = "N/A";
            this.M3 = "N/A";
            this.MC = "N/A";
            this.X = "N/A";
        }

        public Mode5Summary(List<string> BinM5S)
        {
            List<string> defaultM5 = new List<string>() { "No Mode 5 interrogation", "Mode 5 interrogation" };
            List<string> defaultID = new List<string>() { "No authenticated Mode 5 ID reply", "Authenticated Mode 5 ID reply" };
            List<string> defaultDA = new List<string>() { "No authenticated Mode 5 Data reply or Report", "Authenticated Mode 5 Data reply or Report (i.e any valid Mode 5 reply type other than ID)" };
            List<string> defaultM1 = new List<string>() { "Mode 1 code not present or not from Mode 5 reply", "Mode 1 code from Mode 5 reply" };
            List<string> defaultM2 = new List<string>() { "Mode 2 code not present or not from Mode 5 reply", "Mode 2 code from Mode 5 reply" };
            List<string> defaultM3 = new List<string>() { "Mode 3 code not present or not from Mode 5 reply", "Mode 3 code from Mode 5 reply" };
            List<string> defaultMC = new List<string>() { "Mode C altitude not present or not from Mode 5 reply", "Mode C altitude from Mode 5 reply" };
            List<string> defaultX = new List<string>() { "X-pulse set to zero or no authenticated Data reply or Report received", "X-pulse set to one" };

            this.M5 = defaultM5[Convert.ToInt32(BinM5S[0], 2)];
            this.ID = defaultID[Convert.ToInt32(BinM5S[1], 2)];
            this.DA = defaultDA[Convert.ToInt32(BinM5S[2], 2)];
            this.M1 = defaultM1[Convert.ToInt32(BinM5S[3], 2)];
            this.M2 = defaultM2[Convert.ToInt32(BinM5S[4], 2)];
            this.M3 = defaultM3[Convert.ToInt32(BinM5S[5], 2)];
            this.MC = defaultMC[Convert.ToInt32(BinM5S[6], 2)];
            this.X = defaultX[Convert.ToInt32(BinM5S[7], 2)];

            this.TableM5S.Add("M5"); this.TableM5S.Add(this.M5);
            this.TableM5S.Add("ID"); this.TableM5S.Add(this.ID);
            this.TableM5S.Add("DA"); this.TableM5S.Add(this.DA);
            this.TableM5S.Add("M1"); this.TableM5S.Add(this.M1);
            this.TableM5S.Add("M2"); this.TableM5S.Add(this.M2);
            this.TableM5S.Add("M3"); this.TableM5S.Add(this.M3);
            this.TableM5S.Add("MC"); this.TableM5S.Add(this.MC);
            this.TableM5S.Add("X"); this.TableM5S.Add(this.X);
        }
    }
}
