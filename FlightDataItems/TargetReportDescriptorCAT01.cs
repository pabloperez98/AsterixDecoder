using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class TargetReportDescriptorCAT01
    {
        public string TYP;
        public string SIM;
        public string SSR_PSR;
        public string ANT;
        public string SPI;
        public string RAB;

        public string TST;
        public string DS1_DS2;
        public string ME;
        public string MI;

        public List<string> TableTRD = new List<string>();

        public TargetReportDescriptorCAT01(List<string> BinaryTRD)
        {
            List<string> defaultTYP = new List<string>() { "Plot", "Track" };
            List<string> defaultSIM = new List<string>() { "Actual plot or track", "Simulated plot or track" };
            List<string> defaultSSR_PSR = new List<string>() { "No detection", "Sole primary detection", "Sole secondary detection", "Combined primary and secondary detection" };
            List<string> defaultANT = new List<string>() { "Target report from antenna 1", "Target report from antenna 2" };
            List<string> defaultSPI = new List<string>() { "Default", "Special Position Identification" };
            List<string> defaultRAB = new List<string>() { "Default", "Plot or track from a fixed transponder" };

            List<string> defaultTST = new List<string>() { "Default", "Test target indicator" };
            List<string> defaultDS1_DS2 = new List<string>() { "Default", "Unlawful interference (code 7500)", "Radio-communicationfailure (code 7600)", "Emergency (code 7700)" };
            List<string> defaultME = new List<string>() { "Default", "Military emergency" };
            List<string> defaultMI = new List<string>() { "Default", "Military identification" };

            int nextOctet = 0;
            for (int octets = 0; octets < BinaryTRD.Count / 8; octets++)
            {
                List<string> infoOctet = new List<string>();
                for (int bit = 0; bit < 7; bit++)
                    infoOctet.Add(BinaryTRD[bit + nextOctet]);
                if (octets == 0)
                {
                    this.TYP = defaultTYP[Convert.ToInt32(infoOctet[0], 2)];
                    this.SIM = defaultSIM[Convert.ToInt32(infoOctet[1], 2)];
                    this.SSR_PSR = defaultSSR_PSR[Convert.ToInt32(string.Concat(infoOctet[2], infoOctet[3]), 2)];
                    this.ANT = defaultANT[Convert.ToInt32(infoOctet[4], 2)];
                    this.SPI = defaultSPI[Convert.ToInt32(infoOctet[5], 2)];
                    this.RAB = defaultRAB[Convert.ToInt32(infoOctet[6], 2)];
                    this.TableTRD.Add("TYP"); this.TableTRD.Add(this.TYP);
                    this.TableTRD.Add("SIM"); this.TableTRD.Add(this.SIM);
                    this.TableTRD.Add("SSR/PSR"); this.TableTRD.Add(this.SSR_PSR);
                    this.TableTRD.Add("ANT"); this.TableTRD.Add(this.ANT);
                    this.TableTRD.Add("SPI"); this.TableTRD.Add(this.SPI);
                    this.TableTRD.Add("RAB"); this.TableTRD.Add(this.RAB);
                }
                if (octets == 1)
                {
                    this.TST = defaultTST[Convert.ToInt32(infoOctet[0], 2)];
                    this.DS1_DS2 = defaultDS1_DS2[Convert.ToInt32(string.Concat(infoOctet[1], infoOctet[2]), 2)];
                    this.ME = defaultME[Convert.ToInt32(infoOctet[3], 2)];
                    this.MI = defaultMI[Convert.ToInt32(infoOctet[4], 2)];
                    this.TableTRD.Add("TST"); this.TableTRD.Add(this.TST);
                    this.TableTRD.Add("DS1/DS2"); this.TableTRD.Add(this.DS1_DS2);
                    this.TableTRD.Add("ME"); this.TableTRD.Add(this.ME);
                    this.TableTRD.Add("MI"); this.TableTRD.Add(this.MI);
                }
                nextOctet += 8;
            }
        }
        public TargetReportDescriptorCAT01()
        {
            this.TYP = "N/A";
            this.SIM = "N/A";
            this.SSR_PSR = "N/A";
            this.ANT = "N/A";
            this.SPI = "N/A";
            this.RAB = "N/A";

            this.TST = "N/A";
            this.DS1_DS2 = "N/A";
            this.ME = "N/A";
            this.MI = "N/A";
        }
    }
}
