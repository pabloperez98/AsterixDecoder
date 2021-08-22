using System;
using System.Collections.Generic;


namespace FlightDataItems
{
    public class TargetReportDescriptorCAT21v023
    {
        public string DCR;
        public string GBS;
        public string SIM;
        public string TST;
        public string RAB;
        public string SAA;
        public string SPI;

        public string ATP;
        public string ARC;

        public List<string> TableTRD = new List<string>();
        public TargetReportDescriptorCAT21v023(List<string> BinTRD_CAT21V023)
        {
            List<string> defaultDCR = new List<string>() { "No differential correction (ADS-B)", "Differential correction (ADS-B)" };
            List<string> defaultGBS = new List<string>() { "Ground Bit not set", "Ground Bit set" };
            List<string> defaultSIM = new List<string>() { "Actual target report", "Simulated target report" };
            List<string> defaultTST = new List<string>() { "Default", "Test Target" };
            List<string> defaultRAB = new List<string>() { "Report from target transponder", "Report from field monitor (fixed transponder)" };
            List<string> defaultSAA = new List<string>() { "Equipement not capable to provide Selected Altitude", "Equipement capable to provide Selected Altitude" };
            List<string> defaultSPI = new List<string>() { "Absence of SPI", "Special Position Identification" };

            List<string> defaultATP = new List<string>() { "Non unique address", "24-Bit ICAO address", "Surface vehicle address","Anonymous address", "Reserved for future use", "Reserved for future use", "Reserved for future use", "Reserved for future use" };
            List<string> defaultARC = new List<string>() { "Unknown", "25 ft", "100 ft" };

            this.DCR = defaultDCR[Convert.ToInt32(BinTRD_CAT21V023[0], 2)];
            this.GBS = defaultGBS[Convert.ToInt32(BinTRD_CAT21V023[1], 2)];
            this.SIM = defaultSIM[Convert.ToInt32(BinTRD_CAT21V023[2], 2)];
            this.TST = defaultTST[Convert.ToInt32(BinTRD_CAT21V023[3], 2)];
            this.RAB = defaultRAB[Convert.ToInt32(BinTRD_CAT21V023[4], 2)];
            this.SAA = defaultSAA[Convert.ToInt32(BinTRD_CAT21V023[5], 2)];
            this.SPI = defaultSPI[Convert.ToInt32(BinTRD_CAT21V023[6], 2)];
            this.ATP = defaultATP[Convert.ToInt32(string.Join(BinTRD_CAT21V023[8],BinTRD_CAT21V023[9],BinTRD_CAT21V023[10]), 2)];
            this.ARC = defaultARC[Convert.ToInt32(string.Join(BinTRD_CAT21V023[11],BinTRD_CAT21V023[12]), 2)];

            this.TableTRD.Add("DCR"); this.TableTRD.Add(this.DCR);
            this.TableTRD.Add("GBS"); this.TableTRD.Add(this.GBS);
            this.TableTRD.Add("SIM"); this.TableTRD.Add(this.SIM);
            this.TableTRD.Add("TST"); this.TableTRD.Add(this.TST);
            this.TableTRD.Add("RAB"); this.TableTRD.Add(this.RAB);
            this.TableTRD.Add("SAA"); this.TableTRD.Add(this.SAA);
            this.TableTRD.Add("SPI"); this.TableTRD.Add(this.SPI);
            this.TableTRD.Add("ATP"); this.TableTRD.Add(this.ATP);
            this.TableTRD.Add("ARC"); this.TableTRD.Add(this.ARC);
        }
        public TargetReportDescriptorCAT21v023()
        {
            this.DCR = "N/A";
            this.GBS = "N/A";
            this.SIM = "N/A";
            this.TST = "N/A";
            this.RAB = "N/A";
            this.SAA = "N/A";
            this.SPI = "N/A";
            this.ATP = "N/A";
            this.ARC = "N/A";
        }
    }
}