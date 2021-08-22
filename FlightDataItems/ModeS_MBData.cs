using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class ModeS_MBData
    {
        public string REP;
        public List<string> MB_Data;
        public string BDS1;
        public string BDS2;

        // BDS 1.0
        public string OCC;
        public string ACAS;
        public string SVN;
        public string TEPI;
        public string SSC;
        public string UELM;
        public string DELM;
        public string AIC;
        public string SCS;
        public string SIC;
        public string GICB;
        public string HSC;
        public string TAs_RAs;
        public string MOPS;

        // BDS 4.0
        public string MCP_FCU_SA;
        public string FMS_SA;
        public string barometricPressure;
        public string MCP_FCU_ModeStatus;
        public string VNAV_Mode;
        public string ALT_HOLD_Mode;
        public string approachMode;
        public string targetAltSourceStatus;
        public string targetAltSource;

        // BDS 5.0
        public string rollAngle;
        public string trueTrackAngle;
        public string groundSpeed;
        public string trackAngleRate;
        public string trueAirspeed;

        // BDS 5.6
        public string waypoint = "";
        public string ETA;
        public string estimatedFL;
        public string timeToGo;

        // BDS 6.0
        public string magneticHeading;
        public string indicatedAirspeed;
        public string mach;
        public string barometricAltitudeRate;
        public string inertialVerticalRate;

        public List<string> TableMBD = new List<string>();
        public ModeS_MBData()
        { 
            this.REP = "N/A";
            this.BDS1 = "N/A";
            this.BDS2 = "N/A";

            // BDS 1.0
            this.OCC = "N/A";
            this.ACAS = "N/A";
            this.SVN = "N/A";
            this.TEPI = "N/A";
            this.SSC = "N/A";
            this.UELM = "N/A";
            this.DELM = "N/A";
            this.AIC = "N/A";
            this.SCS = "N/A";
            this.SIC = "N/A";
            this.GICB = "N/A";
            this.HSC = "N/A";
            this.TAs_RAs = "N/A";
            this.MOPS = "N/A";

            // BDS 4.0
            this.MCP_FCU_SA = "N/A";
            this.FMS_SA = "N/A";
            this.barometricPressure = "N/A";
            this.MCP_FCU_ModeStatus = "N/A";
            this.VNAV_Mode = "N/A";
            this.ALT_HOLD_Mode = "N/A";
            this.approachMode = "N/A";
            this.targetAltSourceStatus = "N/A";
            this.targetAltSource = "N/A";

            // BDS 5.0
            this.rollAngle = "N/A";
            this.trueTrackAngle = "N/A";
            this.groundSpeed = "N/A";
            this.trackAngleRate = "N/A";
            this.trueAirspeed = "N/A";

            // BDS 5.6
            this.waypoint = "N/A";
            this.ETA = "N/A";
            this.estimatedFL = "N/A";
            this.timeToGo = "N/A";

            // BDS 6.0
            this.magneticHeading = "N/A";
            this.indicatedAirspeed = "N/A";
            this.mach = "N/A";
            this.barometricAltitudeRate = "N/A";
            this.inertialVerticalRate = "N/A";
        }

        public ModeS_MBData(List<string> BinModeS_MBData)
        {
            this.REP = Convert.ToString(Convert.ToInt32(string.Join("", BinModeS_MBData.GetRange(0, 8)), 2));
            for (int i = 0; i < Convert.ToInt32(this.REP); i++)
            {
                this.MB_Data = BinModeS_MBData.GetRange(8 + 64 * i, 56);
                this.BDS1 = Convert.ToInt32(string.Join("", BinModeS_MBData.GetRange(64 + 64 * i, 4)), 2).ToString("X");
                this.BDS2 = Convert.ToInt32(string.Join("", BinModeS_MBData.GetRange(68 + 64 * i, 4)), 2).ToString("X");
                decodeBDS();
            }
        }
        public void decodeBDS()
        {
            if (this.BDS1 == "1" && this.BDS2 == "0")
            {
                List<string> defaultOCC = new List<string>() { "No Overlay Command Capability", "Overlay Command Capability" };
                List<string> defaultACAS = new List<string>() { "ACAS is operational", "ACAS has failed or is on standby" };
                List<string> defaultVersionNumber = new List<string>() { "Mode S subnetwork not available", "ICAO Doc 9688 (1996)", "ICAO Doc 9688 (1998)", "ICAO Annex 10, Volume III, Amendment 77", "ICAO Doc 9871 (1st edition), DO-181D, ED-73C", "ICAO Doc 9871 (2nd edition), DO-181E, ED-73E" };
                List<string> defaultTEPI = new List<string>() { "Level 2 to 4 transponder", "Level 5 transponder" };
                List<string> defaultSSC = new List<string>() { "Mode S specific service capability not supported", "At least one Mode S specific service capability is supported" };
                List<string> defaultUELM = new List<string>() { "No UELM Capability", "16 UELM segments in 1 second", "16 UELM segments in 500 ms", "16 UELM segments in 250 ms", "16 UELM segments in 125 ms", "16 UELM segments in 60 ms", "16 UELM segments in 30 ms", "Reserved" };
                List<string> defaultDELM = new List<string>() { "No DELM Capability", "One 4 segment DELM every second", "One 8 segment DELM every second", "One 16 segment DELM every second", "One 16 segment DELM every 500 ms", "One 16 segment DELM every 250 ms", "One 16 segment DELM every 125 ms", "Reserved", "Reserved", "Reserved", "Reserved", "Reserved", "Reserved", "Reserved", "Reserved", "Reserved" };
                List<string> defaultAIC = new List<string>() { "Aircraft identification capability not available", "Aircraft identification capability available" };
                List<string> defaultSCS = new List<string>() { "Squitter registers are not being updated", "Squitter registers are being updated" };
                List<string> defaultSIC = new List<string>() { "No surveillance identifier code capability", "Surveillance identifier code capability" };
                List<string> defaultGICB = new List<string>() { "Not common usage GICB capability report", "Common usage GICB capability report" };
                List<string> defaultHSC = new List<string>() { "No hybrid surveillance capability", "Hybrid surveillance capability" };
                List<string> defaultTAs_RAs = new List<string>() { "ACAS generating TAs only", "ACAS is generating both TAs and RAs" };
                List<string> defaultMOPS = new List<string>() { "RTCA DO-185", "RTCA DO-185A", "RTCA DO-185B", "Reserved for future versions" };

                this.OCC = defaultOCC[Convert.ToInt32(this.MB_Data[14], 2)];
                this.ACAS = defaultACAS[Convert.ToInt32(this.MB_Data[15], 2)];
                if (Convert.ToInt32(string.Join("", this.MB_Data.GetRange(16, 7)), 2) < 6)
                    this.SVN = defaultVersionNumber[Convert.ToInt32(string.Join("", this.MB_Data.GetRange(16, 7)), 2)];
                else
                    this.SVN = "Reserved";
                this.TEPI = defaultTEPI[Convert.ToInt32(this.MB_Data[23], 2)];
                this.SSC = defaultSSC[Convert.ToInt32(this.MB_Data[24], 2)];
                this.UELM = defaultUELM[Convert.ToInt32(string.Join("", this.MB_Data.GetRange(25, 3)), 2)];
                this.DELM = defaultDELM[Convert.ToInt32(string.Join("", this.MB_Data.GetRange(28, 3)), 2)];
                this.AIC = defaultAIC[Convert.ToInt32(this.MB_Data[32], 2)];
                this.SCS = defaultSCS[Convert.ToInt32(this.MB_Data[33], 2)];
                this.SIC = defaultSIC[Convert.ToInt32(this.MB_Data[34], 2)];
                this.GICB = defaultGICB[Convert.ToInt32(this.MB_Data[35], 2)];
                this.HSC = defaultHSC[Convert.ToInt32(this.MB_Data[36], 2)];
                this.TAs_RAs = defaultTAs_RAs[Convert.ToInt32(this.MB_Data[37], 2)];
                this.MOPS = defaultMOPS[Convert.ToInt32(string.Join("", this.MB_Data.GetRange(38, 2)), 2)];

                this.TableMBD.Add("BDS " + this.BDS1 + "." + this.BDS2); this.TableMBD.Add("Data link capability report");
                this.TableMBD.Add("OCC"); this.TableMBD.Add(this.OCC);
                this.TableMBD.Add("ACAS"); this.TableMBD.Add(this.ACAS);
                this.TableMBD.Add("SVN"); this.TableMBD.Add(this.SVN);
                this.TableMBD.Add("TEPI"); this.TableMBD.Add(this.TEPI);
                this.TableMBD.Add("SSC"); this.TableMBD.Add(this.SSC);
                this.TableMBD.Add("UELM"); this.TableMBD.Add(this.UELM);
                this.TableMBD.Add("DELM"); this.TableMBD.Add(this.DELM);
                this.TableMBD.Add("AIC"); this.TableMBD.Add(this.AIC);
                this.TableMBD.Add("SCS"); this.TableMBD.Add(this.SCS);
                this.TableMBD.Add("SIC"); this.TableMBD.Add(this.SIC);
                this.TableMBD.Add("GICB"); this.TableMBD.Add(this.GICB);
                this.TableMBD.Add("HSC"); this.TableMBD.Add(this.HSC);
                this.TableMBD.Add("TAs/RAs"); this.TableMBD.Add(this.TAs_RAs);
                this.TableMBD.Add("MOPS"); this.TableMBD.Add(this.MOPS);
            }
            else if (this.BDS1 == "1" && this.BDS2 == "7")
            {
                List<string> defaultBDS1dot7 = new List<string>() { "Extended squitter airborne position", "Extended squitter surface position", "Extended squitter status", "Extended squitter identification and category", "Extended squitter airborne velocity information", "Extended squitter event-driven information", "Aircraft identification", "Aircraft registration number",
                    "Selected vertical intention", "Next waypoint identifier", "Next waypoint position", "Next waypoint information", "Meteorological routine report", "Meteorological hazard report", "VHF channel report", "Track and turn report",
                    "Position coarse", "Position fine", "Air-referenced state vector", "Waypoint 1", "Waypoint 2", "Waypoint 3", "Quasi-static parameter monitoring", "Heading and speed report",
                    "Reserved for aircraft capability", "Reserved for aircraft capability", "Reserved for Mode S BITE (Built-in Test Equipment)", "Reserved for Mode S BITE (Built-in Test Equipment)", "Military applications" };
                List<string> defaultNumberBDS1dot7 = new List<string>() { "0.5", "0.6", "0.7", "0.8", "0.9", "0.A", "2.0", "2.I", "4.0", "4.I", "4.2", "4.3", "4.4", "4.5", "4.8", "5.0", "5.1", "5.2", "5.3", "5.4", "5.5", "5.6", "5.F", "6.0", "", "", "E.1", "E.2", "F.1" };
                this.TableMBD.Add("BDS " + this.BDS1 + "." + this.BDS2); this.TableMBD.Add("Selected vertical intention");
                for (int i = 0; i < 30; i++)
                {
                    if (this.MB_Data[i] == "1")
                    { this.TableMBD.Add("GICB " + defaultNumberBDS1dot7[i]); this.TableMBD.Add(defaultBDS1dot7[i]); }
                }
            }
            else if (this.BDS1 == "4" && this.BDS2 == "0")
            {
                List<string> defaultMCP_FCU_ModeStatus = new List<string>() { "No mode information provided", "Mode information deliberately provided" };
                List<string> defaultModes = new List<string>() { "Not active", "Active" };
                List<string> defaultTargetAltSourceStatus = new List<string>() { "No source information provided", "Source information deliberately provided" };
                List<string> defaultTargetAltSource = new List<string>() { "Unknown", "Aircraft altitude", "FCU/MCP selected altitude", "FMS selected altitude" };

                this.MCP_FCU_SA = (Convert.ToInt32(string.Join("", this.MB_Data.GetRange(1, 12)), 2) * 16).ToString();
                this.FMS_SA = (Convert.ToInt32(string.Join("", this.MB_Data.GetRange(14, 12)), 2) * 16).ToString();
                this.barometricPressure = (Convert.ToInt32(string.Join("", this.MB_Data.GetRange(27, 12)), 2) * 0.1 + 800).ToString();
                this.MCP_FCU_ModeStatus = defaultMCP_FCU_ModeStatus[Convert.ToInt32(this.MB_Data[47], 2)];
                this.VNAV_Mode = defaultModes[Convert.ToInt32(this.MB_Data[48], 2)];
                this.ALT_HOLD_Mode = defaultModes[Convert.ToInt32(this.MB_Data[49], 2)];
                this.approachMode = defaultModes[Convert.ToInt32(this.MB_Data[50], 2)];
                this.targetAltSourceStatus = defaultTargetAltSourceStatus[Convert.ToInt32(this.MB_Data[53], 2)];
                this.targetAltSource = defaultTargetAltSource[Convert.ToInt32(string.Join("", this.MB_Data.GetRange(54, 2)), 2)];

                this.TableMBD.Add("BDS " + this.BDS1 + "." + this.BDS2); this.TableMBD.Add("Selected vertical intention");
                this.TableMBD.Add("MCP/FCU Selected Altitude [ft]"); this.TableMBD.Add(this.MCP_FCU_SA);
                this.TableMBD.Add("FMS Selected Altitude [ft]"); this.TableMBD.Add(this.FMS_SA);
                this.TableMBD.Add("Barometric Pressure Setting [mb]"); this.TableMBD.Add(this.barometricPressure);
                this.TableMBD.Add("Status of MCP/FCU Mode"); this.TableMBD.Add(this.MCP_FCU_ModeStatus);
                this.TableMBD.Add("VNAV Mode"); this.TableMBD.Add(this.VNAV_Mode);
                this.TableMBD.Add("ALT HOLD Mode"); this.TableMBD.Add(this.ALT_HOLD_Mode);
                this.TableMBD.Add("Approach Mode"); this.TableMBD.Add(this.approachMode);
                this.TableMBD.Add("Status of Target ALT Source"); this.TableMBD.Add(this.targetAltSourceStatus);
                this.TableMBD.Add("Target ALT Source"); this.TableMBD.Add(this.targetAltSource);
            }
            else if (this.BDS1 == "5" && this.BDS2 == "0")
            {
                this.rollAngle = Math.Round(binTwosComplementToSignedDecimal(string.Join("", this.MB_Data.GetRange(1, 10)), 10) * 45 / 256.0, 3).ToString();
                this.trueTrackAngle = Math.Round(binTwosComplementToSignedDecimal(string.Join("", this.MB_Data.GetRange(12, 11)), 11) * 90 / 512.0, 3).ToString();
                this.groundSpeed = (Convert.ToInt32(string.Join("", this.MB_Data.GetRange(24, 10)), 2) * 1024 / 512.0).ToString();
                this.trackAngleRate = (binTwosComplementToSignedDecimal(string.Join("", this.MB_Data.GetRange(35, 10)), 10) * 8 / 256.0).ToString();
                this.trueAirspeed = (Convert.ToInt32(string.Join("", this.MB_Data.GetRange(46, 10)), 2) * 2).ToString();

                this.TableMBD.Add("BDS " + this.BDS1 + "." + this.BDS2); this.TableMBD.Add("Track and turn report");
                this.TableMBD.Add("Roll Angle [º]"); this.TableMBD.Add(this.rollAngle);
                this.TableMBD.Add("True Track Angle [º]"); this.TableMBD.Add(this.trueTrackAngle);
                this.TableMBD.Add("Ground Speed [kt]"); this.TableMBD.Add(this.groundSpeed);
                this.TableMBD.Add("Track Angle Rate [º/s]"); this.TableMBD.Add(this.trackAngleRate);
                this.TableMBD.Add("True Airspeed [kt]"); this.TableMBD.Add(this.trueAirspeed);
            }
            else if (this.BDS1 == "5" && this.BDS2 == "6")
            {
                for (int ch = 0; ch < 5; ch++)
                { string character = string.Join("", MB_Data.GetRange(1 + ch * 6, 6)); this.waypoint += CodingRules(character); }
                if (this.waypoint.Length == 3)
                    this.waypoint = this.waypoint.PadLeft(5, '0');
                this.ETA = Math.Round(Convert.ToInt32(string.Join("", this.MB_Data.GetRange(31, 9)), 2) * 60 / 512.0, 3).ToString();
                this.estimatedFL = (Convert.ToInt32(string.Join("", this.MB_Data.GetRange(40, 6)), 2) * 10).ToString();
                this.timeToGo = Math.Round(Convert.ToInt32(string.Join("", this.MB_Data.GetRange(46, 9)), 2) * 60 / 512.0, 3).ToString();

                this.TableMBD.Add("BDS " + this.BDS1 + "." + this.BDS2); this.TableMBD.Add("Information of the next waypoint plus two");
                this.TableMBD.Add("Waypoint Name"); this.TableMBD.Add(this.waypoint);
                this.TableMBD.Add("Estimated Time of Arrival (ETA) [min]"); this.TableMBD.Add(this.ETA);
                this.TableMBD.Add("Estimated Flight Level [FL]"); this.TableMBD.Add(this.estimatedFL);
                this.TableMBD.Add("Time to go (Direct Route) [min]"); this.TableMBD.Add(this.timeToGo);
            }
            else if (this.BDS1 == "6" && this.BDS2 == "0")
            {
                this.magneticHeading = Math.Round(binTwosComplementToSignedDecimal(string.Join("", this.MB_Data.GetRange(1, 11)), 11) * 90 / 512.0, 3).ToString();
                this.indicatedAirspeed = Convert.ToInt32(string.Join("", this.MB_Data.GetRange(13, 10)), 2).ToString();
                this.mach = (Convert.ToInt32(string.Join("", this.MB_Data.GetRange(24, 10)), 2) * 2.048 / 512.0).ToString();
                this.barometricAltitudeRate = (binTwosComplementToSignedDecimal(string.Join("", this.MB_Data.GetRange(35, 10)), 10) * 8192 / 256.0).ToString();
                this.inertialVerticalRate = (binTwosComplementToSignedDecimal(string.Join("", this.MB_Data.GetRange(46, 10)), 10) * 8192 / 256.0).ToString();

                this.TableMBD.Add("BDS " + this.BDS1 + "." + this.BDS2); this.TableMBD.Add("Heading and speed report");
                this.TableMBD.Add("Magnetic Heading [º]"); this.TableMBD.Add(this.magneticHeading);
                this.TableMBD.Add("Indicated Airspeed [kt]"); this.TableMBD.Add(this.indicatedAirspeed);
                this.TableMBD.Add("Mach [-]"); this.TableMBD.Add(this.mach);
                this.TableMBD.Add("Barometric Altitude Rate [ft/min]"); this.TableMBD.Add(this.barometricAltitudeRate);
                this.TableMBD.Add("Intertial Vertical Rate [ft/min]"); this.TableMBD.Add(this.inertialVerticalRate);
            }
            else
            { this.TableMBD.Add("BDS " + this.BDS1 + "." + this.BDS2); this.TableMBD.Add("No MB Data"); }
        }

        public static double binTwosComplementToSignedDecimal(string binary, int significantBits)
        {
            double power = Math.Pow(2, significantBits - 1);
            double sum = 0;
            int i;
            for (i = 0; i < significantBits; ++i)
            {
                if (i == 0 && binary[i] != '0')
                    sum = power * -1;
                else
                    sum += (binary[i] - '0') * power;
                power /= 2;
            }
            return sum;
        }

        public string CodingRules(string CharacterStr)
        {
            List<string> code = new List<string>() { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string Character = code[Convert.ToInt32(CharacterStr, 2)];
            return Character;
        }
    }
}