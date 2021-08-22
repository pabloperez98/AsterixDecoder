using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class TrackStatusCAT48
    {
        public string CNF;
        public string RAD;
        public string DOU;
        public string MAH;       
        public string CDM;

        public string TRE;
        public string GHO;
        public string SUP;
        public string TCC;

        public List<string> TableTS = new List<string>();

        public TrackStatusCAT48()
        {
            this.CNF = "N/A";
            this.RAD = "N/A";
            this.DOU = "N/A";
            this.MAH = "N/A";
            this.CDM = "N/A";

            this.TRE = "N/A";
            this.GHO = "N/A";
            this.SUP = "N/A";
            this.TCC = "N/A";
        }

        public TrackStatusCAT48(List<string> BinTrackStatus)
        {
            List<string> defaultCNF = new List<string>() { "Confirmed track", "Tentative Track" };
            List<string> defaultRAD = new List<string>() { "Combined Track", "PSR Track", "SSR/Mode S Track", "Invalid" };
            List<string> defaultDOU = new List<string>() { "Normal confidence", "Low confidence in plot to track association" };
            List<string> defaultMAH = new List<string>() { "No horizontal manoeuvre sensed", "Horizontal manoeuvre sensed" }; 
            List<string> defaultCDM = new List<string>() { "Maintaining", "Climbing", "Descending", "Unknown" };
            
            List<string> defaultTRE = new List<string>() { "Track still alive", "End of track lifetime (last report for this track)" };
            List<string> defaultGHO = new List<string>() { "True target track", "Ghost target track" };
            List<string> defaultSUP = new List<string>() { "Track not maintained with track information from neighbouring Node B on the cluster, or network", "Track maintained with track information from neighbouring Node B on the cluster, or network" };
            List<string> defaultTCC = new List<string>() { "Tracking performed in so-called 'Radar Plane', i.e. neither slant range correction nor stereographical projection was applied", "Slant range correction and a suitable projection technique are used to track in a 2D. reference plane, tangential to the earth model at the Radar Site co-ordinates" };

            int nextOctet = 0;
            for (int octets = 0; octets < BinTrackStatus.Count / 8; octets++)
            {
                if (octets == 0)
                {
                    this.CNF = defaultCNF[Convert.ToInt32(BinTrackStatus[0], 2)];
                    this.RAD = defaultRAD[Convert.ToInt32(string.Concat(BinTrackStatus[1], BinTrackStatus[2]), 2)];
                    this.DOU = defaultDOU[Convert.ToInt32(BinTrackStatus[3], 2)];
                    this.MAH = defaultMAH[Convert.ToInt32(BinTrackStatus[4], 2)];
                    this.CDM = defaultCDM[Convert.ToInt32(string.Concat(BinTrackStatus[5], BinTrackStatus[6]), 2)];
                    this.TableTS.Add("CNF"); this.TableTS.Add(this.CNF);
                    this.TableTS.Add("RAD"); this.TableTS.Add(this.RAD);
                    this.TableTS.Add("MAH"); this.TableTS.Add(this.MAH);
                    this.TableTS.Add("DOU"); this.TableTS.Add(this.DOU);
                    this.TableTS.Add("CDM"); this.TableTS.Add(this.CDM);
                    
                }
                if (octets == 1)
                {
                    this.TRE = defaultTRE[Convert.ToInt32(BinTrackStatus[8], 2)];
                    this.GHO = defaultGHO[Convert.ToInt32(BinTrackStatus[9], 2)];
                    this.SUP = defaultSUP[Convert.ToInt32(BinTrackStatus[10], 2)];
                    this.TCC = defaultTCC[Convert.ToInt32(BinTrackStatus[11], 2)];
                    this.TableTS.Add("TRE"); this.TableTS.Add(this.TRE);
                    this.TableTS.Add("GHO"); this.TableTS.Add(this.GHO);
                    this.TableTS.Add("SUP"); this.TableTS.Add(this.SUP);
                    this.TableTS.Add("TCC"); this.TableTS.Add(this.TCC);
                }
                nextOctet += 8;
            }
        }
    }
}
