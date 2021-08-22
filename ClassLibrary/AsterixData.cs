using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ClassLibrary
{
    public class AsterixData
    {
        public List<AsterixFile> AsterixFiles = new List<AsterixFile>();
        public List<CATs> listaCATs = new List<CATs>();
        public DataTable tablaCATs = new DataTable();
        public List<Flight> FlightList = new List<Flight>();
        public List<RadarStation> RadarStationList = new List<RadarStation>();
        public List<string> CATsList = new List<string>();
        public List<string> DSIList = new List<string>();
        public List<string> SensorList = new List<string>();
        public List<string> CallsignList = new List<string>();
        public List<string> TrackNumberList = new List<string>();
        public List<Boolean> filledDataItems = new List<bool>();
        public int messagesCAT01 = 0; public int messagesCAT02 = 0; public int messagesCAT08 = 0; public int messagesCAT10 = 0; public int messagesCAT21 = 0; public int messagesCAT34 = 0; public int messagesCAT48 = 0; public int messagesCAT62 = 0;
        public int packetNumber = 1;
        public int rowPosition;
        public List<string> analyzedCATs = new List<string>() { "01", "02", "08", "10", "21", "34", "48", "62" };
        public List<string> FRNinfoCATs = new List<string>() { "Packet\nNº", "Category", "SAC/SIC", "Radar\n                      Station                      ", "UTC Time\n[hh:mm:ss.ms]", "Track\nNumber", "Call\n    Sign    ", "ICAO\nAddress", "Mode\n  3/A  ", "Message\n               Type               ", "Target Report\n    Descriptor    ", "WGS84 Coordinates\n(Lat||Lon) [º]", "Polar Coordinates\n(Rho||Theta) [NM||º]", "Cartesian Coordinates\n(x||y) [NM]", "Polar Track Velocity\n(GS||TA) [kt||º]", "Cartesian Track Velocity\n(Vx||Vy) [m/s]", "Acceleration\n(Ax||Ay) [m/s^2]",
            "Flight\n    Level    ", "Geometric\nAltitude [ft]", "Barometric\n           Altitude [FL]           ", "Selected\nAltitude [ft]", "Barometric Vertical\nRate [ft/min]", "Geometric Vertical\nRate [ft/min]", "Mode 3/A Code\nConfidence Indicator", "Mode C\nConfidence Indicator", "Antenna Rotation\nPeriod [s]", "Service\nID", "Radar Plot\nCharacteristics", "Message\nAmplitude [dBm]", "Sector\nNumber [º]", "Vector Qualifier\n(Intensity||Shading) [-||º]", "Processing Status\n (f||R||Q) [-]",
            "Total Number of\nWeather Vectors", "Target Size and Orientation \n (lenght||orientation||width) [m||º||m]", "Velocity\nAccuracy", "WGS84 Coordinates\nHigh Res (Lat||Lon)[º]", "Time of Applicability for\nPosition [hh:mm:ss.ms]", "Time of Msg Rx of\nPosition [hh:mm:ss.ms]", "Time of Msg Rx of\nVelocity [hh:mm:ss.ms]", "Receiver\nID", "Emitter\n                       Category                       ", "Warning\nErrors", "Track\n       Status       ", "System\n       Status       ",
            "Sequence of\nPolar Vectors", "Link\n   Technology   ", "Quality\n    Indicators    ", "MOPS\n      Version      ", "Target\n       Status       ", "Aircraft Operational\nStatus", "Surface Capabilities\n& Characteristics", "Data\n        Ages        ", "System Configuration\n   and Status   ", "System Processing\n   Mode   ", "Mode S\n    MB Data    ", "ACAS Capability &\nFlight Status", "Aircraft Derived\nData", "System Track\n  Update Ages  ", "Mode of\n    Movement    ", "Flight Plan\n  Related Data  ",
            "Measured\n   Information   ", "Figure\n      of Merit      ", "Mode 2", "Radar Doppler\n   Speed [NM/s]   ", "Received Power\n [dBm]", "   Mode 2   \nConfidence Indicator", "Presence of\n X-Pulse ", "Station Configuration\n   Status   ", "Station Processing\n   Mode   ", "Message Count\n   Values   ", "Dynamic Window\n(Rho||Theta) [NM||º]", "Collimation Error\n(Range||Azimuth) [NM||º]", "Sequence of\nCartesian Vectors", "Contour Identifier\n(Intensity||CNS) [-]", "Sequence of\nContour Points",
            "Sequence of\nWeather Vectors", "Vehicle\nFleet ID", "Pre-programmed\nMessage", "STD Deviation of Position\n(σx||σy||σxy)[m||m||m^2]", "   Presence   ", "Amplitude of\nprimary plot", "Roll Angle [º]", "Air Speed \n (IAS ó MACH)[kt||-]", "True Air\nSpeed [kt]", "Magnetic Heading \n [º]", "Rate of\nturn [º/s]", "Time of Day\nAcurracy [s]", "Met\nInformation", "Final Selected\nAltitude [ft]", "Trajectory\nIntent", "Time of Applicability for\nVelocity [hh:mm:ss.ms]",
            "Time of Msg Rx of Position\nHigh Precision [hh:mm:ss.ms]", "Time of Msg Rx of Velocity\nHigh Precision [hh:mm:ss.ms]", "ACAS Res Advisory\nReport", "Data\nFilter", "3D-Position\n(H||Lat||Lon) [m||º||º]", "Track Quality\n(σx||σy||σv||σH)[NM||NM||NM/s||º]", "3D Radar Measured\nHeight [ft]", "Mode 1", "   Mode 1   \nConfidence Indicator", "Mode 5\nData Reports", "Composed\nTrack Number", "Estimated\nAccuracies",};

        public AsterixData()
        {
            // Filling the column header with all the data items
            for (int k = 0; k < FRNinfoCATs.Count; k++)
            { tablaCATs.Columns.Add(FRNinfoCATs[k]); filledDataItems.Add(false); }
        }

        public void Clear()
        {
            this.listaCATs = new List<CATs>();
            this.tablaCATs = new DataTable();
            this.FlightList = new List<Flight>();
            this.CATsList = new List<string>();
            this.DSIList = new List<string>();
            this.SensorList = new List<string>();
            this.CallsignList = new List<string>();
            this.TrackNumberList = new List<string>();
            this.filledDataItems = new List<bool>();
            this.messagesCAT01 = 0; this.messagesCAT02 = 0; this.messagesCAT08 = 0; this.messagesCAT10 = 0; this.messagesCAT21 = 0; this.messagesCAT34 = 0; this.messagesCAT48 = 0; this.messagesCAT62 = 0;
            this.packetNumber = 1; this.rowPosition = 0;
            // Filling the column header with all the data items
            for (int k = 0; k < FRNinfoCATs.Count; k++)
            { tablaCATs.Columns.Add(FRNinfoCATs[k]); filledDataItems.Add(false); }
        }
        public void decodeRadarCSV(string csv)
        {
            
            string[] csvText = csv.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            csvText = csvText.Skip(1).ToArray();
            foreach (string csvLine in csvText)
            {
                string[] csvData = csvLine.Split(';');
                if (csvData[0] != "")
                {
                    RadarStation radarInfo = new RadarStation();
                    radarInfo.radarStation = csvData[0];
                    radarInfo.SASS = csvData[1];
                    radarInfo.property = csvData[2];
                    radarInfo.use = csvData[3];
                    radarInfo.type = csvData[4];
                    string[] lat = csvData[5].Split('/')[0].Split(' ');
                    radarInfo.lat = Convert.ToInt32(lat[0]) + Convert.ToInt32(lat[1]) / 60.0 + Convert.ToDouble(lat[2].Remove(lat[2].Length - 1)) / 3600.0;
                    if (lat[2].EndsWith("S"))
                        radarInfo.lat = -radarInfo.lat;
                    string[] lon = csvData[5].Split('/')[1].Split(' ');
                    radarInfo.lon = Convert.ToInt32(lon[1]) + Convert.ToInt32(lon[2]) / 60.0 + Convert.ToDouble(lon[3].Remove(lon[3].Length - 1)) / 3600.0;
                    if (lon[3].EndsWith("W"))
                        radarInfo.lon = -radarInfo.lon;
                    radarInfo.UTMzone = csvData[6];
                    string hemisphere = "N";
                    if (radarInfo.UTMzone.Last() <= 'N')
                        hemisphere = "S";
                    (radarInfo.UTMeasting, radarInfo.UTMnorthing) = CATs.LLA2UTM(radarInfo.lon, radarInfo.lat, hemisphere);
                    radarInfo.sac_sic = csvData[7].PadLeft(3, '0') + "/" + csvData[8].PadLeft(3, '0');
                    this.RadarStationList.Add(radarInfo);
                }
            }
        }
    }
}
