using System;
using System.Collections.Generic;
using System.Linq;


namespace FlightDataItems
{
    public class TargetReportDescriptorCAT10
    {
        public string TYP;
        public string DCR;
        public string CHN;
        public string GBS;
        public string CRT;

        public string SIM;
        public string TST;
        public string RAB;
        public string LOP;
        public string TOT;

        public string SPI;

        public List<string> TableTRD = new List<string>();
        public TargetReportDescriptorCAT10(List<string> BinaryTRD)
        {
            List<string> defaultTYP = new List<string>() { "SSR multilateriation", "Mode S multilateration", "ADS-B", "PSR", "Magnetic Loop System", "HF multilateration", "Not defined", "Other types" };
            List<string> defaultDCR = new List<string>() { "No differential correction (ADS-B)", "Differential correction (ADS-B)" };
            List<string> defaultCHN = new List<string>() { "Chain 1", "Chain 2" };
            List<string> defaultGBS = new List<string>() { "Transponder Ground bit not set", "Transponder Ground bit set" };
            List<string> defaultCRT = new List<string>() { "No corrupted reply in multilateration", "Corrupted reply in multilateration" };

            List<string> defaultSIM = new List<string>() { "Actual target report", "Simulated target report" };
            List<string> defaultTST = new List<string>() { "Default", "Test target" };
            List<string> defaultRAB = new List<string>() { "Report from target transponder", "Report from field monitor (fixed tranponder)" };
            List<string> defaultLOP = new List<string>() { "Undetermined", "Loop start", "Loop finish" };
            List<string> defaultTOT = new List<string>() { "Undetermined", "Aircraft", "Ground vehicle", "Helicopter" };

            List<string> defaultSPI = new List<string>() { "Absence of SPI", "Special Position Identification" };

            int nextOctet = 0;
            for (int octets = 0; octets < BinaryTRD.Count() / 8; octets++)
            {
                List<string> infoOctet = new List<string>();
                for (int bit = 0; bit < 7; bit++)
                    infoOctet.Add(BinaryTRD[bit + nextOctet]);
                if (octets == 0)
                {
                    this.TYP = defaultTYP[Convert.ToInt32(string.Join("", infoOctet.GetRange(0, 3)), 2)];
                    this.DCR = defaultDCR[Convert.ToInt32(infoOctet[3], 2)];
                    this.CHN = defaultCHN[Convert.ToInt32(infoOctet[4], 2)];
                    this.GBS = defaultGBS[Convert.ToInt32(infoOctet[5], 2)];
                    this.CRT = defaultCRT[Convert.ToInt32(infoOctet[6], 2)];
                    this.TableTRD.Add("TYP"); this.TableTRD.Add(this.TYP);
                    this.TableTRD.Add("DCR"); this.TableTRD.Add(this.DCR);
                    this.TableTRD.Add("CHN"); this.TableTRD.Add(this.CHN);
                    this.TableTRD.Add("GBS"); this.TableTRD.Add(this.GBS);
                    this.TableTRD.Add("CRT"); this.TableTRD.Add(this.CRT);
                }
                if (octets == 1)
                {
                    this.SIM = defaultSIM[Convert.ToInt32(infoOctet[0], 2)];
                    this.TST = defaultTST[Convert.ToInt32(infoOctet[1], 2)];
                    this.RAB = defaultRAB[Convert.ToInt32(infoOctet[2], 2)];
                    this.LOP = defaultLOP[Convert.ToInt32(infoOctet[3] + infoOctet[4], 2)];
                    this.TOT = defaultTOT[Convert.ToInt32(infoOctet[5] + infoOctet[6], 2)];
                    this.TableTRD.Add("SIM"); this.TableTRD.Add(this.SIM);
                    this.TableTRD.Add("TST"); this.TableTRD.Add(this.TST);
                    this.TableTRD.Add("RAB"); this.TableTRD.Add(this.RAB);
                    this.TableTRD.Add("LOP"); this.TableTRD.Add(this.LOP);
                    this.TableTRD.Add("TOT"); this.TableTRD.Add(this.TOT);
                }
                if (octets == 2)
                {
                    this.SPI = defaultSPI[Convert.ToInt32(infoOctet[0], 2)];
                    this.TableTRD.Add("SPI"); this.TableTRD.Add(this.SPI);
                }
                nextOctet += 8;
            }
        }
        public TargetReportDescriptorCAT10()
        {
            this.TYP = "N/A";
            this.DCR = "N/A";
            this.CHN = "N/A";
            this.GBS = "N/A";
            this.CRT = "N/A";

            this.SIM = "N/A";
            this.TST = "N/A";
            this.RAB = "N/A";
            this.LOP = "N/A";
            this.TOT = "N/A";

            this.SPI = "N/A";
        }
    }
}
