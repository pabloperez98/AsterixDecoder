using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightDataItems
{
    public class TrackStatusCAT10
    {
        public string CNF;
        public string TRE;
        public string CST;
        public string MAH;
        public string TCC;
        public string STH;

        public string TOM;
        public string DOU;
        public string MRS;

        public string GHO;

        public List<string> TableTS = new List<string>();

        public TrackStatusCAT10(List<string> BinTrackStatus)
        {
            List<string> defaultCNF = new List<string>() { "Confirmed track", "Track in initialisation phase" };
            List<string> defaultTRE = new List<string>() { "Default", "Last report for a track" };
            List<string> defaultCST = new List<string>() { "No extrapolation", "Predictable extrapolation due to sensor refresh period", "Predictable extrapolation in masked area", "Extrapolation due to unpredictable absence of detection" };
            List<string> defaultMAH = new List<string>() { "Default", "Horizontal manoeuvre" };
            List<string> defaultTCC = new List<string>() { "Tracking performed in 'Sensor Plane', i.e. neither slant range correction nor projection was applied", "Slant range correction and a suitable projection technique are used to track in a 2D reference plane, tangential to the earth model at the Sensor Site co-ordinates" };
            List<string> defaultSTH = new List<string>() { "Measured position", "Smoothed position" };

            List<string> defaultTOM = new List<string>() { "Unknown type of movement", "Taking-off", "Landing", "Other types of movement" };
            List<string> defaultDOU = new List<string>() { "No doubt", "Doubtful correlation (undetermined reason)", "Doubtful correlation in clutter", "Loss of accuracy", "Loss of accuracy in clutter", "Unstable track", "Previously coasted" };
            List<string> defaultMRS = new List<string>() { "Merge or split indication undetermined", "Track merged by association to plot", "Track merged by non-association to plot", "Split track" };

            List<string> defaultGHO = new List<string>() { "Default", "Ghost track" };

            int nextOctet = 0;
            for (int octets = 0; octets < BinTrackStatus.Count() / 8; octets++)
            {
                if (octets == 0)
                {
                    this.CNF = defaultCNF[Convert.ToInt32(BinTrackStatus[0], 2)];
                    this.TRE = defaultTRE[Convert.ToInt32(BinTrackStatus[1], 2)];
                    this.CST = defaultCST[Convert.ToInt32(string.Concat(BinTrackStatus[2], BinTrackStatus[3]), 2)];
                    this.MAH = defaultMAH[Convert.ToInt32(BinTrackStatus[4], 2)];
                    this.TCC = defaultTCC[Convert.ToInt32(BinTrackStatus[5], 2)];
                    this.STH = defaultSTH[Convert.ToInt32(BinTrackStatus[6], 2)];
                    this.TableTS.Add("CNF"); this.TableTS.Add(this.CNF);
                    this.TableTS.Add("TRE"); this.TableTS.Add(this.TRE);
                    this.TableTS.Add("CST"); this.TableTS.Add(this.CST);
                    this.TableTS.Add("MAH"); this.TableTS.Add(this.MAH);
                    this.TableTS.Add("TCC"); this.TableTS.Add(this.TCC);
                    this.TableTS.Add("STH"); this.TableTS.Add(this.STH);
                }
                if (octets == 1)
                {
                    this.TOM = defaultTOM[Convert.ToInt32(string.Concat(BinTrackStatus[8], BinTrackStatus[9]), 2)];
                    this.DOU = defaultDOU[Convert.ToInt32(string.Concat(BinTrackStatus[10], BinTrackStatus[11], BinTrackStatus[12]), 2)];
                    this.MRS = defaultMRS[Convert.ToInt32(string.Concat(BinTrackStatus[13], BinTrackStatus[14]), 2)];
                    this.TableTS.Add("TOM"); this.TableTS.Add(this.TOM);
                    this.TableTS.Add("DOU"); this.TableTS.Add(this.DOU);
                    this.TableTS.Add("MRS"); this.TableTS.Add(this.MRS);
                }
                if (octets == 2)
                {
                    this.GHO = defaultGHO[Convert.ToInt32(BinTrackStatus[16], 2)];
                    this.TableTS.Add("GHO"); this.TableTS.Add(this.GHO);
                }
                nextOctet += 8;
            }
        }
        public TrackStatusCAT10()
        {
            this.CNF = "N/A";
            this.TRE = "N/A";
            this.CST = "N/A";
            this.MAH = "N/A";
            this.TCC = "N/A";
            this.STH = "N/A";

            this.TOM = "N/A";
            this.DOU = "N/A";
            this.MRS = "N/A";

            this.GHO = "N/A";
        }
    }
}
