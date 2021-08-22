using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class TargetReportDescriptorCAT21v21
    {
        //Structure Primary Subfield
        public string ATP;
        public string ARC;
        public string RC;
        public string RAB;
        //Structure first extension
        public string DCR;
        public string GBS;
        public string SIM;
        public string TST;
        public string SAA;
        public string CL;
        //Structure second extension
        public string IPC;
        public string NOGO;
        public string CPR;
        public string LDPJ;
        public string RCF;

        public List<string> TableTRD = new List<string>();

        public TargetReportDescriptorCAT21v21(List<string> BinTRD_CAT21v21)
        {
            List<string> defaultATP = new List<string>() {"24-Bit ICAO address", "Duplicate address", "Surface vehicle address", "Anonymous address", "Reserved for future use", "Reserved for future use", "Reserved for future use", "Reserved for future use" };
            List<string> defaultARC = new List<string>() { "25 ft", "100 ft", "Unknown","Invalid"};
            List<string> defaultRC = new List<string>() { "Default", "Range Check passed, CPR Validation pending"};
            List<string> defaultRAB = new List<string>() { "Report from target transponder", "Report from field monitor (fixed transponder)"};

            List<string> defaultDCR = new List<string>() { "No differential correction (ADS-B)", "Differential correction (ADS-B)"};
            List<string> defaultGBS = new List<string>() { "Ground Bit not set", "Ground Bit set" };
            List<string> defaultSIM = new List<string>() { "Actual target report", "Simulated target report"};
            List<string> defaultTST = new List<string>() { "Default", "Test Target" };
            List<string> defaultSAA = new List<string>() { "Equipement capable to provide Selected Altitude", "Equipement not capable to provide Selected Altitude"};
            List<string> defaultCL = new List<string>() { "Report valid", "Report suspect", "No information", "Reserved for future use"};

            List<string> defaultIPC = new List<string>() { "Default", "Report suspect", "No information", "Reserved for future use" };
            List<string> defaultNOGO = new List<string>() { "NOGO-bit not set ", "NOGO-bit set" };
            List<string> defaultCPR = new List<string>() { "CPR Validation correct", "CPR Validation failed" };
            List<string> defaultLDPJ = new List<string>() { "LDPJ not detected", "LDPJ detected"};
            List<string> defaultRCF = new List<string>() { "Default", "Range Check failed"};

            List<string> variable = new List<string>();
            int nextOctet = 0;
            for (int octets = 0; octets < BinTRD_CAT21v21.Count / 8; octets++)
            {
                for (int bit = 0; bit < 8; bit++)
                    variable.Add(BinTRD_CAT21v21[bit + nextOctet]);
                if (octets == 0)
                {
                    this.ATP = defaultATP[Convert.ToInt32(variable[0] + variable[1] + variable[2], 2)];
                    this.ARC = defaultARC[Convert.ToInt32(variable[3] + variable[4], 2)];
                    this.RC = defaultRC[Convert.ToInt32(variable[5], 2)];
                    this.RAB = defaultRAB[Convert.ToInt32(variable[6], 2)];
                    this.TableTRD.Add("ATP"); this.TableTRD.Add(this.ATP);
                    this.TableTRD.Add("ARC"); this.TableTRD.Add(this.ARC);
                    this.TableTRD.Add("RC"); this.TableTRD.Add(this.RC);
                    this.TableTRD.Add("RAB"); this.TableTRD.Add(this.RAB);
                }
                if (octets == 1)
                {
                    this.DCR = defaultDCR[Convert.ToInt32(variable[0], 2)];
                    this.GBS = defaultGBS[Convert.ToInt32(variable[1], 2)];
                    this.SIM = defaultSIM[Convert.ToInt32(variable[2], 2)];
                    this.TST = defaultTST[Convert.ToInt32(variable[3], 2)];
                    this.SAA = defaultSAA[Convert.ToInt32(variable[4], 2)];
                    this.CL = defaultCL[Convert.ToInt32(variable[5]+ variable[6], 2)];
                    this.TableTRD.Add("DCR"); this.TableTRD.Add(this.DCR);
                    this.TableTRD.Add("GBS"); this.TableTRD.Add(this.GBS);
                    this.TableTRD.Add("SIM"); this.TableTRD.Add(this.SIM);
                    this.TableTRD.Add("TST"); this.TableTRD.Add(this.TST);
                    this.TableTRD.Add("SAA"); this.TableTRD.Add(this.SAA);
                    this.TableTRD.Add("CL"); this.TableTRD.Add(this.CL);
                }
                if (octets == 2)
                {
                    this.IPC = defaultIPC[Convert.ToInt32(variable[2], 2)];
                    this.NOGO = defaultNOGO[Convert.ToInt32(variable[3], 2)];
                    this.CPR = defaultCPR[Convert.ToInt32(variable[4], 2)];
                    this.LDPJ = defaultLDPJ[Convert.ToInt32(variable[5], 2)];
                    this.RCF = defaultRCF[Convert.ToInt32(variable[6], 2)];
                    this.TableTRD.Add("IPC"); this.TableTRD.Add(this.IPC);
                    this.TableTRD.Add("NOGO"); this.TableTRD.Add(this.NOGO);
                    this.TableTRD.Add("CPR"); this.TableTRD.Add(this.CPR);
                    this.TableTRD.Add("LDPJ"); this.TableTRD.Add(this.LDPJ);
                    this.TableTRD.Add("RCF"); this.TableTRD.Add(this.RCF);

                }   
                nextOctet += 8;
                variable.Clear();
            }
        }
        public TargetReportDescriptorCAT21v21()
        {
            this.ATP = "N/A";
            this.ARC = "N/A";
            this.RC = "N/A";
            this.RAB = "N/A";

            this.DCR = "N/A";
            this.GBS = "N/A";
            this.SIM = "N/A";
            this.TST = "N/A";
            this.SAA = "N/A";
            this.CL = "N/A";

            this.IPC = "N/A";
            this.NOGO = "N/A";
            this.CPR = "N/A";
            this.LDPJ = "N/A";
            this.RCF = "N/A";
        }
    }
}
