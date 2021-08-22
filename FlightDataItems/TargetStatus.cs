using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class TargetStatus
    {
        public string ICF;
        public string LNAV;
        public string PS;
        public string SS;

        public List<string> TableTargetStatus = new List<string>();

        public TargetStatus()
        {
            this.ICF = "N/A";
            this.LNAV = "N/A";
            this.PS = "N/A";
            this.SS = "N/A";
        }

        public TargetStatus(List<string> BinaryTargetStatus)
        {
            List<string> defaultICF = new List<string>() { "No intent change active", "Intent change flag raides" };
            List<string> defaultLNAV = new List<string>() { "LNAV Mode engaged", "LNAV Mode not engaged" };
            List<string> defaultPS = new List<string>() { "No emergency/not reported", "General emergency","Lifeguard/medical emergency", "Minimum Fuel", "Unlawful Interference", "Downed Aircraft" };
            List<string> defaultSS = new List<string>() { "No condition reported", "Permanent Alert(emergency condition)", "Temporary ALert(change in Mode 3/a Code other than emergency", "SPI set" };
            
            this.ICF = defaultICF[Convert.ToInt32(BinaryTargetStatus[0], 2)];
            this.LNAV = defaultLNAV[Convert.ToInt32(BinaryTargetStatus[1], 2)];
            this.PS = defaultPS[Convert.ToInt32(string.Join("", BinaryTargetStatus.GetRange(3, 3)), 2)];
            this.SS = defaultSS[Convert.ToInt32(string.Join("", BinaryTargetStatus.GetRange(6, 2)), 2)];
            
            this.TableTargetStatus.Add("ICF"); this.TableTargetStatus.Add(this.ICF);
            this.TableTargetStatus.Add("LNAV"); this.TableTargetStatus.Add(this.LNAV);
            this.TableTargetStatus.Add("PS"); this.TableTargetStatus.Add(this.PS);
            this.TableTargetStatus.Add("SS"); this.TableTargetStatus.Add(this.SS);
        } 
    }
}
