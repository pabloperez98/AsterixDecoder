using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class TrackStatusCAT62
    {
        public string MON;
        public string SPI;
        public string MRH;
        public string SRC;
        public string CNF;

        public string SIM;
        public string TSE;
        public string TSB;
        public string FPC;
        public string AFF;
        public string STP;
        public string KOS;

        public string AMA;
        public string MD4;
        public string ME;
        public string MI;
        public string MD5;

        public string CST;
        public string PSR;
        public string SSR;
        public string MDS;
        public string ADS;
        public string SUC;
        public string AAC;

        public string SDS;
        public string EMS;
        public string PFT;
        public string FPLT;

        public string DUPT;
        public string DUPF;
        public string DUPM;
        public string SFC;
        public string IDD;
        public string IEC;

        public List<string> TableTS = new List<string>();

        public TrackStatusCAT62()
        {
            this.MON = "N/A";
            this.SPI = "N/A";
            this.MRH = "N/A";
            this.SRC = "N/A";
            this.CNF = "N/A";

            this.SIM = "N/A";
            this.TSE = "N/A";
            this.TSB = "N/A";
            this.FPC = "N/A";
            this.AFF = "N/A";
            this.STP = "N/A";
            this.KOS = "N/A";

            this.AMA = "N/A";
            this.MD4 = "N/A";
            this.ME = "N/A";
            this.MI = "N/A";
            this.MD5 = "N/A";

            this.CST = "N/A";
            this.PSR = "N/A";
            this.SSR = "N/A";
            this.MDS = "N/A";
            this.ADS = "N/A";
            this.SUC = "N/A";
            this.AAC = "N/A";

            this.SDS = "N/A";
            this.EMS = "N/A";
            this.PFT = "N/A";
            this.FPLT = "N/A";

            this.DUPT = "N/A";
            this.DUPF = "N/A";
            this.DUPM = "N/A";
            this.SFC = "N/A";
            this.IDD = "N/A";
            this.IEC = "N/A";
        }

        public TrackStatusCAT62(List<string> BinTrackStatus)
        {
            int nextOctet = 0;
            for (int octets = 0; octets < BinTrackStatus.Count / 8; octets++)
            {
                List<string> infoOctet = new List<string>();
                for (int bit = 0; bit < 8; bit++)
                    infoOctet.Add(BinTrackStatus[bit + nextOctet]);
                if (octets == 0)
                {
                    List<string> defaultMON = new List<string>() { "Multisensor track", "Monosensor track" };
                    List<string> defaultSPI = new List<string>() { "Default value", "SPI present in the last report received from a sensor capable of decoding this data" };
                    List<string> defaultMRH = new List<string>() { "Barometric altitude (Mode C) more reliable", "Geometric altitude more reliable" };
                    List<string> defaultSRC = new List<string>() { "No source", "GNSS", "3D radar", "Triangulation", "Height from coverage", "Speed look-up table", "Default height", "Multilateration" };
                    List<string> defaultCNF = new List<string>() { "Confirmed track", "Tentative track" };
                    
                    this.MON = defaultMON[Convert.ToInt32(infoOctet[0], 2)];
                    this.SPI = defaultSPI[Convert.ToInt32(infoOctet[1], 2)];
                    this.MRH = defaultMRH[Convert.ToInt32(infoOctet[2], 2)];
                    this.SRC = defaultSRC[Convert.ToInt32(string.Join("", infoOctet.GetRange(3, 3)), 2)];
                    this.CNF = defaultCNF[Convert.ToInt32(infoOctet[6], 2)];
                    
                    this.TableTS.Add("MON"); this.TableTS.Add(this.MON);
                    this.TableTS.Add("SPI"); this.TableTS.Add(this.SPI);
                    this.TableTS.Add("MRH"); this.TableTS.Add(this.MRH);
                    this.TableTS.Add("SRC"); this.TableTS.Add(this.SRC);
                    this.TableTS.Add("CNF"); this.TableTS.Add(this.CNF);

                }
                else if (octets == 1)
                {
                    List<string> defaultSIM = new List<string>() { "Actual track", "Simulated track" };
                    List<string> defaultTSE = new List<string>() { "Default value", "Last message transmitted to the user for the track" };
                    List<string> defaultTSB = new List<string>() { "Default value", "First message transmitted to the user for the track" };
                    List<string> defaultFPC = new List<string>() { "Not flight-plan correlated", "Flight plan correlated" };
                    List<string> defaultAFF = new List<string>() { "Default value", "ADS-B data inconsistent with other surveillance information" };
                    List<string> defaultSTP = new List<string>() { "Default value", "Slave Track Promotion" };
                    List<string> defaultKOS = new List<string>() { "Complementary service used", "Background service used" };

                    this.SIM = defaultSIM[Convert.ToInt32(infoOctet[0], 2)];
                    this.TSE = defaultTSE[Convert.ToInt32(infoOctet[1], 2)];
                    this.TSB = defaultTSB[Convert.ToInt32(infoOctet[2], 2)];
                    this.FPC = defaultFPC[Convert.ToInt32(infoOctet[3], 2)];
                    this.AFF = defaultAFF[Convert.ToInt32(infoOctet[4], 2)];
                    this.STP = defaultSTP[Convert.ToInt32(infoOctet[5], 2)];
                    this.KOS = defaultKOS[Convert.ToInt32(infoOctet[6], 2)];

                    this.TableTS.Add("SIM"); this.TableTS.Add(this.SIM);
                    this.TableTS.Add("TSE"); this.TableTS.Add(this.TSE);
                    this.TableTS.Add("TSB"); this.TableTS.Add(this.TSB);
                    this.TableTS.Add("FPC"); this.TableTS.Add(this.FPC);
                    this.TableTS.Add("AFF"); this.TableTS.Add(this.AFF);
                    this.TableTS.Add("STP"); this.TableTS.Add(this.STP);
                    this.TableTS.Add("KOS"); this.TableTS.Add(this.KOS);
                }
                else if (octets == 2)
                {
                    List<string> defaultAMA = new List<string>() { "Track not resulting from amalgamation process", "Track resulting from amalgamation process" };
                    List<string> defaultMD4 = new List<string>() { "No Mode 4 interrogation", "Friendly target", "Unknown target", "No reply" };
                    List<string> defaultME = new List<string>() { "Default value", "Military Emergency present in the last report received from a sensor capable of decoding this data" };
                    List<string> defaultMI = new List<string>() { "Default value", "Military Identification present in the last report received from a sensor capable of decoding this data" };
                    List<string> defaultMD5 = new List<string>() { "No Mode 5 interrogation", "Friendly target", "Unknown target", "No reply" };

                    this.AMA = defaultAMA[Convert.ToInt32(infoOctet[0], 2)];
                    this.MD4 = defaultMD4[Convert.ToInt32(string.Join("", infoOctet.GetRange(1, 2)), 2)];
                    this.ME = defaultME[Convert.ToInt32(infoOctet[3], 2)];
                    this.MI = defaultMI[Convert.ToInt32(infoOctet[4], 2)];
                    this.MD5 = defaultMD5[Convert.ToInt32(string.Join("", infoOctet.GetRange(5, 2)), 2)];

                    this.TableTS.Add("AMA"); this.TableTS.Add(this.AMA);
                    this.TableTS.Add("MD4"); this.TableTS.Add(this.MD4);
                    this.TableTS.Add("ME"); this.TableTS.Add(this.ME);
                    this.TableTS.Add("MI"); this.TableTS.Add(this.MI);
                    this.TableTS.Add("MD5"); this.TableTS.Add(this.MD5);
                }
                else if (octets == 3)
                {
                    List<string> defaultCST = new List<string>() { "Default value", "Age of the last received track update is higher than system dependent threshold (coasting)" };
                    List<string> defaultPSR = new List<string>() { "Default value", "Age of the last received PSR update is higher than system dependent threshold" };
                    List<string> defaultSSR = new List<string>() { "Default value", "Age of the last received SSR update is higher than system dependent threshold" };
                    List<string> defaultMDS = new List<string>() { "Default value", "Age of the last received Mode S update is higher than system dependent threshold" };
                    List<string> defaultADS = new List<string>() { "Default value", "Age of the last received ADS-B update is higher than system dependent threshold" };
                    List<string> defaultSUC = new List<string>() { "Default value", "Special Used Code (Mode A codes to be defined in the system to mark a track with special interest)" };
                    List<string> defaultAAC = new List<string>() { "Default value", "Assigned Mode A Code Conflict (same discrete Mode A Code assigned to another track)" };

                    this.CST = defaultCST[Convert.ToInt32(infoOctet[0], 2)];
                    this.PSR = defaultPSR[Convert.ToInt32(infoOctet[1], 2)];
                    this.SSR = defaultSSR[Convert.ToInt32(infoOctet[2], 2)];
                    this.MDS = defaultMDS[Convert.ToInt32(infoOctet[3], 2)];
                    this.ADS = defaultADS[Convert.ToInt32(infoOctet[4], 2)];
                    this.SUC = defaultSUC[Convert.ToInt32(infoOctet[5], 2)];
                    this.AAC = defaultAAC[Convert.ToInt32(infoOctet[6], 2)];

                    this.TableTS.Add("CST"); this.TableTS.Add(this.CST);
                    this.TableTS.Add("PSR"); this.TableTS.Add(this.PSR);
                    this.TableTS.Add("SSR"); this.TableTS.Add(this.SSR);
                    this.TableTS.Add("MDS"); this.TableTS.Add(this.MDS);
                    this.TableTS.Add("ADS"); this.TableTS.Add(this.ADS);
                    this.TableTS.Add("SUC"); this.TableTS.Add(this.SUC);
                    this.TableTS.Add("AAC"); this.TableTS.Add(this.AAC);
                }
                else if (octets == 4)
                {
                    List<string> defaultSDS = new List<string>() { "Combined", "Co-operative only", "Non-Cooperative only", "Not defined" };
                    List<string> defaultEMS = new List<string>() { "No emergency", "General emergency", "Lifeguard/medical", "Minimum fuel", "No communications", "Unlawful interference", "“Downed” Aircraft", "Undefined" };
                    List<string> defaultPFT = new List<string>() { "No indication", "Potential False Track Indication" };
                    List<string> defaultFPLT = new List<string>() { "Default value", "Track created/updated with FPL data" };

                    this.SDS = defaultSDS[Convert.ToInt32(string.Join("", infoOctet.GetRange(0, 2)), 2)];
                    this.EMS = defaultEMS[Convert.ToInt32(string.Join("", infoOctet.GetRange(2, 3)), 2)];
                    this.PFT = defaultPFT[Convert.ToInt32(infoOctet[5], 2)];
                    this.FPLT = defaultFPLT[Convert.ToInt32(infoOctet[6], 2)];
                    
                    this.TableTS.Add("SDS"); this.TableTS.Add(this.SDS);
                    this.TableTS.Add("EMS"); this.TableTS.Add(this.EMS);
                    this.TableTS.Add("PFT"); this.TableTS.Add(this.PFT);
                    this.TableTS.Add("FPLT"); this.TableTS.Add(this.FPLT);
                }
                else if (octets == 5)
                {
                    List<string> defaultDUPT = new List<string>() { "Default value", "Duplicate Mode 3/A Code" };
                    List<string> defaultDUPF = new List<string>() { "Default value", "Duplicate Flight Plan" };
                    List<string> defaultDUPM = new List<string>() { "Default value", "Duplicate Flight Plan due to manual correlation" };
                    List<string> defaultSFC = new List<string>() { "Default value", "Surface target" };
                    List<string> defaultIDD = new List<string>() { "No indication", "Duplicate Flight-ID" };
                    List<string> defaultIEC = new List<string>() { "Default value", "Inconsistent Emergency Code" };

                    this.DUPT = defaultDUPT[Convert.ToInt32(infoOctet[0], 2)];
                    this.DUPF = defaultDUPF[Convert.ToInt32(infoOctet[1], 2)];
                    this.DUPM = defaultDUPM[Convert.ToInt32(infoOctet[2], 2)];
                    this.SFC = defaultSFC[Convert.ToInt32(infoOctet[3], 2)];
                    this.IDD = defaultIDD[Convert.ToInt32(infoOctet[4], 2)];
                    this.IEC = defaultIEC[Convert.ToInt32(infoOctet[5], 2)];

                    this.TableTS.Add("DUPT"); this.TableTS.Add(this.DUPT);
                    this.TableTS.Add("DUPF"); this.TableTS.Add(this.DUPF);
                    this.TableTS.Add("DUPM"); this.TableTS.Add(this.DUPM);
                    this.TableTS.Add("SFC"); this.TableTS.Add(this.SFC);
                    this.TableTS.Add("IDD"); this.TableTS.Add(this.IDD);
                    this.TableTS.Add("IEC"); this.TableTS.Add(this.IEC);
                }
                nextOctet += 8;
            }
        }
    }
}
