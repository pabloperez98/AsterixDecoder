using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class TargetReportDescriptorCAT48
    {
        public string TYP;
        public string SIM;
        public string RDP;
        public string SPI;
        public string RAB;

        public string TST;
        public string ERR;
        public string XPP;
        public string ME;
        public string MI;
        public string FOE;

        public List<string> TableTRD = new List<string>();

        public TargetReportDescriptorCAT48()
        {
            this.TYP = "N/A";
            this.SIM = "N/A";
            this.RDP = "N/A";
            this.SPI = "N/A";
            this.RAB = "N/A";

            this.TST = "N/A";
            this.ERR = "N/A";
            this.XPP = "N/A";
            this.ME = "N/A";
            this.MI = "N/A";
            this.FOE = "N/A";
        }

        public TargetReportDescriptorCAT48(List<string> BinaryTRD)
        {
            List<string> defaultTYP = new List<string>() { "No detection", "Single PSR detection", "Single SSR detection", "SSR + PSR detection", "Single ModeS All-Call", "Single ModeS Roll-Call", "ModeS All-Call + PSR", "ModeS Roll-Call + PSR" };
            List<string> defaultSIM = new List<string>() { "Actual target report", "Simulated target report" };
            List<string> defaultRDP = new List<string>() { "Report from RDP Chain 1", "Report from RDP Chain 2" };
            List<string> defaultSPI = new List<string>() { "Abstence of SPI", "Special Position Identification" };
            List<string> defaultRAB = new List<string>() { "Report from target transponder", "Report from field monitor (fixed tranponder)" };

            List<string> defaultTST = new List<string>() { "Real target report", "Test target report" };
            List<string> defaultERR = new List<string>() { "No Extended Range", "Extended Range present" };
            List<string> defaultXPP = new List<string>() { "No X-Pulse present", "X-Pulse present" };
            List<string> defaultME = new List<string>() { "No military emergency", "Military emergency" };
            List<string> defaultMI = new List<string>() { "No military identification", "Military identification" };
            List<string> defaultFOE = new List<string>() { "No Mode 4 interrogation", "Friendly target", "Unknown target", "No reply" };

            int nextOctet = 0;
            for (int octets = 0; octets < BinaryTRD.Count / 8; octets++)
            {
                List<string> infoOctet = new List<string>();
                for (int bit = 0; bit < 7; bit++)
                    infoOctet.Add(BinaryTRD[bit + nextOctet]);
                if (octets == 0)
                {
                    this.TYP = defaultTYP[Convert.ToInt32(string.Join("", infoOctet.GetRange(0, 3)), 2)];
                    this.SIM = defaultSIM[Convert.ToInt32(infoOctet[3], 2)]; 
                    this.RDP = defaultRDP[Convert.ToInt32(infoOctet[4], 2)];
                    this.SPI = defaultSPI[Convert.ToInt32(infoOctet[5], 2)];
                    this.RAB = defaultRAB[Convert.ToInt32(infoOctet[6], 2)];
                    
                    this.TableTRD.Add("TYP"); this.TableTRD.Add(this.TYP);
                    this.TableTRD.Add("SIM"); this.TableTRD.Add(this.SIM);
                    this.TableTRD.Add("RDP"); this.TableTRD.Add(this.RDP);
                    this.TableTRD.Add("SPI"); this.TableTRD.Add(this.SPI);
                    this.TableTRD.Add("RAB"); this.TableTRD.Add(this.RAB);
                }
                if (octets == 1)
                {
                    this.TST = defaultTST[Convert.ToInt32(infoOctet[0], 2)];
                    this.ERR = defaultERR[Convert.ToInt32(infoOctet[1], 2)];
                    this.XPP = defaultXPP[Convert.ToInt32(infoOctet[2], 2)];
                    this.ME = defaultME[Convert.ToInt32(infoOctet[3], 2)];
                    this.MI = defaultMI[Convert.ToInt32(infoOctet[4], 2)];
                    this.FOE = defaultFOE[Convert.ToInt32(infoOctet[5] + infoOctet[6], 2)];
                    
                    this.TableTRD.Add("TST"); this.TableTRD.Add(this.TST);
                    this.TableTRD.Add("ERR"); this.TableTRD.Add(this.ERR);
                    this.TableTRD.Add("XPP"); this.TableTRD.Add(this.XPP);
                    this.TableTRD.Add("ME"); this.TableTRD.Add(this.ME);
                    this.TableTRD.Add("MI"); this.TableTRD.Add(this.MI);
                    this.TableTRD.Add("FOE"); this.TableTRD.Add(this.FOE);
                }
                nextOctet += 8;
            }
        }
    }
}
