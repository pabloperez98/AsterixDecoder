using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class ACAS_CapabilitiesFlightStatus
    {
        public string COM;
        public string STAT;
        public string SI;
        public string MSSC;
        public string ARC;
        public string AIC;
        public string B1A;
        public string B1B_1;
        public string B1B_2;
        public string B1B_3;

        public List<string> TableACAS_CFS = new List<string>();

        public ACAS_CapabilitiesFlightStatus()
        {
            this.COM = "N/A";
            this.STAT = "N/A";
            this.SI = "N/A";
            this.MSSC = "N/A";
            this.ARC = "N/A";
            this.AIC = "N/A";
            this.B1A = "N/A";
            this.B1B_1 = "N/A";
            this.B1B_2 = "N/A";
            this.B1B_3 = "N/A";
        }

        public ACAS_CapabilitiesFlightStatus(List<string> BinACAS_CFS)
        {
            List<string> defaultCOM = new List<string>() { "No communications capability (surveillance only)", "Comm. A and Comm. B capability", "Comm. A, Comm. B and Uplink ELM", "Comm. A, Comm. B, Uplink ELM and Downlink ELM", "Level 5 Transponder capability", "Not assigned", "Not assigned", "Not assigned" };
            List<string> defaultSTAT = new List<string>() { "No alert, no SPI, aircraft airborne", "No alert, no SPI, aircraft on ground", "Alert, no SPI, aircraft airborne", "Alert, no SPI, aircraft on ground", "Alert, SPI, aircraft airborne or on ground", "No alert, SPI, aircraft airborne or on ground", "Not assigned", "Unknown" };
            List<string> defaultSI = new List<string>() { "SI-Code Capable", "II-Code Capable" };
            List<string> defaultMSSC = new List<string>() { "No", "Yes" };
            List<string> defaultARC = new List<string>() { "100 ft resolution", "25 ft resolution" };
            List<string> defaultAIC = new List<string>() { "No", "Yes" };
            List<string> defaultB1A = new List<string>() { "ACAS failed or on standby", "ACAS is operational and receiving TCAS RI = 2, 3 or 4" };
            List<string> defaultB1B_1 = new List<string>() { "ACAS operating hybrid surveillance not operational", "ACAS operating hybrid surveillance operational" };
            List<string> defaultB1B_2 = new List<string>() { "ACAS generating TAs only", "ACAS generating TAs and RAs" };
            List<string> defaultB1B_3 = new List<string>() { "ACAS Version: RTCA DO-185 (6.04A/pre-ACAS)", "ACAS Version: RTCA DO-185A", "ACAS Version: RTCA DO-185B/EUROCAE ED-143",  "Reserved for future versions" };

            this.COM = defaultCOM[Convert.ToInt32(string.Join("", BinACAS_CFS.GetRange(0, 3)), 2)];
            this.STAT = defaultSTAT[Convert.ToInt32(string.Join("", BinACAS_CFS.GetRange(3, 3)), 2)];
            this.SI = defaultSI[Convert.ToInt32(BinACAS_CFS[6], 2)];
            this.MSSC = defaultMSSC[Convert.ToInt32(BinACAS_CFS[8], 2)];
            this.ARC = defaultARC[Convert.ToInt32(BinACAS_CFS[9], 2)];
            this.AIC = defaultAIC[Convert.ToInt32(BinACAS_CFS[10], 2)];
            this.B1A = defaultB1A[Convert.ToInt32(BinACAS_CFS[11])];
            this.B1B_1 = defaultB1B_1[Convert.ToInt32(BinACAS_CFS[12])];
            this.B1B_2 = defaultB1B_2[Convert.ToInt32(BinACAS_CFS[13])];
            this.B1B_3 = defaultB1B_3[Convert.ToInt32(string.Join("", BinACAS_CFS.GetRange(14, 2)), 2)];

            TableACAS_CFS.Add("COM"); TableACAS_CFS.Add(this.COM);
            TableACAS_CFS.Add("STAT"); TableACAS_CFS.Add(this.STAT);
            TableACAS_CFS.Add("SI"); TableACAS_CFS.Add(this.SI);
            TableACAS_CFS.Add("MSSC"); TableACAS_CFS.Add(this.MSSC);
            TableACAS_CFS.Add("ARC"); TableACAS_CFS.Add(this.ARC);
            TableACAS_CFS.Add("AIC"); TableACAS_CFS.Add(this.AIC);
            TableACAS_CFS.Add("B1A"); TableACAS_CFS.Add(this.B1A);
            TableACAS_CFS.Add("B1B_1"); TableACAS_CFS.Add(this.B1B_1);
            TableACAS_CFS.Add("B1B_2"); TableACAS_CFS.Add(this.B1B_2);
            TableACAS_CFS.Add("B1B_3"); TableACAS_CFS.Add(this.B1B_3);
        }
    }
}
