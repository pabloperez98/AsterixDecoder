using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class PresenceX_Pulse
    {
        public string XA;
        public string XC;
        public string X2;
        //CAT62 only
        public string X5;
        public string X3;
        public string X1;

        public List<string> TablePXP = new List<string>();

        public PresenceX_Pulse()
        {
            this.XA = "N/A";
            this.XC = "N/A";
            this.X2 = "N/A";
            //CAT62 only
            this.X5 = "N/A";
            this.X3 = "N/A";
            this.X1 = "N/A";
        }

        public PresenceX_Pulse(List<string> BinPresenceX_Pulse, string category)
        {
            if (category == "01")
            {
                List<string> defaultXA = new List<string>() { "Default", "X-pulse received in Mode-3/A reply" };
                List<string> defaultXC = new List<string>() { "Default", "X-pulse received in Mode-C reply" };
                List<string> defaultX2 = new List<string>() { "Default", "X-pulse received in Mode-2 reply" };

                this.XA = defaultXA[Convert.ToInt32(BinPresenceX_Pulse[0], 2)];
                this.XC = defaultXC[Convert.ToInt32(BinPresenceX_Pulse[2], 2)];
                this.X2 = defaultX2[Convert.ToInt32(BinPresenceX_Pulse[5], 2)];

                this.TablePXP.Add("XA"); this.TablePXP.Add(this.XA);
                this.TablePXP.Add("XC"); this.TablePXP.Add(this.XC);
                this.TablePXP.Add("X2"); this.TablePXP.Add(this.X2);
            }
            if (category == "62")
            {
                List<string> defaultX5 = new List<string>() { "X-pulse set to zero or no authenticated Data reply or Report received", "X-pulse set to one (present)" };
                List<string> defaultXC = new List<string>() { "X-pulse set to zero or no Mode C reply", "X-pulse set to one (present)" };
                List<string> defaultX3 = new List<string>() { "X-pulse set to zero or no Mode 3/A reply", "X-pulse set to one (present)" };
                List<string> defaultX2 = new List<string>() { "X-pulse set to zero or no Mode 2 reply", "X-pulse set to one (present)" };
                List<string> defaultX1 = new List<string>() { "X-pulse set to zero or no Mode 1 reply", "X-pulse set to one (present)" };

                this.X5 = defaultX5[Convert.ToInt32(BinPresenceX_Pulse[3], 2)];
                this.XC = defaultXC[Convert.ToInt32(BinPresenceX_Pulse[4], 2)];
                this.X3 = defaultX3[Convert.ToInt32(BinPresenceX_Pulse[5], 2)];
                this.X2 = defaultX2[Convert.ToInt32(BinPresenceX_Pulse[6], 2)];
                this.X1 = defaultX1[Convert.ToInt32(BinPresenceX_Pulse[7], 2)];

                this.TablePXP.Add("X5"); this.TablePXP.Add(this.X5);
                this.TablePXP.Add("XC"); this.TablePXP.Add(this.XC);
                this.TablePXP.Add("X3"); this.TablePXP.Add(this.X3);
                this.TablePXP.Add("X2"); this.TablePXP.Add(this.X2);
                this.TablePXP.Add("X1"); this.TablePXP.Add(this.X1);
            }
        }
    }
}
