using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using FlightDataItems;

// Decode the messages of all categories. Fill in each data item according to the Asterix specification book
namespace ClassLibrary
{
    public class CATs
    {
        AsterixData data;
        // Common variables to all CATs
        public string packetNumber;
        public string category;
        public int length;
        public string SAC;
        public string SIC;
        public string sensor = "N/A";
        public List<string> Message = new List<string>();
        public List<string> defaultFRN = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "fx", "8", "9", "10", "11", "12", "13", "14", "fx", "15", "16", "17", "18", "19", "20", "21", "fx", "22", "23", "24", "25", "26", "27", "28", "fx", "29", "30", "31", "32", "33", "34", "35", "fx", "36", "37", "38", "39", "40", "41", "42", "fx", "43", "44", "45", "46", "47", "48", "49", "fx" };
        public List<string> FRNitems = new List<string>();
        List<string> BinList = new List<string>();
        public int firstIndex = 3;
        int FRN;
        Boolean fx = true;
        public DataRow row;
        private string moreInfo = "Click to see info";
        public string typeTarget = "N/A";
        public Boolean timeFounded = false;
        public int numberOftruncatedTimes;
        // Number of octets of each data item of each CAT
        public List<int> OctetsDataItemsCAT01 = new List<int>() { 2, 1, 4, 2, 2, 1, 2, 2, 1, 1, 2, 4, 2, 1, 1 };
        public List<int> OctetsDataItemsCAT02 = new List<int>() { 2, 1, 1, 3, 2, 1, 1, 2, 8, 2, 1 };
        public List<int> OctetsDataItemsCAT08 = new List<int>() { 2, 1, 1, 3, 4, 2, 2, 3, 3, 1, 2, 4 };
        public List<int> OctetsDataItemsCAT10 = new List<int>() { 2, 1, 1, 3, 8, 4, 4, 4, 4, 2, 1, 2, 3, 7, 8, 1, 2, 2, 1, 1, 1, 4, 2, 1, 2 };
        public List<int> OctetsDataItemsCAT21V023 = new List<int>() { 2, 2, 3, 6, 3, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 4, 1, 6, 1, 1, 1, 1, 1, 2, 2, 1 };
        public List<int> OctetsDataItemsCAT21V21 = new List<int>() { 2, 1, 2, 1, 3, 6, 8, 3, 2, 2, 3, 3, 4, 3, 4, 2, 1, 1, 2, 2, 2, 2, 1, 2, 2, 4, 2, 3, 6, 1, 1, 2, 2, 1, 1, 1, 2, 1, 8, 7, 1, 4 };
        public List<int> OctetsDataItemsCAT34 = new List<int>() { 2, 1, 3, 1, 2, 1, 1, 2, 8, 1, 8, 2 };
        public List<int> OctetsDataItemsCAT48 = new List<int>() { 2, 3, 1, 4, 2, 2, 1, 3, 6, 8, 2, 4, 4, 1, 4, 1, 2, 4, 2, 1, 2, 7, 1, 2, 1, 2 };
        public List<int> OctetsDataItemsCAT62 = new List<int>() { 2, 0, 1, 3, 8, 6, 4, 2, 2, 7, 1, 2, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 2, 3, 1, 1 };

        // Data Items common in different CATs
        public TimeOfDay timeOfDay = new TimeOfDay();
        public string dataSourceIdentifier = "N/A";
        public string messageType = "N/A";
        public string trackNumber = "N/A";
        public TargetIdentification callsign = new TargetIdentification();
        public string ICAOAdress = "N/A";
        public PositionWGS84Coordinates positionWGS84 = new PositionWGS84Coordinates();
        public PositionPolarCoordinates measuredPositionPolar = new PositionPolarCoordinates();
        public PositionCartesianCoordinates positionCartesian = new PositionCartesianCoordinates();
        public TrackVelocityPolarCoordinates trackVelocityPolar = new TrackVelocityPolarCoordinates();
        public TrackVelocityCartesianCoordinates trackVelocityCartesian = new TrackVelocityCartesianCoordinates();
        public CalculatedAcceleration calculatedAcceleration = new CalculatedAcceleration();
        public string geometricAltitude = "N/A";
        public TargetSizeAndOrientation targetSizeAndOrientation = new TargetSizeAndOrientation();
        public string vehicleFleetIdentification = "N/A";
        public string mode3AConfidenceIndicator = "N/A";
        public ModeC_ConfidenceIndicator modeC_ConfidenceIndicator = new ModeC_ConfidenceIndicator();
        public RadialDopplerSpeed radialDopplerSpeed = new RadialDopplerSpeed();
        public Mode2 mode2 = new Mode2();
        public string mode2ConfidenceIndicator = "N/A";
        public FlightLevel flightLevel = new FlightLevel();
        public Mode3A mode3A = new Mode3A();
        public ModeS_MBData modeS_MBData = new ModeS_MBData();
        public string warningConditions = "N/A";
        public string stationConfigurationStatus = "N/A";
        public string sectorNumber = "N/A";
        public string antennaRotationPeriod = "N/A";
        public DynamicWindow dynamicWindow = new DynamicWindow();
        public CollimationError collimationError = new CollimationError();

        // Data Items only in CAT01 (Order of UAP for Plot Information)
        public TargetReportDescriptorCAT01 targetReportDescriptorCAT01 = new TargetReportDescriptorCAT01();
        public string radarPlotCharacteristics_str = "N/A";
        public string radialDopplerSpeed_str = "N/A";
        public string receivedPower = "N/A";
        public PresenceX_Pulse presenceX_Pulse = new PresenceX_Pulse();

        // Data Items only in CAT02
        public string stationProcessingMode = "N/A";
        public PlotCountValues plotCountValues = new PlotCountValues();

        // Data Items only in CAT08
        public VectorQualifier vectorQualifier = new VectorQualifier();
        public SequenceCartesianVectors sequenceCartesianVectors = new SequenceCartesianVectors();
        public SequencePolarVectors sequencePolarVectors = new SequencePolarVectors();
        public ContourIdentifier contourIdentifier = new ContourIdentifier();
        public SequenceContourPoints sequenceContourPoints = new SequenceContourPoints();
        public ProcessingStatus processingStatus = new ProcessingStatus();
        public string totalNumberWeatherVectors = "N/A";
        public SequenceWeatherVectors sequenceWeatherVectors = new SequenceWeatherVectors();

        // Data Items only in CAT10
        public Boolean SMR = false;
        public Boolean MLAT = false;
        public TargetReportDescriptorCAT10 targetReportDescriptorCAT10 = new TargetReportDescriptorCAT10();
        public TrackStatusCAT10 trackStatusCAT10 = new TrackStatusCAT10();
        public string measuredHeight = "N/A";
        public SystemStatus systemStatus = new SystemStatus();
        public string preprogrammedMessage = "N/A";
        public StandardDeviationPosition standardDeviationPosition = new StandardDeviationPosition();
        public Presence presence = new Presence();
        public string amplitudePrimaryPlot = "N/A";

        // Data Items only in CAT21
        public Boolean V21 = false;
        public Boolean V023 = false;
        //Common in v0.23 y v2.1:
        public string rollAngle = "N/A";
        public AirSpeed airSpeed = new AirSpeed();
        public string trueAirspeed = "N/A";
        public string magneticHeading = "N/A";
        public string barometricVerticalRate = "N/A";
        public string geometricVerticalRate = "N/A";
        public GroundVector groundVector = new GroundVector();
        public RateOfTurn rateOfTurnV023 = new RateOfTurn();
        public string targetStatusV023 = "N/A";
        public string emitterCategory = "N/A";
        public MetInformation metInformation = new MetInformation();
        public SelectedAltitude selectedAltitude = new SelectedAltitude();
        public FinalSelectedAltitude finalSelectedAltitude = new FinalSelectedAltitude();
        public TrajectoryIntentStatus trajectoryIntentStatus = new TrajectoryIntentStatus();
        public TrajectoryIntentData trajectoryIntentData = new TrajectoryIntentData();

        //Data Items only in version v0.23:
        public TargetReportDescriptorCAT21v023 targetReportDescriptorCAT21V023 = new TargetReportDescriptorCAT21v023();
        public FigureOfMerit figureOfMerit = new FigureOfMerit();
        public LinkTechnololy linkTechnology = new LinkTechnololy();
        public string velocityAccuracy = "N/A";
        public string timeOfDayAccuracy = "N/A";

        //Data Items only in version v2.1:
        public TargetReportDescriptorCAT21v21 targetReportDescriptorCAT21V21 = new TargetReportDescriptorCAT21v21();
        public string serviceIdentification = "N/A";
        public TimeOfDay timeOfApplicabilityPosition = new TimeOfDay();
        public PositionWGS84Coordinates positionWGS84HighResolution = new PositionWGS84Coordinates();
        public TimeOfDay timeOfApplicabilityVelocity = new TimeOfDay();
        public TimeOfDay timeOfReceptionPosition = new TimeOfDay();
        public TimeOfDay timeOfReceptionPositionHighPrecision = new TimeOfDay();
        public TimeOfDay timeOfReceptionVelocity = new TimeOfDay();
        public TimeOfDay timeOfReceptionVelocityHighPrecision = new TimeOfDay();
        public QualityIndicators qualityIndicators = new QualityIndicators();
        public MOPSversion MOPSversion = new MOPSversion();
        public TargetStatus targetStatusV21 = new TargetStatus();
        public string rateOfTurnV21 = "N/A";
        public string serviceManagement = "N/A";
        public AircraftOperationalStatus aircraftOperationalStatus = new AircraftOperationalStatus();
        public SurfaceCapabilitiesAndCharacteristics surfaceCapabilitiesAndCharacteristics = new SurfaceCapabilitiesAndCharacteristics();
        public string messageAmplitude = "N/A";
        public ACAS_ResolutionAdvisoryReport ACASresolutionAdvisoryReport = new ACAS_ResolutionAdvisoryReport();
        public string receiverID = "N/A";
        public DataAges dataAges = new DataAges();
        public List<string> dataAgesFRN = new List<string>();
        
        // Data Items only in CAT34
        public SystemConfigurationStatus systemConfigurationStatus = new SystemConfigurationStatus();
        public SystemProcessingMode systemProcessingMode = new SystemProcessingMode();
        public MessageCountValues messageCountValues = new MessageCountValues();
        public string dataFilter = "N/A";
        public Position3D position3D = new Position3D();

        // Data Items only in CAT48
        public TargetReportDescriptorCAT48 targetReportDescriptorCAT48 = new TargetReportDescriptorCAT48();
        public RadarPlotCharacteristics radarPlotCharacteristics = new RadarPlotCharacteristics();
        public TrackStatusCAT48 trackStatusCAT48 = new TrackStatusCAT48();
        public TrackQuality trackQuality = new TrackQuality();
        public string measuredHeight3DRadar = "N/A";
        public ACAS_CapabilitiesFlightStatus ACAS_CapabilitiesFlightStatus = new ACAS_CapabilitiesFlightStatus();
        public ACAS_ResolutionAdvisoryReport ACAS_ResolutionAdvisoryReport = new ACAS_ResolutionAdvisoryReport();
        public Mode1 mode1 = new Mode1();
        public string mode1ConfidenceIndicator = "N/A";

        // Data Items only in CAT62
        public AircraftDerivedData aircraftDerivedData = new AircraftDerivedData();
        public TrackStatusCAT62 trackStatusCAT62 = new TrackStatusCAT62();
        public SystemTrackUpdateAges systemTrackUpdateAges = new SystemTrackUpdateAges();
        public ModeOfMovement modeOfMovement = new ModeOfMovement();
        public TrackDataAges trackDataAges = new TrackDataAges();
        public string barometricAltitude = "N/A";
        public string rateOfClimb = "N/A";
        public FlightPlanRelatedData flightPlanRelatedData = new FlightPlanRelatedData();
        public Mode5DataReports mode5DataReports = new Mode5DataReports();
        public string mode2_str = "N/A";
        public ComposedTrackNumber composedTrackNumber = new ComposedTrackNumber();
        public EstimatedAccuracies estimatedAccuracies = new EstimatedAccuracies();
        public MeasuredInformation measuredInformation = new MeasuredInformation();

        // Constructor of CATs class passing as parameters the message to be decoded and the AsterixData class
        public CATs(List<string> message, AsterixData data)
        { this.Message = message; this.length = this.Message.Count; this.data = data; }  // HEX message to get decodified

        // Function that converts a string of HEX to a list of Binary values
        public static List<string> HexToBinary(string HexValue)
        {
            List<string> BinaryList = new List<string>();
            foreach (char bit in Convert.ToString(Convert.ToInt32(HexValue, 16), 2).PadLeft(8, '0'))
                BinaryList.Add(Char.ToString(bit));
            return BinaryList;
        }

        // Function that converts a binary string to a decimal doing the complement 2
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

        // Function that decodes the different CATs by calling the respective decoding functions of the categories
        public void DecodeCATs()
        {
            // Fill all columns of the row with N/A
            for (int i = 0; i < this.row.Table.Columns.Count; i++)
                this.row[i] = "N/A";
            this.row[0] = Convert.ToString(packetNumber);
            this.row[1] = this.category; data.filledDataItems[1] = true;
            BinList = new List<string>();
            BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
            this.firstIndex += 1;
            fx = true;
            while (fx)
            {
                if (BinList[BinList.Count - 1] == "1")
                {
                    BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                    this.firstIndex += 1;
                }
                else
                    fx = false;
            }
            FRNitems = new List<string>();
            for (int i = 0; i < BinList.Count(); i++)
            {
                if (BinList[i] == "1")
                {
                    if (defaultFRN[i] != "fx")
                        this.FRNitems.Add(defaultFRN[i]);
                }
            }
            for (int item = 0; item < FRNitems.Count; item++)
            {
                FRN = Convert.ToInt32(FRNitems[item]);
                BinList = new List<string>();
                if(this.category == "01")
                { DecodeCAT01(); }
                else if(this.category == "02")
                { DecodeCAT02(); }
                else if(this.category == "08")
                { DecodeCAT08(); }
                else if(this.category == "10")
                { DecodeCAT10(); }
                else if(this.category == "21")
                { DecodeCAT21(); }
                else if(this.category == "34")
                { DecodeCAT34(); }
                else if(this.category == "48")
                { DecodeCAT48(); }
                else if (this.category == "62")
                { DecodeCAT62(); }
                else 
                { while (this.firstIndex < this.Message.Count)
                        this.firstIndex++; 
                }
            }
        }

        public void obtainTimeUTC()
        {
            try 
            {
                BinList = new List<string>();
                BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                this.firstIndex += 1;
                fx = true;
                while (fx)
                {
                    if (BinList[BinList.Count - 1] == "1")
                    {
                        BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                        this.firstIndex += 1;
                    }
                    else
                        fx = false;
                }
                FRNitems = new List<string>();
                for (int i = 0; i < BinList.Count(); i++)
                {
                    if (BinList[i] == "1")
                    {
                        if (defaultFRN[i] != "fx")
                            this.FRNitems.Add(defaultFRN[i]);
                    }
                }
                for (int item = 0; item < FRNitems.Count; item++)
                {
                    FRN = Convert.ToInt32(FRNitems[item]);
                    BinList = new List<string>();
                    if (this.category == "01")
                    {
                        obtainBinListCAT01();
                        if (FRN == 7)
                        { timeFounded = true; this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes); break; }
                    }
                    else if (this.category == "02")
                    {
                        obtainBinListCAT02();
                        if (FRN == 4)
                        { timeFounded = true; this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes); break; }
                    }
                    else if (this.category == "08")
                    {
                        obtainBinListCAT08();
                        if (FRN == 8)
                        { timeFounded = true; this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes); break; }
                    }
                    else if (this.category == "10")
                    {
                        obtainBinListCAT10();
                        if (FRN == 4)
                        { timeFounded = true; this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes); break; }
                    }
                    else if (this.category == "21")
                    {
                        obtainBinListCAT21();
                        if (this.V023 && FRN == 3)
                        { timeFounded = true; this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes); break; }
                        if (this.V21 && FRN == 28)
                        { timeFounded = true; this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes); break; }
                    }
                    else if (this.category == "34")
                    {
                        obtainBinListCAT34();
                        if (FRN == 3)
                        { timeFounded = true; this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes); break; }
                    }
                    else if (this.category == "48")
                    {
                        obtainBinListCAT48();
                        if (FRN == 2)
                        { timeFounded = true; this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes); break; }
                    }
                    else if (this.category == "62")
                    {
                        obtainBinListCAT62();
                        if (FRN == 4)
                        { timeFounded = true; this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes); break; }
                    }
                    else
                    {
                        while (this.firstIndex < this.Message.Count)
                            this.firstIndex++;
                    }
                }
            }
            catch { }
            
        }

        public void obtainBinListCAT01()
        {
            if (FRN == 2 || FRN == 6 || FRN == 14) // Data Items with variable octets lenght (fx)
            {
                BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                this.firstIndex += 1;
                fx = true;
                while (fx)
                {
                    if (BinList[BinList.Count - 1] == "1")
                    { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                    else
                        fx = false;
                }
            }
            else // Data Items with fixed octets lenght
            {
                for (int octets = 0; octets < OctetsDataItemsCAT01[FRN - 1]; octets++)
                { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
            }
        }

        // Function that decodes all the CAT01 Data Items
        public void DecodeCAT01()
        {
            obtainBinListCAT01();
            if (FRN == 1)
            {
                this.SAC = Convert.ToInt32(string.Join("", BinList.GetRange(0, 8)), 2).ToString().PadLeft(3, '0');
                this.SIC = Convert.ToInt32(string.Join("", BinList.GetRange(8, 8)), 2).ToString().PadLeft(3, '0');
                this.dataSourceIdentifier = string.Join("/", this.SAC, this.SIC);
                this.sensor = data.RadarStationList.Find(r => r.sac_sic == this.dataSourceIdentifier && r.type != "ADS-B").radarStation;
                this.row[2] = this.dataSourceIdentifier; data.filledDataItems[2] = true;
                this.row[3] = this.sensor; data.filledDataItems[3] = true;
            }
            else if (FRN == 2)
            {
                this.targetReportDescriptorCAT01 = new TargetReportDescriptorCAT01(BinList);
                this.row[10] = moreInfo; data.filledDataItems[10] = true;
            }
            else if (FRN == 3)
            {
                this.measuredPositionPolar = new PositionPolarCoordinates(BinList, category);
                this.positionCartesian.x = this.measuredPositionPolar.rho * Math.Sin(this.measuredPositionPolar.theta * Math.PI / 180.0);
                this.positionCartesian.y = this.measuredPositionPolar.rho * Math.Cos(this.measuredPositionPolar.theta * Math.PI / 180.0);
                this.row[12] = Math.Round(this.measuredPositionPolar.rho, 3) + " || " + Math.Round(this.measuredPositionPolar.theta, 3);
                data.filledDataItems[12] = true;
                UTM2WGS84(data.RadarStationList.Find(r => r.radarStation == this.sensor).UTMzone, data.RadarStationList.Find(r => r.radarStation == this.sensor).UTMnorthing, data.RadarStationList.Find(r => r.radarStation == this.sensor).UTMeasting);
            }
            else if (FRN == 4)
            {
                this.mode3A = new Mode3A(BinList, category);
                this.row[8] = this.mode3A.Reply + " *"; data.filledDataItems[8] = true;
            }
            else if (FRN == 5)
            {
                this.flightLevel = new FlightLevel(BinList);
                this.row[17] = "FL" + this.flightLevel.FL + " *"; data.filledDataItems[17] = true;
            }
            else if (FRN == 6)
            {
                this.radarPlotCharacteristics_str = Convert.ToInt32(string.Join("", BinList.GetRange(0, 7)), 2).ToString();
                this.row[27] = this.radarPlotCharacteristics_str + " replies"; data.filledDataItems[27] = true;
            }
            else if (FRN == 7)
            {
                this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                this.row[4] = this.timeOfDay.timeUTC; data.filledDataItems[4] = true;
            }
            else if (FRN == 8)
            {
                this.mode2 = new Mode2(BinList);
                this.row[62] = this.mode2.Reply + " *"; data.filledDataItems[62] = true;
            }
            else if (FRN == 9)
            {
                this.radialDopplerSpeed_str = (binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count) * Math.Pow(2, -14)).ToString(); // [NM/s]
                this.row[63] = this.radialDopplerSpeed_str; data.filledDataItems[63] = true;
            }
            else if (FRN == 10)
            {
                this.receivedPower = binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count).ToString(); // [dBm]
                this.row[64] = this.receivedPower; data.filledDataItems[64] = true;
            }
            else if (FRN == 11)
            {
                this.mode3AConfidenceIndicator = Convert.ToString(Convert.ToInt32(string.Join("", BinList), 2), 8);
                this.row[23] = mode3AConfidenceIndicator; data.filledDataItems[23] = true;
            }
            else if (FRN == 12)
            {
                this.modeC_ConfidenceIndicator = new ModeC_ConfidenceIndicator(BinList);
                this.row[24] = modeC_ConfidenceIndicator.grayHeight + "/" + modeC_ConfidenceIndicator.qualityPulse;
                data.filledDataItems[24] = true;
            }
            else if (FRN == 13)
            {
                this.mode2ConfidenceIndicator = Convert.ToString(Convert.ToInt32(string.Join("", BinList.GetRange(4, 12)), 2), 8);
                this.row[65] = mode2ConfidenceIndicator; data.filledDataItems[65] = true;
            }
            else if (FRN == 14)
            {
                List<string> defaultWC = new List<string>() { "No warning nor error condition", "Garbled reply", "Reflection", "Sidelobe reply", "Split plot", "Second time around reply", "Angels", "Terrestrial vehicles" };
                string warningConditions = "N/A";
                for (int octets = 0; octets < BinList.Count / 8; octets++)
                {
                    List<string> infoOctet = new List<string>();
                    for (int bit = 0; bit < 7; bit++)
                        infoOctet.Add(BinList[bit + octets * 8]);
                    if (Convert.ToInt32(string.Join("", infoOctet), 2) < 8)
                        warningConditions = defaultWC[Convert.ToInt32(string.Join("", infoOctet), 2)];
                    else if (Convert.ToInt32(string.Join("", infoOctet), 2) == 64)
                        warningConditions = "Possible wrong code in Mode-3/A";
                    else if (Convert.ToInt32(string.Join("", infoOctet), 2) == 65)
                        warningConditions = "Possible wrong altitude information, transmitted when the Code C credibility check fails together with the Mode - C code in binary notation";
                    else if (Convert.ToInt32(string.Join("", infoOctet), 2) == 66)
                        warningConditions = "Possible phantom MSSR plot";
                    else if (Convert.ToInt32(string.Join("", infoOctet), 2) == 80)
                        warningConditions = "Fixed PSR plot";
                    else if (Convert.ToInt32(string.Join("", infoOctet), 2) == 81)
                        warningConditions = "Slow PSR plot";
                    else if (Convert.ToInt32(string.Join("", infoOctet), 2) == 82)
                        warningConditions = "Low quality PSR plot";
                    if (this.warningConditions != "N/A")
                        this.warningConditions = this.warningConditions + "\n" + warningConditions;
                    else
                        this.warningConditions = warningConditions;
                }
                this.row[41] = this.warningConditions; data.filledDataItems[41] = true;
            }
            else if (FRN == 15)
            {
                this.presenceX_Pulse = new PresenceX_Pulse(BinList, category);
                this.row[66] = moreInfo; data.filledDataItems[66] = true;
            }
        }

        public void obtainBinListCAT02()
        {
            if (FRN == 6 || FRN == 7 || FRN == 11) // Data Items with variable octets lenght (fx)
            {
                BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                this.firstIndex += 1;
                fx = true;
                while (fx)
                {
                    if (BinList[BinList.Count - 1] == "1")
                    { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                    else
                        fx = false;
                }
            }
            else if (FRN == 8) // Data Items with variable octets lenght (REP)
            {
                BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                int REP = Convert.ToInt32(string.Join("", BinList), 2);
                this.firstIndex += 1;
                for (int i = 0; i < OctetsDataItemsCAT02[FRN - 1] * REP; i++)
                { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
            }
            else // Data Items with fixed octets lenght
            {
                for (int octets = 0; octets < OctetsDataItemsCAT02[FRN - 1]; octets++)
                { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
            }
        }

        // Function that decodes all the CAT02 Data Items
        public void DecodeCAT02()
        {
            obtainBinListCAT02();   
            if (FRN == 1)
            {
                this.SAC = Convert.ToInt32(string.Join("", BinList.GetRange(0, 8)), 2).ToString().PadLeft(3, '0');
                this.SIC = Convert.ToInt32(string.Join("", BinList.GetRange(8, 8)), 2).ToString().PadLeft(3, '0');
                this.dataSourceIdentifier = string.Join("/", this.SAC, this.SIC);
                this.sensor = data.RadarStationList.Find(r => r.sac_sic == this.dataSourceIdentifier && r.type != "ADS-B").radarStation;
                this.row[2] = this.dataSourceIdentifier; data.filledDataItems[2] = true;
                this.row[3] = this.sensor; data.filledDataItems[3] = true;
            }
            else if (FRN == 2)
            {
                List<string> defaultMT = new List<string>() { "N/A", "North marker message", "Sector crossing message", "South marker message", "N/A", "N/A", "N/A", "N/A", "Activation of blind zone filtering", "Stop of blind zone filtering" };
                this.messageType = defaultMT[Convert.ToInt32(string.Join("", BinList), 2)];
                this.row[9] = this.messageType; data.filledDataItems[9] = true;
            }
            else if (FRN == 3)
            {
                this.sectorNumber = (Convert.ToInt32(string.Join("", BinList), 2) * 360 / Math.Pow(2, 8)).ToString(); // [º];
                this.row[29] = this.sectorNumber; data.filledDataItems[29] = true;
            }
            else if (FRN == 4)
            {
                this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                this.row[4] = this.timeOfDay.timeUTC; data.filledDataItems[4] = true;
            }
            else if (FRN == 5)
            {
                this.antennaRotationPeriod = (Convert.ToInt32(string.Join("", BinList), 2) * 1 / 128.0).ToString(); // [s];
                this.row[25] = this.antennaRotationPeriod; data.filledDataItems[25] = true;
            }
            else if (FRN == 6)
            {
                this.stationConfigurationStatus = Convert.ToInt32(string.Join("", BinList.GetRange(0, 7)), 2).ToString();
                this.row[67] = this.stationConfigurationStatus; data.filledDataItems[67] = true;
            }
            else if (FRN == 7)
            {
                this.stationProcessingMode = Convert.ToInt32(string.Join("", BinList.GetRange(0, 7)), 2).ToString();
                this.row[68] = this.stationProcessingMode;
                data.filledDataItems[68] = true;
            }
            else if (FRN == 8)
            {
                this.plotCountValues = new PlotCountValues(BinList);
                this.row[69] = this.plotCountValues.REP + " count value(s) *"; data.filledDataItems[69] = true;
            }
            else if (FRN == 9)
            {
                this.dynamicWindow = new DynamicWindow(BinList, category);
                this.row[70] = this.dynamicWindow.rhoStart + "-" + this.dynamicWindow.rhoEnd + " || " + this.dynamicWindow.thetaStart + "-" + this.dynamicWindow.thetaEnd;
                data.filledDataItems[70] = true;
            }
            else if (FRN == 10)
            {
                this.collimationError = new CollimationError(BinList, category);
                this.row[71] = this.collimationError.rangeError + " || " + this.collimationError.azimuthError;
                data.filledDataItems[71] = true;
            }
            else if (FRN == 11)
            {
                this.warningConditions = Convert.ToString(Convert.ToInt32(string.Join("", BinList), 2));
                this.row[41] = this.warningConditions; data.filledDataItems[41] = true;
            }
        }

        public void obtainBinListCAT08()
        {
            if (FRN == 3 || FRN == 9 || FRN == 10) // Data Items with variable octets lenght (fx)
            {
                for (int octets = 0; octets < OctetsDataItemsCAT08[FRN - 1]; octets++)
                { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                fx = true;
                while (fx)
                {
                    if (BinList[BinList.Count - 1] == "1")
                    { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                    else
                        fx = false;
                }
            }
            else if (FRN == 4 || FRN == 5 || FRN == 7 || FRN == 12) // Data Items with variable octets lenght (REP)
            {
                BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                int REP = Convert.ToInt32(string.Join("", BinList), 2);
                this.firstIndex += 1;
                for (int i = 0; i < OctetsDataItemsCAT08[FRN - 1] * REP; i++)
                { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
            }
            else // Data Items with fixed octets lenght
            {
                for (int octets = 0; octets < OctetsDataItemsCAT08[FRN - 1]; octets++)
                { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
            }
        }

        // Function that decodes all the CAT08 Data Items
        public void DecodeCAT08()
        {
            obtainBinListCAT08();
            if (FRN == 1)
            {
                this.SAC = Convert.ToInt32(string.Join("", BinList.GetRange(0, 8)), 2).ToString().PadLeft(3, '0');
                this.SIC = Convert.ToInt32(string.Join("", BinList.GetRange(8, 8)), 2).ToString().PadLeft(3, '0');
                this.dataSourceIdentifier = string.Join("/", this.SAC, this.SIC);
                this.sensor = data.RadarStationList.Find(r => r.sac_sic == this.dataSourceIdentifier && r.type != "ADS-B").radarStation;
                this.row[2] = this.dataSourceIdentifier; data.filledDataItems[2] = true;
                this.row[3] = this.sensor; data.filledDataItems[3] = true;
            }
            else if (FRN == 2)
            {
                List<string> defaultMT = new List<string>() { "N/A", "Polar vector", "Cartesian vector of start point/ length", "Contour record", " Cartesian start point and end point vector" };
                if (Convert.ToInt32(string.Join("", BinList), 2) < 5)
                    this.messageType = defaultMT[Convert.ToInt32(string.Join("", BinList), 2)];
                else if (Convert.ToInt32(string.Join("", BinList), 2) == 254)
                    this.messageType = "SOP message";
                else if (Convert.ToInt32(string.Join("", BinList), 2) == 255)
                    this.messageType = "EOP message";
                else
                    this.messageType = "N/A";
                this.row[9] = this.messageType; data.filledDataItems[9] = true;
            }
            else if (FRN == 3)
            {
                this.vectorQualifier = new VectorQualifier(BinList);
                this.row[30] = this.vectorQualifier.intensityLevel + " || " + this.vectorQualifier.shadingOrientation + " *";
                data.filledDataItems[30] = true;
            }
            else if (FRN == 4)
            {
                this.sequenceCartesianVectors = new SequenceCartesianVectors(BinList);
                this.row[72] = this.sequenceCartesianVectors.REP + " vectors *";
                data.filledDataItems[72] = true;
            }
            else if (FRN == 5)
            {
                this.sequencePolarVectors = new SequencePolarVectors(BinList);
                this.row[44] = this.sequencePolarVectors.REP + " vectors *";
                data.filledDataItems[44] = true;
            }
            else if (FRN == 6)
            {
                this.contourIdentifier = new ContourIdentifier(BinList);
                this.row[73] = this.contourIdentifier.intensityLevel + " || " + this.contourIdentifier.CSN + " *";
                data.filledDataItems[73] = true;
            }
            else if (FRN == 7)
            {
                this.sequenceContourPoints = new SequenceContourPoints(BinList);
                this.row[74] = this.sequenceContourPoints.REP + " points *"; data.filledDataItems[74] = true;
            }
            else if (FRN == 8)
            {
                this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                this.row[4] = this.timeOfDay.timeUTC; data.filledDataItems[4] = true;
            }
            else if (FRN == 9)
            {
                this.processingStatus = new ProcessingStatus(BinList);
                this.row[31] = this.processingStatus.f + " || " + this.processingStatus.R + " || " + this.processingStatus.Q;
                data.filledDataItems[31] = true;
            }
            else if (FRN == 10)
            {
                this.stationConfigurationStatus = Convert.ToInt32(string.Join("", BinList.GetRange(0, 7)), 2).ToString();
                this.row[66] = this.stationConfigurationStatus;
                data.filledDataItems[66] = true;
            }
            else if (FRN == 11)
            {
                this.totalNumberWeatherVectors = Convert.ToInt32(string.Join("", BinList.GetRange(0, 16)), 2).ToString();
                this.row[32] = this.totalNumberWeatherVectors + " vectors"; data.filledDataItems[32] = true;
            }
            else if (FRN == 12)
            {
                this.sequenceWeatherVectors = new SequenceWeatherVectors(BinList);
                this.row[75] = this.sequenceWeatherVectors.REP + " vectors *"; data.filledDataItems[75] = true;
            }
        }

        public void obtainBinListCAT10()
        {
            if (FRN == 3 || FRN == 11 || FRN == 19) // Data Items with variable octets lenght (fx)
            {
                BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                this.firstIndex += 1;
                fx = true;
                while (fx)
                {
                    if (BinList[BinList.Count - 1] == "1")
                    { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                    else
                        fx = false;
                }
            }
            else if (FRN == 15 || FRN == 23) // Data Items with variable octets lenght (REP)
            {
                BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                int REP = Convert.ToInt32(string.Join("", BinList), 2);
                this.firstIndex += 1;
                for (int i = 0; i < OctetsDataItemsCAT10[FRN - 1] * REP; i++)
                { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
            }
            else // Data Items with fixed octets lenght
            {
                for (int octets = 0; octets < OctetsDataItemsCAT10[FRN - 1]; octets++)
                {
                    if (FRN == 13) // Not needed to get converted to BIN
                        BinList.Add(this.Message[this.firstIndex]);
                    else
                        BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                    this.firstIndex += 1;
                }
            }
        }

        // Function that decodes all the CAT10 Data Items
        public void DecodeCAT10()
        {
            obtainBinListCAT10();
            if (FRN == 1)
            {
                this.SAC = Convert.ToInt32(string.Join("", BinList.GetRange(0, 8)), 2).ToString().PadLeft(3, '0');
                this.SIC = Convert.ToInt32(string.Join("", BinList.GetRange(8, 8)), 2).ToString().PadLeft(3, '0');
                this.dataSourceIdentifier = string.Join("/", this.SAC, this.SIC);
                this.sensor = data.RadarStationList.Find(r => r.sac_sic == this.dataSourceIdentifier && r.type != "ADS-B").radarStation;
                this.row[2] = this.dataSourceIdentifier; data.filledDataItems[2] = true;
                this.row[3] = this.sensor; data.filledDataItems[3] = true;
            }
            else if (FRN == 2)
            {
                List<string> defaultMT = new List<string>() { "Target Report", "Start of Update Cycle", "Periodic Status Message", "Event-triggered Status Message" };
                this.messageType = defaultMT[Convert.ToInt32(string.Join("", BinList), 2) - 1];
                this.row[9] = this.messageType; data.filledDataItems[9] = true;
            }
            else if (FRN == 3)
            {
                this.targetReportDescriptorCAT10 = new TargetReportDescriptorCAT10(BinList);
                if (this.targetReportDescriptorCAT10.TOT == "Aircraft")
                    typeTarget = "Aircraft";
                if (this.targetReportDescriptorCAT10.TOT == "Ground vehicle")
                    typeTarget = "Ground vehicle";
                this.row[10] = moreInfo; data.filledDataItems[10] = true;
            }
            else if (FRN == 4)
            {
                this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                this.row[4] = this.timeOfDay.timeUTC; data.filledDataItems[4] = true;
            }
            else if (FRN == 5)
            {
                this.positionWGS84 = new PositionWGS84Coordinates(BinList, this.category);
                this.row[11] = Math.Round(this.positionWGS84.latitude, 5) + " || " + Math.Round(this.positionWGS84.longitude, 5);
                data.filledDataItems[11] = true;
            }
            else if (FRN == 6)
            {
                this.measuredPositionPolar = new PositionPolarCoordinates(BinList, category);
                this.row[12] = Math.Round(this.measuredPositionPolar.rho, 3) + " || " + Math.Round(this.measuredPositionPolar.theta, 3);
                data.filledDataItems[12] = true;
            }
            else if (FRN == 7)
            {
                this.positionCartesian = new PositionCartesianCoordinates(BinList, category);
                this.row[13] = Math.Round(this.positionCartesian.x, 3) + " || " + Math.Round(this.positionCartesian.y, 3);
                data.filledDataItems[13] = true;
                UTM2WGS84(data.RadarStationList.Find(r => r.radarStation == this.sensor).UTMzone, data.RadarStationList.Find(r => r.radarStation == this.sensor).UTMnorthing, data.RadarStationList.Find(r => r.radarStation == this.sensor).UTMeasting);
            }
            else if (FRN == 8)
            {
                this.trackVelocityPolar = new TrackVelocityPolarCoordinates(BinList);
                this.row[14] = Math.Round(this.trackVelocityPolar.groundSpeed, 3) + " || " + Math.Round(this.trackVelocityPolar.trackAngle, 3);
                data.filledDataItems[14] = true;
            }
            else if (FRN == 9)
            {
                this.trackVelocityCartesian = new TrackVelocityCartesianCoordinates(BinList);
                this.row[15] = this.trackVelocityCartesian.Vx + " || " + this.trackVelocityCartesian.Vy;
                data.filledDataItems[15] = true;
            }
            else if (FRN == 10)
            {
                this.trackNumber = Convert.ToInt32(string.Join("", BinList), 2).ToString().PadLeft(4, '0');
                this.row[5] = this.trackNumber; data.filledDataItems[5] = true;
            }
            else if (FRN == 11)
            {
                this.trackStatusCAT10 = new TrackStatusCAT10(BinList);
                this.row[42] = moreInfo; data.filledDataItems[42] = true;
            }
            else if (FRN == 12)
            {
                this.mode3A = new Mode3A(BinList, category);
                this.row[8] = this.mode3A.Reply + " *"; data.filledDataItems[8] = true;
            }
            else if (FRN == 13)
            {
                this.ICAOAdress = string.Join("", BinList);
                this.row[7] = this.ICAOAdress; data.filledDataItems[7] = true;
            }
            else if (FRN == 14)
            {
                this.callsign = new TargetIdentification(BinList);
                this.row[6] = this.callsign.TargetID; data.filledDataItems[6] = true;
            }
            else if (FRN == 15)
            {
                this.modeS_MBData = new ModeS_MBData(BinList);
                this.row[54] = this.modeS_MBData.REP + " register(s) *"; data.filledDataItems[54] = true;
            }
            else if (FRN == 16)
            {
                List<string> DefaultVFI = new List<string>() { "Unknown", "ATC equipment maintenance", "Airport maintenance", "Fire", "Bird scarer", "Snow plough", "Runway sweeper", "Emergency", "Police", "Bus", "Tug (push/tow)", "Grass cutter", "Fuel", "Baggage", "Catering", "Aircraft maintenance", "Flyco (follow me)" };
                if (Convert.ToInt32(string.Join("", BinList), 2) < DefaultVFI.Count() - 1)
                    this.vehicleFleetIdentification = DefaultVFI[Convert.ToInt32(string.Join("", BinList), 2)];
                this.row[76] = this.vehicleFleetIdentification; data.filledDataItems[76] = true;
            }
            else if (FRN == 17)
            {
                this.flightLevel = new FlightLevel(BinList);
                this.row[17] = "FL" + this.flightLevel.FL + " *"; data.filledDataItems[17] = true;
            }
            else if (FRN == 18)
            {
                this.measuredHeight = (binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count()) * 6.25).ToString();
                this.row[18] = this.measuredHeight; data.filledDataItems[18] = true;
            }
            else if (FRN == 19)
            {
                this.targetSizeAndOrientation = new TargetSizeAndOrientation(BinList);
                this.row[33] = this.targetSizeAndOrientation.length + " || " + this.targetSizeAndOrientation.orientation + " || " + this.targetSizeAndOrientation.width;
                data.filledDataItems[33] = true;
            }
            else if (FRN == 20)
            {
                this.systemStatus = new SystemStatus(BinList);
                this.row[43] = moreInfo; data.filledDataItems[43] = true;
            }
            else if (FRN == 21)
            {
                List<string> defaultPreProgrammedMessage = new List<string>() {"No message", "Towing aircraft", "“Follow me” operation", "Runway check", "Emergency operation (fire, medical…)", "Work in progress (maintenance, birds scarer, sweepers…)" };
                this.preprogrammedMessage = defaultPreProgrammedMessage[Convert.ToInt32(string.Join("", BinList.GetRange(1, 7)), 2)]; ;
                this.row[77] = this.preprogrammedMessage; data.filledDataItems[77] = true; 
            }
            else if (FRN == 22)
            {
                this.standardDeviationPosition = new StandardDeviationPosition(BinList);
                this.row[78] = this.standardDeviationPosition.x + " || " + this.standardDeviationPosition.y + " || " + this.standardDeviationPosition.xy;
                data.filledDataItems[78] = true;
            }
            else if (FRN == 23)
            {
                this.presence = new Presence(BinList);
                this.row[79] = this.presence.REP + " value(s) *"; data.filledDataItems[79] = true;
            }
            else if (FRN == 24)
            {
                this.amplitudePrimaryPlot = Convert.ToString(Convert.ToInt32(string.Join("", BinList), 2));
                this.row[80] = this.amplitudePrimaryPlot;
                data.filledDataItems[80] = true;
            }
            else if (FRN == 25)
            {
                this.calculatedAcceleration = new CalculatedAcceleration(BinList);
                this.row[16] = this.calculatedAcceleration.Ax + " || " + this.calculatedAcceleration.Ay;
                data.filledDataItems[16] = true;
            }
        }

        public void obtainBinListCAT21()
        {
            if (FRN == 1)
            {
                BinList = new List<string>();
                for (int i = 0; i < 2; i++)
                    BinList.AddRange(HexToBinary(this.Message[this.firstIndex + i]));
                this.firstIndex += 2;
                this.SAC = Convert.ToInt32(string.Join("", BinList.GetRange(0, 8)), 2).ToString().PadLeft(3, '0');
                this.SIC = Convert.ToInt32(string.Join("", BinList.GetRange(8, 8)), 2).ToString().PadLeft(3, '0');
                if (this.SIC == "107" && this.firstIndex < 9)
                    this.V023 = true;
                else
                    this.V21 = true;
                this.dataSourceIdentifier = string.Join("/", this.SAC, this.SIC);
                this.sensor = data.RadarStationList.Find(r => r.sac_sic == this.dataSourceIdentifier && r.type == "ADS-B").radarStation;
            }
            if (V023)
            {
                if (FRN == 17 || FRN == 26) // Data Items with variable octets lenght (fx)
                {
                    BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                    this.firstIndex += 1;
                    fx = true;
                    while (fx)
                    {
                        if (BinList[BinList.Count - 1] == "1")
                        { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                        else
                            fx = false;
                    }
                }
                else // Data Items with fixed octets lenght
                {
                    for (int octets = 0; octets < OctetsDataItemsCAT21V023[FRN - 1]; octets++)
                    {
                        if (FRN == 5) // not needed to get converted to BIN
                            BinList.Add(this.Message[this.firstIndex]);
                        else
                            BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                        this.firstIndex += 1;
                    }
                }
            }
            else if (V21)
            {
                if (FRN == 2 || FRN == 17 || FRN == 34) // Data Items with variable octets lenght (fx)
                {
                    BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                    this.firstIndex += 1;
                    fx = true;
                    while (fx)
                    {
                        if (BinList[BinList.Count - 1] == "1")
                        { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                        else
                            fx = false;
                    }
                }
                else if (FRN == 39) // Data Items with variable octets lenght (REP)
                {
                    BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                    int REP = Convert.ToInt32(string.Join("", BinList), 2);
                    this.firstIndex += 1;
                    for (int i = 0; i < OctetsDataItemsCAT21V21[FRN - 1] * REP; i++)
                    { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                }
                else if (FRN == 37 || FRN == 42) // Data Items with variable octets lenght (with limit)
                {
                    BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                    this.firstIndex += 1;
                    for (int i = 0; i < OctetsDataItemsCAT21V21[FRN - 1] - 1; i++)
                    {
                        if (BinList[BinList.Count - 1] == "1")
                        { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                        else
                            break;
                    }
                }
                else if (FRN == 48 || FRN == 49) //Reserved Expansion and Special Purpose Fields
                {
                    while (this.firstIndex < this.Message.Count)
                        this.firstIndex++;
                }

                else // Data Items with fixed octets lenght
                {
                    for (int octets = 0; octets < OctetsDataItemsCAT21V21[FRN - 1]; octets++)
                    {
                        if (FRN == 11) // not needed to get converted to BIN
                            BinList.Add(this.Message[this.firstIndex]);
                        else
                            BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                        this.firstIndex += 1;
                    }
                }
            }
        }

        // Function that decodes all the CAT21 Data Items
        public void DecodeCAT21()
        {
            obtainBinListCAT21();
            this.row[2] = this.dataSourceIdentifier; data.filledDataItems[2] = true;
            this.row[3] = this.sensor; data.filledDataItems[3] = true;
            if (V023)
            {
                if (FRN == 2)
                {
                    this.targetReportDescriptorCAT21V023 = new TargetReportDescriptorCAT21v023(BinList);
                    this.row[9] = moreInfo; data.filledDataItems[9] = true;
                }
                else if (FRN == 3)
                {
                    this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                    this.row[4] = this.timeOfDay.timeUTC; data.filledDataItems[4] = true;
                }
                else if (FRN == 4)
                {
                    this.positionWGS84 = new PositionWGS84Coordinates(BinList, this.category);
                    this.row[11] = Math.Round(this.positionWGS84.latitude, 5) + " || " + Math.Round(this.positionWGS84.longitude, 5);
                    data.filledDataItems[11] = true;
                }
                else if (FRN == 5)
                {
                    this.ICAOAdress = string.Join("", BinList);
                    this.row[7] = this.ICAOAdress; data.filledDataItems[7] = true;
                }
                else if (FRN == 6)
                {
                    this.geometricAltitude = (binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count()) * 6.25).ToString();
                    this.row[17] = this.geometricAltitude; data.filledDataItems[17] = true;
                }
                else if (FRN == 7)
                {
                    this.figureOfMerit = new FigureOfMerit(BinList);
                    this.row[61] = moreInfo; data.filledDataItems[61] = true;
                }
                else if (FRN == 8)
                {
                    this.linkTechnology = new LinkTechnololy(BinList);
                    this.row[45] = moreInfo; data.filledDataItems[45] = true;
                }
                else if (FRN == 9)
                {
                    this.rollAngle = (binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count()) * 0.01).ToString();
                    this.row[81] = this.rollAngle; data.filledDataItems[81] = true;
                }
                else if (FRN == 10)
                {
                    this.flightLevel.FL = (binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count()) / 4).ToString();
                    this.flightLevel.altitude = Convert.ToDouble(this.flightLevel.FL) * 30.48; // [m]
                    if (this.flightLevel.altitude < 0)
                        this.flightLevel.altitude = 0;
                    this.row[17] = "FL" + this.flightLevel.FL; data.filledDataItems[17] = true;
                }
                else if (FRN == 11)
                {
                    this.airSpeed = new AirSpeed(BinList);
                    this.row[82] = this.airSpeed.TypeAirSpeed + ": " + this.airSpeed.AirSpeedValue;
                    data.filledDataItems[82] = true;
                }
                else if (FRN == 12)
                {
                    this.trueAirspeed = Convert.ToInt32(string.Join("", BinList), 2).ToString();
                    this.row[83] = this.trueAirspeed; data.filledDataItems[83] = true;
                }
                else if (FRN == 13)
                {
                    this.magneticHeading = (Convert.ToInt32(string.Join("", BinList), 2) * 360 / Math.Pow(2, 16)).ToString();
                    this.row[84] = this.magneticHeading; data.filledDataItems[84] = true;
                }
                else if (FRN == 14)
                {
                    this.barometricVerticalRate = (Convert.ToInt32(string.Join("", BinList), 2) * 6.25).ToString();
                    this.row[21] = this.barometricVerticalRate; data.filledDataItems[21] = true;
                }
                else if (FRN == 15)
                {
                    this.geometricVerticalRate = (Convert.ToInt32(string.Join("", BinList), 2) * 6.25).ToString();
                    this.row[22] = this.geometricVerticalRate; data.filledDataItems[22] = true;
                }
                else if (FRN == 16)
                {
                    this.groundVector = new GroundVector(BinList, Convert.ToString(FRN));
                    this.row[14] = Math.Round(this.groundVector.GroundSpeed, 3) + "||" + Math.Round(this.groundVector.TrackAngle, 3);
                    data.filledDataItems[14] = true;
                }
                else if (FRN == 17)
                {
                    this.rateOfTurnV023 = new RateOfTurn(BinList);
                    this.row[85] = this.rateOfTurnV023.rateOfTurn + " (" + this.rateOfTurnV023.turnIndicator + ")";
                    data.filledDataItems[85] = true;
                }
                else if (FRN == 18)
                {
                    this.callsign = new TargetIdentification(BinList);
                    this.row[6] = this.callsign.TargetID; data.filledDataItems[6] = true;
                }
                else if (FRN == 19)
                {
                    this.velocityAccuracy = Convert.ToInt32(string.Join("", BinList), 2).ToString();
                    this.row[34] = this.velocityAccuracy; data.filledDataItems[34] = true;
                }
                else if (FRN == 20)
                {
                    this.timeOfDayAccuracy = (Convert.ToInt32(string.Join("", BinList), 2) / 256.0).ToString();
                    this.row[86] = this.timeOfDayAccuracy; data.filledDataItems[86] = true;
                }
                else if (FRN == 21)
                {
                    List<string> DefaultTargetStatus = new List<string>() { "No emergency/not reported", "General Emergency", "Lifeguard/medical", "Minimum Fuel", "No Communications", "Unlawful interference" };
                    if (Convert.ToInt32(string.Join("", BinList), 2) < (DefaultTargetStatus.Count() - 1))
                        this.targetStatusV023 = DefaultTargetStatus[Convert.ToInt32(string.Join("", BinList), 2)];
                    this.row[48] = this.targetStatusV023; data.filledDataItems[48] = true;
                }
                else if (FRN == 22)
                {
                    List<string> defaultEmitterCategory = new List<string>() { "N/A", "light aircraft <= 7000 kg", "reserved", "7000 kg < medium aircraft  < 136000 kg ", "reserved", "136000 kg <= heavy aircraft ", "highly manoeuvrable (5g acceleration capability) and high speed (>400 knots cruise)", "reserved", "reserved", "reserved", "rotocraft", "glider/sailplane", "lighter-than-air", "unmanned aerial vehicle", "space/transatmospheric vehicle", "ultralight/handglider/paraglider", "parachutist/skydiver", "reserved", "reserved", "reserved", "surface emergency vehicle", "surface service vehicle", "fixed hround or tethered obstruction", "reserved", "reserved" };
                    if (Convert.ToInt32(string.Join("", BinList), 2) < (defaultEmitterCategory.Count() - 1))
                        this.emitterCategory = defaultEmitterCategory[Convert.ToInt32(string.Join("", BinList), 2)];
                    if (Enumerable.Range(1, 6).Contains(Convert.ToInt32(string.Join("", BinList), 2)) || Enumerable.Range(10, 12).Contains(Convert.ToInt32(string.Join("", BinList), 2)))
                        typeTarget = "Aircraft";
                    if (Enumerable.Range(20, 21).Contains(Convert.ToInt32(string.Join("", BinList), 2)))
                        typeTarget = "Ground vehicle";
                    this.row[40] = this.emitterCategory; data.filledDataItems[40] = true;
                }
                else if (FRN == 23)
                {
                    int octets = 2;
                    for (int bit = 0; bit < BinList.Count / 2; bit++)
                    {
                        List<string> MetInformationList = new List<string>();
                        if (BinList[bit] == "1")
                        {
                            if (bit == 3) //Subfield Turbulence
                                octets = 1;
                            for (int i = 0; i < octets; i++)
                            { MetInformationList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                            if (bit == 0)
                            {
                                this.metInformation.WS = Convert.ToInt32(string.Join("", MetInformationList), 2).ToString();
                                this.metInformation.InsertMetInfoInTable("WS [kt]", this.metInformation.WS);
                            }
                            else if (bit == 1)
                            {
                                this.metInformation.WD = Convert.ToInt32(string.Join("", MetInformationList), 2).ToString();
                                this.metInformation.InsertMetInfoInTable("WD [º]", this.metInformation.WD);
                            }
                            else if (bit == 2)
                            {
                                this.metInformation.TMP = (binTwosComplementToSignedDecimal(string.Join("", MetInformationList), MetInformationList.Count()) * 0.25).ToString();
                                this.metInformation.InsertMetInfoInTable("TMP [º]", this.metInformation.TMP);
                            }
                            else if (bit == 3)
                            {
                                this.metInformation.TRB = Convert.ToInt32(string.Join("", MetInformationList), 2).ToString();
                                this.metInformation.InsertMetInfoInTable("TRB", this.metInformation.TRB);
                            }
                        }
                    }
                    this.row[87] = moreInfo; data.filledDataItems[87] = true;
                }
                else if (FRN == 24)
                {
                    this.selectedAltitude = new SelectedAltitude(BinList);
                    this.row[20] = this.selectedAltitude.Altitude + " *"; data.filledDataItems[20] = true;
                }
                else if (FRN == 25)
                {
                    this.finalSelectedAltitude = new FinalSelectedAltitude(BinList);
                    this.row[88] = this.finalSelectedAltitude.Altitude + " *";
                    data.filledDataItems[88] = true;
                }
                else if (FRN == 26)
                {
                    for (int bit = 0; bit < BinList.Count; bit++)
                    {
                        List<string> BinTI_Subfield = new List<string>();
                        if (BinList[bit] == "1")
                        {
                            if (bit == 0) //TIS Subfield
                            {
                                BinTI_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex]));
                                this.firstIndex += 1;
                                fx = true;
                                while (fx)
                                {
                                    if (BinTI_Subfield[BinTI_Subfield.Count - 1] == "1")
                                    { BinTI_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                                    else
                                        fx = false;
                                }
                                this.trajectoryIntentStatus = new TrajectoryIntentStatus(BinTI_Subfield);
                            }
                            else if (bit == 1) //TID Subfield
                            {
                                BinTI_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex]));
                                this.firstIndex += 1;
                                this.trajectoryIntentData.REP = Convert.ToInt32(string.Join("", BinTI_Subfield), 2).ToString();
                                for (int i = 0; i < 15 * Convert.ToInt32(this.trajectoryIntentData.REP); i++)
                                { BinTI_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                                this.trajectoryIntentData = new TrajectoryIntentData(BinTI_Subfield);
                            }
                        }
                    }
                    this.row[89] = moreInfo; data.filledDataItems[89] = true;
                }
            }
            else if (V21)
            {
                if (FRN == 2)
                {
                    this.targetReportDescriptorCAT21V21 = new TargetReportDescriptorCAT21v21(BinList);
                    this.row[10] = moreInfo; data.filledDataItems[10] = true;
                }
                else if (FRN == 3)
                {
                    this.trackNumber = Convert.ToInt32(string.Join("", BinList), 2).ToString().PadLeft(4, '0');
                    this.row[5] = this.trackNumber; data.filledDataItems[5] = true;
                }
                else if (FRN == 4)
                {
                    this.serviceIdentification = Convert.ToString(Convert.ToInt32(string.Join("", BinList), 2));
                    this.row[26] = this.serviceIdentification; data.filledDataItems[26] = true;
                }
                else if (FRN == 5)
                {
                    this.timeOfApplicabilityPosition = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                    this.row[36] = this.timeOfApplicabilityPosition.timeUTC; data.filledDataItems[36] = true;
                }
                else if (FRN == 6)
                {
                    this.positionWGS84 = new PositionWGS84Coordinates(BinList, this.category);
                    this.row[11] = Math.Round(this.positionWGS84.latitude, 5) + " || " + Math.Round(this.positionWGS84.longitude, 5);
                    data.filledDataItems[11] = true;
                }
                else if (FRN == 7)
                {
                    this.positionWGS84HighResolution = new PositionWGS84Coordinates(BinList, this.category);
                    this.row[35] = Math.Round(this.positionWGS84.latitude, 5) + " || " + Math.Round(this.positionWGS84.longitude, 5);
                    data.filledDataItems[35] = true;
                }
                else if (FRN == 8)
                {
                    this.timeOfApplicabilityVelocity = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                    this.row[90] = this.timeOfApplicabilityVelocity.timeUTC; data.filledDataItems[90] = true;
                }
                else if (FRN == 9)
                {
                    this.airSpeed = new AirSpeed(BinList);
                    this.row[82] = this.airSpeed.TypeAirSpeed + ": " + this.airSpeed.AirSpeedValue; ;
                    data.filledDataItems[82] = true;
                }
                else if (FRN == 10)
                {
                    this.trueAirspeed = (Convert.ToInt32(string.Join("", BinList.GetRange(1, 15)), 2)).ToString();
                    this.row[83] = this.trueAirspeed; data.filledDataItems[83] = true;
                }
                else if (FRN == 11)
                {
                    this.ICAOAdress = string.Join("", BinList);
                    this.row[7] = this.ICAOAdress; data.filledDataItems[7] = true;
                }
                else if (FRN == 12)
                {
                    this.timeOfReceptionPosition = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                    this.row[37] = this.timeOfReceptionPosition.timeUTC; data.filledDataItems[37] = true;
                }
                else if (FRN == 13)
                {
                    this.timeOfReceptionPositionHighPrecision = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                    this.row[91] = this.timeOfReceptionPositionHighPrecision.timeUTC; data.filledDataItems[91] = true;
                }
                else if (FRN == 14)
                {
                    this.timeOfReceptionVelocity = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                    this.row[38] = this.timeOfReceptionVelocity.timeUTC; data.filledDataItems[38] = true;
                }
                else if (FRN == 15)
                {
                    this.timeOfReceptionVelocityHighPrecision = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                    this.row[92] = this.timeOfReceptionVelocityHighPrecision.timeUTC; data.filledDataItems[92] = true;
                }
                else if (FRN == 16)
                {
                    this.geometricAltitude = (binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count()) * 6.25).ToString();
                    this.row[18] = this.geometricAltitude; data.filledDataItems[18] = true;
                }
                else if (FRN == 17)
                {
                    this.qualityIndicators = new QualityIndicators(BinList);
                    this.row[46] = moreInfo; data.filledDataItems[46] = true;
                }
                else if (FRN == 18)
                {
                    this.MOPSversion = new MOPSversion(BinList);
                    this.row[47] = moreInfo; data.filledDataItems[47] = true;
                }
                else if (FRN == 19)
                {
                    this.mode3A.Reply = Convert.ToString(Convert.ToInt32(string.Join("", BinList.GetRange(4, 12)), 2), 8).PadLeft(4, '0'); //octal representation
                    this.row[8] = this.mode3A.Reply; data.filledDataItems[8] = true;
                }
                else if (FRN == 20)
                {
                    this.rollAngle = (binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count()) * 0.01).ToString();
                    this.row[81] = this.rollAngle; data.filledDataItems[81] = true;
                }
                else if (FRN == 21)
                {
                    this.flightLevel.FL = (binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count()) / 4.0).ToString();
                    this.flightLevel.altitude = Convert.ToDouble(this.flightLevel.FL) * 30.48; // [m]
                    if (this.flightLevel.altitude < 0)
                        this.flightLevel.altitude = 0;
                    this.row[17] = "FL" + this.flightLevel.FL; data.filledDataItems[17] = true;
                }
                else if (FRN == 22)
                {
                    this.magneticHeading = Convert.ToInt32(string.Join("", BinList), 2).ToString();
                    this.row[84] = this.magneticHeading; data.filledDataItems[84] = true;
                }
                else if (FRN == 23)
                {
                    this.targetStatusV21 = new TargetStatus(BinList);
                    this.row[48] = moreInfo; data.filledDataItems[48] = true;
                }
                else if (FRN == 24)
                {
                    this.barometricVerticalRate = (Convert.ToInt32(string.Join("", BinList.GetRange(1, 15)), 2) * 6.25).ToString();
                    this.row[21] = this.barometricVerticalRate; data.filledDataItems[21] = true;
                }
                else if (FRN == 25)
                {
                    this.geometricVerticalRate = (Convert.ToInt32(string.Join("", BinList.GetRange(1, 15)), 2) * 6.25).ToString();
                    this.row[22] = this.geometricVerticalRate; data.filledDataItems[22] = true;
                }
                else if (FRN == 26)
                {
                    this.groundVector = new GroundVector(BinList, Convert.ToString(FRN));
                    this.row[14] = Math.Round(this.groundVector.GroundSpeed, 3) + " || " + Math.Round(this.groundVector.TrackAngle, 3);
                    data.filledDataItems[14] = true;
                }
                else if (FRN == 27)
                {
                    this.rateOfTurnV21 = (Convert.ToInt32(string.Join("", BinList.GetRange(6, 10)), 2) * 6.25).ToString();
                    this.row[85] = this.rateOfTurnV21; data.filledDataItems[85] = true;
                }
                else if (FRN == 28)
                {
                    this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                    this.row[4] = this.timeOfDay.timeUTC; data.filledDataItems[4] = true;
                }
                else if (FRN == 29)
                {
                    this.callsign = new TargetIdentification(BinList);
                    this.row[6] = this.callsign.TargetID; data.filledDataItems[6] = true;
                }
                else if (FRN == 30)
                {
                    List<string> defaultEmitterCategory = new List<string>() { "No ADS-B Emitter Category Information", "light aircraft <= 15500 lbs", "15500 lbs < small aircraft <75000 lbs", "75000 lbs < medium a/c  < 300000 lbs", "High Vortex Large", "300000 lbs <= heavy aircraft", "highly manoeuvrable (5g acceleration capability) and high speed (>400 knots cruise)", "reserved", "reserved", "reserved", "rotocraft", "glider/sailplane", "lighter-than-air", "unmanned aerial vehicle", "space/transatmospheric vehicle", "ultralight/handglider/paraglider", "parachutist/skydiver", "reserved", "reserved", "reserved", "surface emergency vehicle", "surface service vehicle", "fixed ground of tethered obstruction", "cluster obstacle", "line obstacle" };
                    if (Convert.ToInt32(string.Join("", BinList), 2) < (defaultEmitterCategory.Count() - 1))
                        this.emitterCategory = defaultEmitterCategory[Convert.ToInt32(string.Join("", BinList), 2)];
                    if (Enumerable.Range(1, 6).Contains(Convert.ToInt32(string.Join("", BinList), 2)) || Enumerable.Range(10, 12).Contains(Convert.ToInt32(string.Join("", BinList), 2)))
                        typeTarget = "Aircraft";
                    if (Enumerable.Range(20, 21).Contains(Convert.ToInt32(string.Join("", BinList), 2)))
                        typeTarget = "Ground vehicle";
                    this.row[40] = this.emitterCategory; data.filledDataItems[40] = true;
                }
                else if (FRN == 31)
                {
                    int octets = 2;
                    for (int bit = 0; bit < BinList.Count / 2; bit++)
                    {
                        List<string> MetInformationList = new List<string>();
                        if (BinList[bit] == "1")
                        {
                            if (bit == 3) //Subfield Turbulence
                                octets = 1;
                            for (int i = 0; i < octets; i++)
                            { MetInformationList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                            if (bit == 0)
                            {
                                this.metInformation.WS = Convert.ToInt32(string.Join("", MetInformationList), 2).ToString();
                                this.metInformation.InsertMetInfoInTable("WS", this.metInformation.WS);
                            }
                            else if (bit == 1)
                            {
                                this.metInformation.WD = Convert.ToInt32(string.Join("", MetInformationList), 2).ToString();
                                this.metInformation.InsertMetInfoInTable("WD", this.metInformation.WD);
                            }
                            else if (bit == 2)
                            {
                                this.metInformation.TMP = binTwosComplementToSignedDecimal(string.Join("", MetInformationList), MetInformationList.Count()).ToString();
                                this.metInformation.InsertMetInfoInTable("TMP", this.metInformation.TMP);
                            }
                            else if (bit == 3)
                            {
                                this.metInformation.TRB = Convert.ToInt32(string.Join("", MetInformationList), 2).ToString();
                                this.metInformation.InsertMetInfoInTable("TRB", this.metInformation.TRB);
                            }
                        }
                    }
                    this.row[87] = moreInfo; data.filledDataItems[87] = true;
                }
                else if (FRN == 32)
                {
                    this.selectedAltitude = new SelectedAltitude(BinList);
                    this.row[20] = this.selectedAltitude.Altitude + " *"; data.filledDataItems[20] = true;
                }
                else if (FRN == 33)
                {
                    this.finalSelectedAltitude = new FinalSelectedAltitude(BinList);
                    this.row[88] = this.finalSelectedAltitude.Altitude + " *"; data.filledDataItems[88] = true;
                }
                else if (FRN == 34)
                {
                    for (int bit = 0; bit < BinList.Count; bit++)
                    {
                        List<string> BinTI_Subfield = new List<string>();
                        if (BinList[bit] == "1")
                        {
                            if (bit == 0) //TIS Subfield
                            {
                                BinTI_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex]));
                                this.firstIndex += 1;
                                fx = true;
                                while (fx)
                                {
                                    if (BinTI_Subfield[BinTI_Subfield.Count - 1] == "1")
                                    { BinTI_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                                    else
                                        fx = false;
                                }
                                this.trajectoryIntentStatus = new TrajectoryIntentStatus(BinTI_Subfield);
                            }
                            else if (bit == 1) //TID Subfield
                            {
                                BinTI_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex]));
                                this.firstIndex += 1;
                                this.trajectoryIntentData.REP = Convert.ToInt32(string.Join("", BinTI_Subfield), 2).ToString();
                                for (int i = 0; i < 15 * Convert.ToInt32(this.trajectoryIntentData.REP); i++)
                                { BinTI_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1;  }
                                this.trajectoryIntentData = new TrajectoryIntentData(BinTI_Subfield);
                            }
                        }
                    }
                    this.row[89] = moreInfo; data.filledDataItems[89] = true;
                }
                else if (FRN == 35)
                {
                    this.serviceManagement = Convert.ToString(Convert.ToInt32(string.Join("", BinList), 2) * 0.5);
                    this.row[25] = this.serviceManagement; data.filledDataItems[25] = true;
                }
                else if (FRN == 36)
                {
                    this.aircraftOperationalStatus = new AircraftOperationalStatus(BinList);
                    this.row[49] = moreInfo; data.filledDataItems[49] = true;
                }
                else if (FRN == 37)
                {
                    this.surfaceCapabilitiesAndCharacteristics = new SurfaceCapabilitiesAndCharacteristics(BinList);
                    this.row[50] = moreInfo; data.filledDataItems[50] = true;
                }
                else if (FRN == 38)
                {
                    this.messageAmplitude = Convert.ToString(binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count()));
                    this.row[28] = this.messageAmplitude; data.filledDataItems[28] = true;
                }
                else if (FRN == 39)
                {
                    this.modeS_MBData = new ModeS_MBData(BinList);
                    this.row[54] = this.modeS_MBData.REP + " register(s) *"; data.filledDataItems[54] = true;
                }
                else if (FRN == 40)
                {
                    this.ACASresolutionAdvisoryReport = new ACAS_ResolutionAdvisoryReport(BinList);
                    this.row[93] = moreInfo; data.filledDataItems[93] = true;
                }
                else if (FRN == 41)
                {
                    this.receiverID = Convert.ToString(Convert.ToInt32(string.Join("", BinList), 2));
                    this.row[39] = this.receiverID; data.filledDataItems[39] = true;
                }
                else if (FRN == 42)
                {
                    for (int bit = 0; bit < BinList.Count; bit++)
                    {
                        List<string> BinDataAgeSubfield = new List<string>();
                        if (BinList[bit] == "1" && (bit - 7) % 8 != 0) // eliminar el fx=1
                        {
                            BinDataAgeSubfield.AddRange(HexToBinary(this.Message[this.firstIndex]));
                            this.firstIndex += 1;
                            if (bit == 0) //Subfield AOS
                            {
                                this.dataAges.AOS = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("AOS", this.dataAges.AOS);
                            }
                            else if (bit == 1) //Subfield TRD
                            {
                                this.dataAges.TRD = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("TRD", this.dataAges.TRD);
                            }
                            else if (bit == 2) //Subfield M3A
                            {
                                this.dataAges.M3A = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("M3A", this.dataAges.M3A);
                            }
                            else if (bit == 3) //Subfield QI
                            {
                                this.dataAges.QI = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("QI", this.dataAges.QI);
                            }
                            else if (bit == 4) //Subfield TI
                            {
                                this.dataAges.TI = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("TI", this.dataAges.TI);
                            }
                            else if (bit == 5) //Subfield MAM
                            {
                                this.dataAges.MAM = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("MAM", this.dataAges.MAM);
                            }
                            else if (bit == 6) //Subfield GH
                            {
                                this.dataAges.GH = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("GH", this.dataAges.GH);
                            }
                            else if (bit == 8) //Subfield FL
                            {
                                this.dataAges.FL = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("FL", this.dataAges.FL);
                            }
                            else if (bit == 9) //Subfield ISA
                            {
                                this.dataAges.ISA = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("ISA", this.dataAges.ISA);
                            }
                            else if (bit == 10) //Subfield FSA
                            {
                                this.dataAges.FSA = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("FSA", this.dataAges.FSA);
                            }
                            else if (bit == 11) //Subfield AS
                            {
                                this.dataAges.AS = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("AS", this.dataAges.AS);
                            }
                            else if (bit == 12) //Subfield TAS
                            {
                                this.dataAges.TAS = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("TAS", this.dataAges.TAS);
                            }
                            else if (bit == 13) //Subfield MH
                            {
                                this.dataAges.MH = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("MH", this.dataAges.MH);
                            }
                            else if (bit == 14) //Subfield BVR
                            {
                                this.dataAges.BVR = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("BVR", this.dataAges.BVR);
                            }
                            else if (bit == 16) //Subfield GVR
                            {
                                this.dataAges.GVR = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("GVR", this.dataAges.GVR);
                            }
                            else if (bit == 17) //Subfield GV
                            {
                                this.dataAges.GV = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("GV", this.dataAges.GV);
                            }
                            else if (bit == 18) //Subfield TAR
                            {
                                this.dataAges.TAR = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("TAR", this.dataAges.TAR);
                            }
                            else if (bit == 19) //Subfield TId
                            {
                                this.dataAges.TId = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("TId", this.dataAges.TId);
                            }
                            else if (bit == 20) //Subfield TS
                            {
                                this.dataAges.TS = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("TS", this.dataAges.TS);
                            }
                            else if (bit == 21) //Subfield MET
                            {
                                this.dataAges.MET = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("MET", this.dataAges.MET);
                            }
                            else if (bit == 22) //Subfield ROA
                            {
                                this.dataAges.ROA = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("ROA", this.dataAges.ROA);
                            }
                            else if (bit == 24) //Subfield ARA
                            {
                                this.dataAges.ARA = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("ARA", this.dataAges.ARA);
                            }
                            else if (bit == 25) //Subfield SCC
                            {
                                this.dataAges.SCC = (Convert.ToInt32(string.Join("", BinDataAgeSubfield), 2) * 0.1).ToString();
                                this.dataAges.InsertMetInfoInTable("SCC", this.dataAges.SCC);
                            }
                        }
                    }
                    this.row[51] = moreInfo; data.filledDataItems[51] = true;
                }
            }
        }

        public void obtainBinListCAT34()
        {
            if (FRN == 8) // Data Items with variable octets lenght (REP)
            {
                BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                int REP = Convert.ToInt32(string.Join("", BinList), 2);
                this.firstIndex += 1;
                for (int i = 0; i < OctetsDataItemsCAT34[FRN - 1] * REP; i++)
                { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
            }
            else // Data Items with fixed octets lenght
            {
                for (int octets = 0; octets < OctetsDataItemsCAT34[FRN - 1]; octets++)
                { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
            }
        }

        // Function that decodes all the CAT34 Data Items
        public void DecodeCAT34()
        {
            obtainBinListCAT34();
            if (FRN == 1)
            {
                this.SAC = Convert.ToInt32(string.Join("", BinList.GetRange(0, 8)), 2).ToString().PadLeft(3, '0');
                this.SIC = Convert.ToInt32(string.Join("", BinList.GetRange(8, 8)), 2).ToString().PadLeft(3, '0');
                this.dataSourceIdentifier = string.Join("/", this.SAC, this.SIC);
                this.sensor = data.RadarStationList.Find(r => r.sac_sic == this.dataSourceIdentifier && r.type != "ADS-B").radarStation;
                this.row[2] = this.dataSourceIdentifier; data.filledDataItems[2] = true;
                this.row[3] = this.sensor; data.filledDataItems[3] = true;
            }
            else if (FRN == 2)
            {
                List<string> defaultMT = new List<string>() { "N/A", "North marker message", "Sector crossing message", "Geographical filtering message", "Jamming Strobe message" };
                this.messageType = defaultMT[Convert.ToInt32(string.Join("", BinList), 2)];
                this.row[9] = this.messageType; data.filledDataItems[9] = true;
            }
            else if (FRN == 3)
            {
                this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                this.row[4] = this.timeOfDay.timeUTC; data.filledDataItems[4] = true;
            }
            else if (FRN == 4)
            {
                this.sectorNumber = (Convert.ToInt32(string.Join("", BinList), 2) * 360 / Math.Pow(2, 8)).ToString(); // [º];
                this.row[29] = this.sectorNumber; data.filledDataItems[29] = true;
            }
            else if (FRN == 5)
            {
                this.antennaRotationPeriod = Math.Round(Convert.ToInt32(string.Join("", BinList), 2) * 1 / 128.0, 3).ToString(); // [s];
                this.row[25] = this.antennaRotationPeriod; data.filledDataItems[25] = true;
            }
            else if (FRN == 6)
            {
                int octets = 1;
                for (int bit = 0; bit < BinList.Count; bit++)
                {
                    List<string> SystemConfigurationStatusList = new List<string>();
                    if (BinList[bit] == "1")
                    {
                        if (bit == 5) //MDS Subfield
                            octets = 2;
                        for (int i = 0; i < octets; i++)
                        { SystemConfigurationStatusList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                        if (bit == 0) //COM Subfield
                        {
                            List<string> defaultNOGO = new List<string>() { "System is released for operational use", "Operational use of System is inhibited, i.e. the data shall be discarded by an operational SDPS" };
                            List<string> defaultRDPC = new List<string>() { "RDPC-1 selected", "RDPC-2 selected" };
                            List<string> defaultRDPR = new List<string>() { "Default situation", "Reset of RDPC" };
                            List<string> defaultOVL_RDP = new List<string>() { "Default, no overload", "Overload in RDP" };
                            List<string> defaultOVL_XMT = new List<string>() { " Default, no overload", "Overload in transmission subsystem" };
                            List<string> defaultMSC_COM = new List<string>() { "Monitoring system connected", "Monitoring system disconnected" };
                            List<string> defaultTSV = new List<string>() { "Time Source Valid", "Time Source Invalid" };
                            this.systemConfigurationStatus.NOGO = defaultNOGO[Convert.ToInt32(SystemConfigurationStatusList[0], 2)];
                            this.systemConfigurationStatus.RDPC = defaultRDPC[Convert.ToInt32(SystemConfigurationStatusList[1], 2)];
                            this.systemConfigurationStatus.RDPR = defaultRDPR[Convert.ToInt32(SystemConfigurationStatusList[2], 2)];
                            this.systemConfigurationStatus.OVL_RDP = defaultOVL_RDP[Convert.ToInt32(SystemConfigurationStatusList[3], 2)];
                            this.systemConfigurationStatus.OVL_XMT = defaultOVL_XMT[Convert.ToInt32(SystemConfigurationStatusList[4], 2)];
                            this.systemConfigurationStatus.MSC_COM = defaultMSC_COM[Convert.ToInt32(SystemConfigurationStatusList[5], 2)];
                            this.systemConfigurationStatus.TSV = defaultTSV[Convert.ToInt32(SystemConfigurationStatusList[6], 2)];
                            this.systemConfigurationStatus.InsertSCSinfoInTable("NOGO", this.systemConfigurationStatus.NOGO);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("RDPC", this.systemConfigurationStatus.RDPC);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("RDPR", this.systemConfigurationStatus.RDPR);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("OVL_RDP", this.systemConfigurationStatus.OVL_RDP);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("OVL_XMT", this.systemConfigurationStatus.OVL_XMT);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("MSC_COM", this.systemConfigurationStatus.MSC_COM);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("TSV", this.systemConfigurationStatus.TSV);
                        }
                        else if (bit == 3) //PSR Subfield
                        {
                            List<string> defaultANT_PSR = new List<string>() { "Antenna 1", "Antenna 2" };
                            List<string> defaultCH_A_B_PSR = new List<string>() { "No channel selected", "RChannel A only selected", "Channel B only selected", "Diversity mode; Channel A and B selected" };
                            List<string> defaultOVL_PSR = new List<string>() { "No overload", "Overload" };
                            List<string> defaultMSC_PSR = new List<string>() { "Monitoring system connected", "Monitoring system disconnected" };
                            this.systemConfigurationStatus.ANT_PSR = defaultANT_PSR[Convert.ToInt32(SystemConfigurationStatusList[0], 2)];
                            this.systemConfigurationStatus.CH_A_B_PSR = defaultCH_A_B_PSR[Convert.ToInt32(string.Join("", SystemConfigurationStatusList.GetRange(1, 2)), 2)];
                            this.systemConfigurationStatus.OVL_PSR = defaultOVL_PSR[Convert.ToInt32(SystemConfigurationStatusList[3], 2)];
                            this.systemConfigurationStatus.MSC_PSR = defaultMSC_PSR[Convert.ToInt32(SystemConfigurationStatusList[4], 2)];
                            this.systemConfigurationStatus.InsertSCSinfoInTable("ANT_PSR", this.systemConfigurationStatus.ANT_PSR);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("CH_A_B_PSR", this.systemConfigurationStatus.CH_A_B_PSR);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("OVL_PSR", this.systemConfigurationStatus.OVL_PSR);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("MSC_PSR", this.systemConfigurationStatus.MSC_PSR);
                        }
                        else if (bit == 4) //SSR Subfield
                        {
                            List<string> defaultANT_SSR = new List<string>() { "Antenna 1", "Antenna 2" };
                            List<string> defaultCH_A_B_SSR = new List<string>() { "No channel selected", "RChannel A only selected", "Channel B only selected", "Invalid combination" };
                            List<string> defaultOVL_SSR = new List<string>() { "No overload", "Overload" };
                            List<string> defaultMSC_SSR = new List<string>() { "Monitoring system connected", "Monitoring system disconnected" };
                            this.systemConfigurationStatus.ANT_SSR = defaultANT_SSR[Convert.ToInt32(SystemConfigurationStatusList[0], 2)];
                            this.systemConfigurationStatus.CH_A_B_SSR = defaultCH_A_B_SSR[Convert.ToInt32(string.Join("", SystemConfigurationStatusList.GetRange(1, 2)), 2)];
                            this.systemConfigurationStatus.OVL_SSR = defaultOVL_SSR[Convert.ToInt32(SystemConfigurationStatusList[3], 2)];
                            this.systemConfigurationStatus.MSC_SSR = defaultMSC_SSR[Convert.ToInt32(SystemConfigurationStatusList[4], 2)];
                            this.systemConfigurationStatus.InsertSCSinfoInTable("ANT_SSR", this.systemConfigurationStatus.ANT_SSR);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("CH_A_B_SSR", this.systemConfigurationStatus.CH_A_B_SSR);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("OVL_SSR", this.systemConfigurationStatus.OVL_SSR);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("MSC_SSR", this.systemConfigurationStatus.MSC_SSR);
                        }
                        else if (bit == 5) //MDS Subfield
                        {
                            List<string> defaultANT_MDS = new List<string>() { "Antenna 1", "Antenna 2" };
                            List<string> defaultCH_A_B_MDS = new List<string>() { "No channel selected", "RChannel A only selected", "Channel B only selected", "Illegal combination" };
                            List<string> defaultOVL_SUR = new List<string>() { "No overload", "Overload" };
                            List<string> defaultMSC_MDS = new List<string>() { "Monitoring system connected", "Monitoring system disconnected" };
                            List<string> defaultSCF = new List<string>() { "Channel A in use", "Channel B in use" };
                            List<string> defaultDLF = new List<string>() { "Channel A in use", "Channel B in use" };
                            List<string> defaultOVL_SCF = new List<string>() { "No overload", "Overload" };
                            List<string> defaultOVL_DLF = new List<string>() { "No overload", "Overload" };
                            this.systemConfigurationStatus.ANT_MDS = defaultANT_MDS[Convert.ToInt32(SystemConfigurationStatusList[0], 2)];
                            this.systemConfigurationStatus.CH_A_B_MDS = defaultCH_A_B_MDS[Convert.ToInt32(string.Join("", SystemConfigurationStatusList.GetRange(1, 2)), 2)];
                            this.systemConfigurationStatus.OVL_SUR = defaultOVL_SUR[Convert.ToInt32(SystemConfigurationStatusList[3], 2)];
                            this.systemConfigurationStatus.MSC_MDS = defaultMSC_MDS[Convert.ToInt32(SystemConfigurationStatusList[4], 2)];
                            this.systemConfigurationStatus.SCF = defaultSCF[Convert.ToInt32(SystemConfigurationStatusList[5], 2)];
                            this.systemConfigurationStatus.DLF = defaultDLF[Convert.ToInt32(SystemConfigurationStatusList[6], 2)];
                            this.systemConfigurationStatus.OVL_SCF = defaultOVL_SCF[Convert.ToInt32(SystemConfigurationStatusList[7], 2)];
                            this.systemConfigurationStatus.OVL_DLF = defaultOVL_DLF[Convert.ToInt32(SystemConfigurationStatusList[8], 2)];
                            this.systemConfigurationStatus.InsertSCSinfoInTable("ANT_MDS", this.systemConfigurationStatus.ANT_MDS);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("CH_A_B_MDS", this.systemConfigurationStatus.CH_A_B_MDS);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("OVL_SUR", this.systemConfigurationStatus.OVL_SUR);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("MSC_MDS", this.systemConfigurationStatus.MSC_MDS);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("SCF", this.systemConfigurationStatus.SCF);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("DLF", this.systemConfigurationStatus.DLF);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("OVL_SCF", this.systemConfigurationStatus.OVL_SCF);
                            this.systemConfigurationStatus.InsertSCSinfoInTable("OVL_DLF", this.systemConfigurationStatus.OVL_DLF);
                        }
                    }
                }
                this.row[52] = moreInfo; data.filledDataItems[52] = true;
            }
            else if (FRN == 7)
            {
                for (int bit = 0; bit < BinList.Count; bit++)
                {
                    List<string> SystemProcessingModeList;
                    if (BinList[bit] == "1")
                    {
                        SystemProcessingModeList = HexToBinary(this.Message[this.firstIndex]);
                        this.firstIndex += 1;
                        if (bit == 0) //COM Subfield
                        {
                            List<string> defaultRED_RDP = new List<string>() { "No reduction active", "Reduction step 1 active", "Reduction step 2 active", "Reduction step 3 active", "Reduction step 4 active", "Reduction step 5 active", "Reduction step 6 active", "Reduction step 7 active" };
                            List<string> defaultRED_XMT = new List<string>() { "No reduction active", "Reduction step 1 active", "Reduction step 2 active", "Reduction step 3 active", "Reduction step 4 active", "Reduction step 5 active", "Reduction step 6 active", "Reduction step 7 active" };
                            this.systemProcessingMode.RED_RDP = defaultRED_RDP[Convert.ToInt32(string.Join("", SystemProcessingModeList.GetRange(1, 3)), 2)];
                            this.systemProcessingMode.RED_XMT = defaultRED_XMT[Convert.ToInt32(string.Join("", SystemProcessingModeList.GetRange(4, 3)), 2)];
                            this.systemProcessingMode.InsertSPMinfoInTable("RED_RDP", this.systemProcessingMode.RED_RDP);
                            this.systemProcessingMode.InsertSPMinfoInTable("RED_XMT", this.systemProcessingMode.RED_XMT);
                        }
                        else if (bit == 3) //PSR Subfield
                        {
                            List<string> defaultPOL = new List<string>() { "Linear polarization", "Circular polarization" };
                            List<string> defaultRED_RAD_PSR = new List<string>() { "No reduction active", "Reduction step 1 active", "Reduction step 2 active", "Reduction step 3 active", "Reduction step 4 active", "Reduction step 5 active", "Reduction step 6 active", "Reduction step 7 active" };
                            List<string> defaultSTC = new List<string>() { "STC Map-1", "STC Map-2", "STC Map-3", "STC Map-4" };
                            this.systemProcessingMode.POL = defaultPOL[Convert.ToInt32(SystemProcessingModeList[0], 2)];
                            this.systemProcessingMode.RED_RAD_PSR = defaultRED_RAD_PSR[Convert.ToInt32(string.Join("", SystemProcessingModeList.GetRange(1, 3)), 2)];
                            this.systemProcessingMode.STC = defaultSTC[Convert.ToInt32(string.Join("", SystemProcessingModeList.GetRange(4, 2)), 2)];
                            this.systemProcessingMode.InsertSPMinfoInTable("POL", this.systemProcessingMode.POL);
                            this.systemProcessingMode.InsertSPMinfoInTable("RED_RAD_PSR", this.systemProcessingMode.RED_RAD_PSR);
                            this.systemProcessingMode.InsertSPMinfoInTable("STC", this.systemProcessingMode.STC);
                        }
                        else if (bit == 4) //SSR Subfield
                        {
                            List<string> defaultRED_RAD_SSR = new List<string>() { "No reduction active", "Reduction step 1 active", "Reduction step 2 active", "Reduction step 3 active", "Reduction step 4 active", "Reduction step 5 active", "Reduction step 6 active", "Reduction step 7 active" };
                            this.systemProcessingMode.RED_RAD_SSR = defaultRED_RAD_SSR[Convert.ToInt32(string.Join("", SystemProcessingModeList.GetRange(0, 3)), 2)];
                            this.systemProcessingMode.InsertSPMinfoInTable("RED_RAD_PSR", this.systemProcessingMode.RED_RAD_PSR);
                        }
                        else if (bit == 5) //MDS Subfield
                        {
                            List<string> defaultRED_RAD_MDS = new List<string>() { "No reduction active", "Reduction step 1 active", "Reduction step 2 active", "Reduction step 3 active", "Reduction step 4 active", "Reduction step 5 active", "Reduction step 6 active", "Reduction step 7 active" };
                            List<string> defaultCLU = new List<string>() { "Autonomous", "Not autonomous" };
                            this.systemProcessingMode.RED_RAD_MDS = defaultRED_RAD_MDS[Convert.ToInt32(string.Join("", SystemProcessingModeList.GetRange(0, 3)), 2)];
                            this.systemProcessingMode.CLU = defaultCLU[Convert.ToInt32(SystemProcessingModeList[3], 2)];
                            this.systemProcessingMode.InsertSPMinfoInTable("RED_RAD_MDS", this.systemProcessingMode.RED_RAD_MDS);
                            this.systemProcessingMode.InsertSPMinfoInTable("CLU", this.systemProcessingMode.CLU);
                        }
                    }
                }
                this.row[53] = moreInfo; data.filledDataItems[53] = true;
            }
            else if (FRN == 8)
            {
                this.messageCountValues = new MessageCountValues(BinList);
                this.row[69] = this.messageCountValues.REP + " count value(s) *"; data.filledDataItems[69] = true;
            }
            else if (FRN == 9)
            {
                this.dynamicWindow = new DynamicWindow(BinList, category);
                this.row[70] = this.dynamicWindow.rhoStart + "-" + this.dynamicWindow.rhoEnd + " || " + this.dynamicWindow.thetaStart + "-" + this.dynamicWindow.thetaEnd;
                data.filledDataItems[70] = true;
            }
            else if (FRN == 10)
            {
                List<string> defaultDataFilter = new List<string>() { "Invalid value", "Filter for Weather data", "Filter for Jamming Strobe", "Filter for PSR data", "Filter for SSR/Mode S data", "Filter for SSR/Mode S + PSR data", "Enhanced Surveillance data", "Filter for PSR+Enhanced Surveillance data", "Filter for PSR+Enhanced Surveillance + SSR/Mode S data not in Area of Prime Interest", "Filter for PSR+Enhanced Surveillance + all SSR/Mode S data" };
                this.dataFilter = defaultDataFilter[Convert.ToInt32(string.Join("", BinList), 2)];
                this.row[94] = this.dataFilter; data.filledDataItems[94] = true;
            }
            else if (FRN == 11)
            {
                this.position3D = new Position3D(BinList);
                this.row[95] = this.position3D.height + " || " + this.position3D.latitude + " || " + this.position3D.longitude;
                data.filledDataItems[95] = true;
            }
            else if (FRN == 12)
            {
                this.collimationError = new CollimationError(BinList, category);
                this.row[71] = this.collimationError.rangeError + " || " + this.collimationError.azimuthError;
                data.filledDataItems[71] = true;
            }
        }

        public void obtainBinListCAT48()
        {
            if (FRN == 3 || FRN == 14 || FRN == 16) // Data Items with variable octets lenght (fx)
            {
                BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                this.firstIndex += 1;
                fx = true;
                while (fx)
                {
                    if (BinList[BinList.Count - 1] == "1")
                    { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                    else
                        fx = false;
                }
            }
            else if (FRN == 10) // Data Items with variable octets lenght (REP)
            {
                BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                int REP = Convert.ToInt32(string.Join("", BinList), 2);
                this.firstIndex += 1;
                for (int i = 0; i < OctetsDataItemsCAT48[FRN - 1] * REP; i++)
                { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
            }
            else // Data Items with fixed octets lenght
            {
                for (int octets = 0; octets < OctetsDataItemsCAT48[FRN - 1]; octets++)
                {
                    if (FRN == 8) // not needed to get converted to BIN (ICAO Address)
                        BinList.Add(this.Message[this.firstIndex]);
                    else
                        BinList.AddRange(HexToBinary(this.Message[this.firstIndex]));
                    this.firstIndex += 1;
                }
            }
        }

        // Function that decodes all the CAT48 Data Items
        public void DecodeCAT48()
        {
            obtainBinListCAT48();
            if (FRN == 1)
            {
                this.SAC = Convert.ToInt32(string.Join("", BinList.GetRange(0, 8)), 2).ToString().PadLeft(3, '0');
                this.SIC = Convert.ToInt32(string.Join("", BinList.GetRange(8, 8)), 2).ToString().PadLeft(3, '0');
                this.dataSourceIdentifier = string.Join("/", this.SAC, this.SIC);
                this.sensor = data.RadarStationList.Find(r => r.sac_sic == this.dataSourceIdentifier && r.type != "ADS-B").radarStation;
                this.row[2] = this.dataSourceIdentifier; data.filledDataItems[2] = true;
                this.row[3] = this.sensor; data.filledDataItems[3] = true;
            }
            else if (FRN == 2)
            {
                this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                this.row[4] = this.timeOfDay.timeUTC; data.filledDataItems[4] = true;
            }
            else if (FRN == 3)
            {
                this.targetReportDescriptorCAT48 = new TargetReportDescriptorCAT48(BinList);
                this.row[10] = moreInfo; data.filledDataItems[10] = true;
            }
            else if (FRN == 4)
            {
                this.measuredPositionPolar = new PositionPolarCoordinates(BinList, category);
                this.positionCartesian.x = this.measuredPositionPolar.rho * Math.Sin(this.measuredPositionPolar.theta * Math.PI / 180.0);
                this.positionCartesian.y = this.measuredPositionPolar.rho * Math.Cos(this.measuredPositionPolar.theta * Math.PI / 180.0);
                this.row[12] = Math.Round(this.measuredPositionPolar.rho, 3) + " || " + Math.Round(this.measuredPositionPolar.theta, 3);
                data.filledDataItems[12] = true;
                UTM2WGS84(data.RadarStationList.Find(r => r.radarStation == this.sensor).UTMzone, data.RadarStationList.Find(r => r.radarStation == this.sensor).UTMnorthing, data.RadarStationList.Find(r => r.radarStation == this.sensor).UTMeasting);
            }
            else if (FRN == 5)
            {
                this.mode3A = new Mode3A(BinList, category);
                this.row[8] = this.mode3A.Reply + " *"; data.filledDataItems[8] = true;
            }
            else if (FRN == 6)
            {
                this.flightLevel = new FlightLevel(BinList);
                this.row[17] = "FL" + this.flightLevel.FL + " *"; data.filledDataItems[17] = true;
            }
            else if (FRN == 7)
            {
                for (int bit = 0; bit < BinList.Count; bit++)
                {
                    List<string> BinRPC_Subfield = new List<string>();
                    if (BinList[bit] == "1")
                    {
                        BinRPC_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex]));
                        this.firstIndex += 1;
                        if (bit == 0) //SRL Subfield
                        {
                            this.radarPlotCharacteristics.SRL = (Convert.ToInt32(string.Join("", BinRPC_Subfield), 2) * 360 / Math.Pow(2, 13)).ToString(); //[º]
                            this.radarPlotCharacteristics.InsertSCSinfoInTable("SRL [º]", Math.Round(Convert.ToDouble(this.radarPlotCharacteristics.SRL), 3).ToString());
                        }
                        else if (bit == 1) //SRR Subfield
                        {
                            this.radarPlotCharacteristics.SRR = Convert.ToInt32(string.Join("", BinRPC_Subfield), 2).ToString(); //[-]
                            this.radarPlotCharacteristics.InsertSCSinfoInTable("SRR replies", this.radarPlotCharacteristics.SRR);
                        }
                        else if (bit == 2) //SAM Subfield
                        {
                            this.radarPlotCharacteristics.SAM = binTwosComplementToSignedDecimal(string.Join("", BinRPC_Subfield), 8).ToString(); //[dBm]
                            this.radarPlotCharacteristics.InsertSCSinfoInTable("SAM [dBm]", this.radarPlotCharacteristics.SAM);
                        }
                        else if (bit == 3) //PRL Subfield
                        {
                            this.radarPlotCharacteristics.PRL = (Convert.ToInt32(string.Join("", BinRPC_Subfield), 2) * 360 / Math.Pow(2, 13)).ToString(); //[º]
                            this.radarPlotCharacteristics.InsertSCSinfoInTable("PRL [º]", Math.Round(Convert.ToDouble(this.radarPlotCharacteristics.PRL), 3).ToString());
                        }
                        else if (bit == 4) //PAM Subfield
                        {
                            this.radarPlotCharacteristics.PAM = binTwosComplementToSignedDecimal(string.Join("", BinRPC_Subfield), 8).ToString(); //[-]
                            this.radarPlotCharacteristics.InsertSCSinfoInTable("PAM [dBm]", this.radarPlotCharacteristics.PAM);
                        }
                        else if (bit == 5) //RPD Subfield
                        {
                            this.radarPlotCharacteristics.RPD = (binTwosComplementToSignedDecimal(string.Join("", BinRPC_Subfield), 8) * 1 / 256.0).ToString(); //[NM]
                            this.radarPlotCharacteristics.InsertSCSinfoInTable("RPD [NM]", Math.Round(Convert.ToDouble(this.radarPlotCharacteristics.RPD), 3).ToString());
                        }
                        else if (bit == 6) //APD Subfield
                        {
                            this.radarPlotCharacteristics.APD = (Convert.ToInt32(string.Join("", BinRPC_Subfield), 2) * 360 / Math.Pow(2, 14)).ToString(); //[º]
                            this.radarPlotCharacteristics.InsertSCSinfoInTable("APD [º]", Math.Round(Convert.ToDouble(this.radarPlotCharacteristics.APD), 3).ToString());
                        }
                    }
                }
                this.row[27] = moreInfo; data.filledDataItems[27] = true;
            }
            else if (FRN == 8)
            {
                this.ICAOAdress = string.Join("", BinList);
                this.row[7] = this.ICAOAdress; data.filledDataItems[7] = true;
            }
            else if (FRN == 9)
            {
                this.callsign = new TargetIdentification(BinList);
                this.row[6] = this.callsign.TargetID; data.filledDataItems[6] = true;
            }
            else if (FRN == 10)
            {
                this.modeS_MBData = new ModeS_MBData(BinList);
                this.row[54] = this.modeS_MBData.REP + " register(s) *"; data.filledDataItems[54] = true;
            }
            else if (FRN == 11)
            {
                this.trackNumber = Convert.ToInt32(string.Join("", BinList), 2).ToString().PadLeft(4, '0');
                this.row[5] = this.trackNumber; data.filledDataItems[5] = true;
            }
            else if (FRN == 12)
            {
                this.positionCartesian = new PositionCartesianCoordinates(BinList, category);
                this.row[13] = Math.Round(this.positionCartesian.x, 3) + " || " + Math.Round(this.positionCartesian.y, 3);
                data.filledDataItems[13] = true;
                UTM2WGS84(data.RadarStationList.Find(r => r.radarStation == this.sensor).UTMzone, data.RadarStationList.Find(r => r.radarStation == this.sensor).UTMnorthing, data.RadarStationList.Find(r => r.radarStation == this.sensor).UTMeasting);
            }
            else if (FRN == 13)
            {
                this.trackVelocityPolar = new TrackVelocityPolarCoordinates(BinList);
                this.row[14] = Math.Round(this.trackVelocityPolar.groundSpeed, 3) + " || " + Math.Round(this.trackVelocityPolar.trackAngle, 3);
                data.filledDataItems[14] = true;
            }
            else if (FRN == 14)
            {
                this.trackStatusCAT48 = new TrackStatusCAT48(BinList);
                this.row[42] = moreInfo; data.filledDataItems[42] = true;
            }
            else if (FRN == 15)
            {
                this.trackQuality = new TrackQuality(BinList);
                this.row[96] = Math.Round(Convert.ToDouble(this.trackQuality.sigmaX), 3).ToString() + " || " + Math.Round(Convert.ToDouble(this.trackQuality.sigmaY), 3).ToString() + " || " + Math.Round(Convert.ToDouble(this.trackQuality.sigmaV), 3).ToString() + " || " + Math.Round(Convert.ToDouble(this.trackQuality.sigmaX), 3).ToString();
                data.filledDataItems[96] = true;
            }
            else if (FRN == 16)
            {
                List<string> defaultWC = new List<string>() { "Not defined; never used", "Multipath Reply (Reflection)", "Reply due to sidelobe interrogation/reception", "Split plot", "Second time around reply", "Angel", "Slow moving target correlated with road infrastructure (terrestrial vehicle)", "Fixed PSR plot", "Slow PSR target", "Low quality PSR plot", "Phantom SSR plot", "Non-Matching Mode-3/A Code", "Mode C code / Mode S altitude code abnormal value compared to the track", "Target in Clutter Area", "Maximum Doppler Response in Zero Filter", "Transponder anomaly detected", "Duplicated or Illegal Mode S Aircraft Address", "Mode S error correction applied", "Undecodable Mode C code / Mode S altitude code", "Birds", "Flock of Birds", "Mode-1 was present in original reply", "Mode-2 was present in original reply", "Plot potentially caused by Wind Turbine", "Helicopter", "Maximum number of re-interrogations reached (surveillance information)", "Maximum number of re-interrogations reached (BDS Extractions)", "BDS Overlay Incoherence", "Potential BDS Swap Detected", "Track Update in the Zenithal Gap", "Mode S Track re-acquired", "Duplicated Mode 5 Pair NO/PIN detected" };
                for (int octets = 0; octets < BinList.Count / 8; octets++)
                {
                    List<string> infoOctet = new List<string>();
                    for (int bit = 0; bit < 7; bit++)
                        infoOctet.Add(BinList[bit + octets * 8]);
                    this.warningConditions = defaultWC[Convert.ToInt32(string.Join("", infoOctet), 2)];
                }
                this.row[41] = this.warningConditions; data.filledDataItems[41] = true;
            }
            else if (FRN == 17)
            {
                this.mode3AConfidenceIndicator = Convert.ToString(Convert.ToInt32(string.Join("", BinList), 2), 8).PadLeft(4, '0'); ;
                this.row[23] = mode3AConfidenceIndicator; data.filledDataItems[23] = true;
            }
            else if (FRN == 18)
            {
                this.modeC_ConfidenceIndicator = new ModeC_ConfidenceIndicator(BinList);
                this.row[24] = modeC_ConfidenceIndicator.grayHeight + "/" + modeC_ConfidenceIndicator.qualityPulse;
                data.filledDataItems[24] = true;
            }
            else if (FRN == 19)
            {
                this.measuredHeight3DRadar = (binTwosComplementToSignedDecimal(string.Join("", BinList.GetRange(2, 14)), 14) * 25).ToString(); // [ft]
                this.row[97] = this.measuredHeight3DRadar; data.filledDataItems[97] = true;
            }
            else if (FRN == 20)
            {
                for (int bit = 0; bit < BinList.Count; bit++)
                {
                    List<string> BinRDS_Subfield = new List<string>();
                    if (BinList[bit] == "1")
                    {
                        if (bit == 0) //CAL Subfield
                        {
                            for (int i = 0; i < 2; i++)
                                BinRDS_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex + i]));
                            this.firstIndex += 1;
                            List<string> defaultWC = new List<string>() { "Doppler speed is valid", "Doppler speed is doubtful" };
                            this.radialDopplerSpeed.D = defaultWC[Convert.ToInt32(BinRDS_Subfield[0], 2)];
                            this.radialDopplerSpeed.InsertRDSinfoInTable("D", this.radialDopplerSpeed.D);
                            this.radialDopplerSpeed.CAL = binTwosComplementToSignedDecimal(string.Join("", BinRDS_Subfield.GetRange(6, 10)), 10).ToString(); //[m/s]
                            this.radialDopplerSpeed.InsertRDSinfoInTable("CAL", this.radialDopplerSpeed.CAL);
                        }
                        else if (bit == 1) //RDS Subfield
                        {
                            BinRDS_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex]));
                            this.firstIndex += 1;
                            this.radialDopplerSpeed.REP = Convert.ToInt32(string.Join("", BinRDS_Subfield), 2).ToString();
                            for (int i = 0; i < 6 * Convert.ToInt32(this.radialDopplerSpeed.REP); i++)
                            { BinRDS_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                            for (int i = 0; i < Convert.ToInt32(this.radialDopplerSpeed.REP); i++)
                            {
                                this.radialDopplerSpeed.DOP = Convert.ToInt32(string.Join("", BinRDS_Subfield.GetRange(8 + 48 * i, 16)), 2).ToString(); //[m/s]
                                this.radialDopplerSpeed.AMB = Convert.ToInt32(string.Join("", BinRDS_Subfield.GetRange(24 + 48 * i, 16)), 2).ToString(); //[m/s]
                                this.radialDopplerSpeed.FRQ = Convert.ToInt32(string.Join("", BinRDS_Subfield.GetRange(40 + 48 * i, 16)), 2).ToString(); //[MHz]
                            }
                        }
                    }
                }
                this.row[63] = moreInfo; data.filledDataItems[63] = true;
            }
            else if (FRN == 21)
            {
                this.ACAS_CapabilitiesFlightStatus = new ACAS_CapabilitiesFlightStatus(BinList);
                this.row[55] = moreInfo; data.filledDataItems[55] = true;
            }
            else if (FRN == 22)
            {
                this.ACAS_ResolutionAdvisoryReport = new ACAS_ResolutionAdvisoryReport(BinList);
                this.row[93] = moreInfo; data.filledDataItems[93] = true;
            }
            else if (FRN == 23)
            {
                this.mode1 = new Mode1(BinList);
                this.row[98] = this.mode1.Reply + " *"; data.filledDataItems[98] = true;
            }
            else if (FRN == 24)
            {
                this.mode2 = new Mode2(BinList);
                this.row[62] = this.mode2.Reply + " *"; data.filledDataItems[62] = true;
            }
            else if (FRN == 25)
            {
                this.mode2ConfidenceIndicator = Convert.ToString(Convert.ToInt32(string.Join("", BinList.GetRange(3, 5)), 2), 8);
                this.row[99] = mode2ConfidenceIndicator; data.filledDataItems[99] = true;
            }
            else if (FRN == 26)
            {
                this.mode2ConfidenceIndicator = Convert.ToString(Convert.ToInt32(string.Join("", BinList.GetRange(4, 12)), 2), 8);
                this.row[65] = mode2ConfidenceIndicator; data.filledDataItems[65] = true;
            }
        }

        public void obtainBinListCAT62()
        {
            if (FRN == 11 || FRN == 13 || FRN == 16 || FRN == 21 || FRN == 22 || FRN == 24 || FRN == 26 || FRN == 27 || FRN == 28) //Data Items de longitud de octetos variable con fx
            {
                for (int octets = 0; octets < OctetsDataItemsCAT62[FRN - 1]; octets++)
                { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                fx = true;
                while (fx)
                {
                    if (BinList[BinList.Count - 1] == "1")
                    {
                        for (int octets = 0; octets < OctetsDataItemsCAT62[FRN - 1]; octets++)
                        { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                    }
                    else
                        fx = false;
                }
            }
            else if (FRN == 34 || FRN == 35) // Reserved Expansion and Special Purpose Fields
            {
                while (this.firstIndex < this.Message.Count)
                    this.firstIndex++;
            }
            else // Data Items with fixed octets lenght
            {
                for (int octets = 0; octets < OctetsDataItemsCAT62[FRN - 1]; octets++)
                { BinList.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
            }
        }

        // Function that decodes all the CAT62 Data Items
        public void DecodeCAT62()
        {
            obtainBinListCAT62();
            if (FRN == 1)
            {
                this.SAC = Convert.ToInt32(string.Join("", BinList.GetRange(0, 8)), 2).ToString().PadLeft(3, '0');
                this.SIC = Convert.ToInt32(string.Join("", BinList.GetRange(8, 8)), 2).ToString().PadLeft(3, '0');
                this.dataSourceIdentifier = string.Join("/", this.SAC, this.SIC);
                this.sensor = data.RadarStationList.Find(r => r.sac_sic == this.dataSourceIdentifier && r.type != "ADS-B").radarStation;
                this.row[2] = this.dataSourceIdentifier; data.filledDataItems[2] = true;
                this.row[3] = this.sensor; data.filledDataItems[3] = true;
            }
            else if (FRN == 3)
            {
                this.serviceIdentification = Convert.ToString(Convert.ToInt32(string.Join("", BinList), 2));
                this.row[26] = this.serviceIdentification; data.filledDataItems[26] = true;
            }
            else if (FRN == 4)
            {
                this.timeOfDay = new TimeOfDay(BinList, category, numberOftruncatedTimes);
                this.row[4] = this.timeOfDay.timeUTC; data.filledDataItems[4] = true;
            }
            else if (FRN == 5)
            {
                this.positionWGS84 = new PositionWGS84Coordinates(BinList, this.category);
                this.row[11] = Math.Round(this.positionWGS84.latitude, 5) + " || " + Math.Round(this.positionWGS84.longitude, 5);
                data.filledDataItems[11] = true;
            }
            else if (FRN == 6)
            {
                this.positionCartesian = new PositionCartesianCoordinates(BinList, category);
                this.row[13] = Math.Round(this.positionCartesian.x, 3) + " || " + Math.Round(this.positionCartesian.y, 3);
                data.filledDataItems[13] = true;
            }
            else if (FRN == 7)
            {
                this.trackVelocityCartesian = new TrackVelocityCartesianCoordinates(BinList);
                this.row[15] = this.trackVelocityCartesian.Vx + " || " + this.trackVelocityCartesian.Vy;
                data.filledDataItems[15] = true;
            }
            else if (FRN == 8)
            {
                this.calculatedAcceleration = new CalculatedAcceleration(BinList);
                this.row[16] = this.calculatedAcceleration.Ax + " || " + this.calculatedAcceleration.Ay;
                data.filledDataItems[16] = true;
            }
            else if (FRN == 9)
            {
                this.mode3A = new Mode3A(BinList, category);
                this.row[8] = this.mode3A.Reply + " *"; data.filledDataItems[8] = true;
            }
            else if (FRN == 10)
            {
                this.callsign = new TargetIdentification(BinList);
                this.row[6] = this.callsign.TargetID; data.filledDataItems[6] = true;
            }
            else if (FRN == 11)
            {
                List<int> OctetsADD = new List<int>() { 3, 6, 2, 2, 2, 2, 2, 0, 1, 1, 2, 2, 7, 2, 2, 0, 2, 2, 2, 2, 1, 8, 1, 0, 6, 2, 1, 1, 2, 2, 2, 0 };
                for (int bit = 0; bit < BinList.Count; bit++)
                {
                    List<string> BinADD_Subfield = new List<string>();
                    if (BinList[bit] == "1" && (bit - 7) % 8 != 0) // Eliminate fx=1
                    {
                        for (int octets = 0; octets < OctetsADD[bit]; octets++)
                        {
                            if (bit == 0) // ICAO Address does not need to convert to HEX
                                BinADD_Subfield.Add(this.Message[this.firstIndex]);
                            else
                                BinADD_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex]));
                            this.firstIndex += 1;
                        }
                        if (bit == 0) //ADR Subfield
                        {
                            this.aircraftDerivedData.ICAOaddress = string.Join("", BinADD_Subfield);
                            this.aircraftDerivedData.InsertADDinfoInTable("ICAO Address", this.aircraftDerivedData.ICAOaddress);
                            this.ICAOAdress = this.aircraftDerivedData.ICAOaddress;
                            this.row[7] = this.ICAOAdress; data.filledDataItems[7] = true;
                        }
                        else if (bit == 1) //ID Subfield
                        {
                            this.aircraftDerivedData.callsign = new TargetIdentification(BinADD_Subfield);
                            this.aircraftDerivedData.InsertADDinfoInTable("Callsign", this.aircraftDerivedData.callsign.TargetID);
                        }
                        else if (bit == 2) //MHG Subfield
                        {
                            this.aircraftDerivedData.magneticHeading = (Convert.ToInt32(string.Join("", BinADD_Subfield), 2) * 360 / Math.Pow(2, 16)).ToString();
                            this.aircraftDerivedData.InsertADDinfoInTable("Magnetic Heading [º]", Math.Round(Convert.ToDouble(this.aircraftDerivedData.magneticHeading), 3).ToString());
                        }
                        else if (bit == 3) //IAS Subfield
                        {
                            this.aircraftDerivedData.airspeed = new AirSpeed(BinADD_Subfield);
                            this.aircraftDerivedData.InsertADDinfoInTable(this.aircraftDerivedData.airspeed.TypeAirSpeed, this.aircraftDerivedData.airspeed.AirSpeedValue);
                        }
                        else if (bit == 4) //TAS Subfield
                        {
                            this.aircraftDerivedData.trueAirspeed = Convert.ToInt32(string.Join("", BinADD_Subfield), 2).ToString();
                            this.aircraftDerivedData.InsertADDinfoInTable("True Airspeed [kt]", this.aircraftDerivedData.trueAirspeed);
                        }
                        else if (bit == 5) //SAL Subfield
                        {
                            this.aircraftDerivedData.selectedAltitude = new SelectedAltitude(BinADD_Subfield);
                            this.aircraftDerivedData.InsertADDinfoInTable("SAS", this.aircraftDerivedData.selectedAltitude.SAS);
                            this.aircraftDerivedData.InsertADDinfoInTable("Source", this.aircraftDerivedData.selectedAltitude.Source);
                            this.aircraftDerivedData.InsertADDinfoInTable("Altitude [ft]", this.aircraftDerivedData.selectedAltitude.Altitude);
                        }
                        else if (bit == 6) //FSS Subfield
                        {
                            this.aircraftDerivedData.finalSelectedAltitude = new FinalSelectedAltitude(BinADD_Subfield);
                            this.aircraftDerivedData.InsertADDinfoInTable("MV", this.aircraftDerivedData.finalSelectedAltitude.MV);
                            this.aircraftDerivedData.InsertADDinfoInTable("AH", this.aircraftDerivedData.finalSelectedAltitude.AH);
                            this.aircraftDerivedData.InsertADDinfoInTable("AM", this.aircraftDerivedData.finalSelectedAltitude.AM);
                            this.aircraftDerivedData.InsertADDinfoInTable("Altitude [ft]", this.aircraftDerivedData.finalSelectedAltitude.Altitude);
                        }
                        else if (bit == 8) //TIS Subfield
                        {
                            this.aircraftDerivedData.trajectoryIntentStatus = new TrajectoryIntentStatus(BinADD_Subfield);
                            this.aircraftDerivedData.InsertADDinfoInTable("NAV", this.aircraftDerivedData.trajectoryIntentStatus.NAV);
                            this.aircraftDerivedData.InsertADDinfoInTable("NVB", this.aircraftDerivedData.trajectoryIntentStatus.NVB);
                        }
                        else if (bit == 9) //TID Subfield
                        {
                            this.aircraftDerivedData.trajectoryIntentData.REP = Convert.ToInt32(string.Join("", BinADD_Subfield), 2).ToString();
                            for (int i = 0; i < 15 * Convert.ToInt32(this.aircraftDerivedData.trajectoryIntentData.REP); i++)
                            {
                                BinADD_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex]));
                                this.firstIndex += 1;
                            }
                            this.aircraftDerivedData.trajectoryIntentData = new TrajectoryIntentData(BinADD_Subfield);
                            for (int i = 0; i < this.aircraftDerivedData.trajectoryIntentData.TableTID.Count; i += 2)
                                this.aircraftDerivedData.InsertADDinfoInTable(this.aircraftDerivedData.trajectoryIntentData.TableTID[i], this.aircraftDerivedData.trajectoryIntentData.TableTID[i + 1]);
                        }
                        else if (bit == 10) //COM Subfield
                        {
                            this.aircraftDerivedData.ACAS_CapabilitiesFlightStatus = new ACAS_CapabilitiesFlightStatus(BinADD_Subfield);
                            for (int i = 0; i < this.aircraftDerivedData.ACAS_CapabilitiesFlightStatus.TableACAS_CFS.Count; i += 2)
                                this.aircraftDerivedData.InsertADDinfoInTable(this.aircraftDerivedData.ACAS_CapabilitiesFlightStatus.TableACAS_CFS[i], this.aircraftDerivedData.ACAS_CapabilitiesFlightStatus.TableACAS_CFS[i + 1]);
                        }
                        else if (bit == 11) //SAB Subfield
                        {
                            this.aircraftDerivedData.statusADSB = new StatusADSB(BinADD_Subfield);
                            for (int i = 0; i < this.aircraftDerivedData.statusADSB.TableSADSB.Count; i += 2)
                                this.aircraftDerivedData.InsertADDinfoInTable(this.aircraftDerivedData.statusADSB.TableSADSB[i], this.aircraftDerivedData.statusADSB.TableSADSB[i + 1]);
                        }
                        else if (bit == 12) //ACS Subfield
                        {
                            this.aircraftDerivedData.ACAS_ResolutionAdvisoryReport = new ACAS_ResolutionAdvisoryReport(BinADD_Subfield);
                            for (int i = 0; i < this.aircraftDerivedData.ACAS_ResolutionAdvisoryReport.TableACAS_RAR.Count; i += 2)
                                this.aircraftDerivedData.InsertADDinfoInTable(this.aircraftDerivedData.ACAS_ResolutionAdvisoryReport.TableACAS_RAR[i], this.aircraftDerivedData.ACAS_ResolutionAdvisoryReport.TableACAS_RAR[i + 1]);
                        }
                        else if (bit == 13) //BVR Subfield
                        {
                            this.aircraftDerivedData.barometricVerticalRate = (binTwosComplementToSignedDecimal(string.Join("", BinADD_Subfield), 16) * 6.25).ToString(); //[ft/min]
                            this.aircraftDerivedData.InsertADDinfoInTable("Barometric Vertical Rate [ft/min]", this.aircraftDerivedData.barometricVerticalRate);
                        }
                        else if (bit == 14) //GVR Subfield
                        {
                            this.aircraftDerivedData.geometricVerticalRate = (binTwosComplementToSignedDecimal(string.Join("", BinADD_Subfield), 16) * 6.25).ToString(); //[ft/min]
                            this.aircraftDerivedData.InsertADDinfoInTable("Geometric Vertical Rate [ft/min]", this.aircraftDerivedData.geometricVerticalRate);
                        }
                        else if (bit == 16) //RAN Subfield
                        {
                            this.aircraftDerivedData.rollAngle = (binTwosComplementToSignedDecimal(string.Join("", BinADD_Subfield), BinADD_Subfield.Count()) * 0.01).ToString();
                            this.aircraftDerivedData.InsertADDinfoInTable("Roll Angle [º]", this.aircraftDerivedData.rollAngle);
                        }
                        else if (bit == 17) //TAR Subfield
                        {
                            this.aircraftDerivedData.rateOfTurn = new RateOfTurn(BinADD_Subfield);
                            this.aircraftDerivedData.InsertADDinfoInTable("Rate of turn [º]", this.aircraftDerivedData.rateOfTurn.rateOfTurn + " (" + this.aircraftDerivedData.rateOfTurn.turnIndicator + ")");
                        }
                        else if (bit == 18) //TAN Subfield
                        {
                            this.aircraftDerivedData.trackAngle = (Convert.ToInt32(string.Join("", BinADD_Subfield), 2) * 360 / Math.Pow(2, 16)).ToString(); //[º]
                            this.aircraftDerivedData.InsertADDinfoInTable("Track Angle [º]", this.aircraftDerivedData.trackAngle);
                        }
                        else if (bit == 19) //GSP Subfield
                        {
                            this.aircraftDerivedData.groundSpeed = (binTwosComplementToSignedDecimal(string.Join("", BinADD_Subfield), BinADD_Subfield.Count) * Math.Pow(2, -14) * 3600).ToString(); //[kt]
                            this.aircraftDerivedData.InsertADDinfoInTable("GroundSpeed [kt]", this.aircraftDerivedData.groundSpeed);
                        }
                        else if (bit == 20) //VUN Subfield
                        {
                            this.aircraftDerivedData.velocityUncertainty = Convert.ToInt32(string.Join("", BinADD_Subfield), 2).ToString();
                            this.aircraftDerivedData.InsertADDinfoInTable("Velocity Uncertainty", this.aircraftDerivedData.velocityUncertainty);
                        }
                        else if (bit == 21) //MET Subfield
                        {
                            this.aircraftDerivedData.metData.WS = Convert.ToInt32(string.Join("", BinADD_Subfield.GetRange(8, 16)), 2).ToString();
                            this.aircraftDerivedData.metData.WD = Convert.ToInt32(string.Join("", BinADD_Subfield.GetRange(16, 16)), 2).ToString();
                            this.aircraftDerivedData.metData.TMP = (binTwosComplementToSignedDecimal(string.Join("", BinADD_Subfield.GetRange(32, 16)), 16) * 0.25).ToString();
                            this.aircraftDerivedData.metData.TRB = Convert.ToInt32(string.Join("", BinADD_Subfield.GetRange(48, 8), 2)).ToString();
                            this.aircraftDerivedData.InsertADDinfoInTable("Wind Speed [kt]", this.aircraftDerivedData.metData.WS);
                            this.aircraftDerivedData.InsertADDinfoInTable("Wind Direction [º]", this.aircraftDerivedData.metData.WD);
                            this.aircraftDerivedData.InsertADDinfoInTable("Temperature [º]", this.aircraftDerivedData.metData.TMP);
                            this.aircraftDerivedData.InsertADDinfoInTable("Turbulence", this.aircraftDerivedData.metData.TRB);
                        }
                        else if (bit == 22) //EMC Subfield
                        {
                            List<string> defaultEmitterCategory = new List<string>() { "N/A", "light aircraft <= 7000 kg", "reserved", "7000 kg < medium aircraft  < 136000 kg ", "reserved", "136000 kg <= heavy aircraft ", "highly manoeuvrable (5g acceleration capability) and high speed (>400 knots cruise)", "reserved", "reserved", "reserved", "rotocraft", "glider/sailplane", "lighter-than-air", "unmanned aerial vehicle", "space/transatmospheric vehicle", "ultralight/handglider/paraglider", "parachutist/skydiver", "reserved", "reserved", "reserved", "surface emergency vehicle", "surface service vehicle", "fixed hround or tethered obstruction", "reserved", "reserved" };
                            if (Convert.ToInt32(string.Join("", BinADD_Subfield), 2) < (defaultEmitterCategory.Count() - 1))
                                this.aircraftDerivedData.emitterCategory = defaultEmitterCategory[Convert.ToInt32(string.Join("", BinADD_Subfield), 2)];
                            this.aircraftDerivedData.InsertADDinfoInTable("Emitter Category", this.aircraftDerivedData.emitterCategory);
                        }
                        else if (bit == 24) //POS Subfield
                        {
                            this.aircraftDerivedData.positionWGS84Coordinates.latitude = binTwosComplementToSignedDecimal(string.Join("", BinADD_Subfield.GetRange(0, BinADD_Subfield.Count / 2)), BinADD_Subfield.Count / 2) * (180 / Math.Pow(2, 23));
                            this.aircraftDerivedData.positionWGS84Coordinates.longitude = binTwosComplementToSignedDecimal(string.Join("", BinADD_Subfield.GetRange(BinADD_Subfield.Count / 2, BinADD_Subfield.Count / 2)), BinADD_Subfield.Count / 2) * (180 / Math.Pow(2, 23));
                            this.aircraftDerivedData.InsertADDinfoInTable("Latitude [º]", Math.Round(this.aircraftDerivedData.positionWGS84Coordinates.latitude, 5).ToString());
                            this.aircraftDerivedData.InsertADDinfoInTable("Longitude [º]", Math.Round(this.aircraftDerivedData.positionWGS84Coordinates.longitude, 5).ToString());
                        }
                        else if (bit == 25) //GAL Subfield
                        {
                            this.aircraftDerivedData.geometricAltitude = (binTwosComplementToSignedDecimal(string.Join("", BinADD_Subfield), BinADD_Subfield.Count()) * 6.25).ToString();
                            this.aircraftDerivedData.InsertADDinfoInTable("Geometric Altitude [ft]", this.aircraftDerivedData.geometricAltitude);
                        }
                        else if (bit == 26) //PUN Subfield
                        {
                            this.aircraftDerivedData.positionUncertainty = Convert.ToInt32(string.Join("", BinADD_Subfield.GetRange(4, 4)), 2).ToString();
                            this.aircraftDerivedData.InsertADDinfoInTable("Position Uncertainty", this.aircraftDerivedData.positionUncertainty);
                        }
                        else if (bit == 27) //MB Subfield
                        {
                            this.aircraftDerivedData.modeS_MBData.REP = Convert.ToInt32(string.Join("", BinADD_Subfield), 2).ToString();
                            for (int i = 0; i < 8 * Convert.ToInt32(this.aircraftDerivedData.modeS_MBData.REP); i++)
                            {
                                BinADD_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex]));
                                this.firstIndex += 1;
                            }
                            this.aircraftDerivedData.modeS_MBData = new ModeS_MBData(BinADD_Subfield);
                            for (int i = 0; i < this.aircraftDerivedData.modeS_MBData.TableMBD.Count; i += 2)
                                this.aircraftDerivedData.InsertADDinfoInTable(this.aircraftDerivedData.modeS_MBData.TableMBD[i], this.aircraftDerivedData.modeS_MBData.TableMBD[i + 1]);
                        }
                        else if (bit == 28) //IAR Subfield
                        {
                            this.aircraftDerivedData.IndicatedAirSpeed = Convert.ToInt32(string.Join("", BinADD_Subfield), 2).ToString();
                            this.aircraftDerivedData.InsertADDinfoInTable("Indicated AirSpeed [kt]", this.aircraftDerivedData.IndicatedAirSpeed);
                        }
                        else if (bit == 29) //MAC Subfield
                        {
                            this.aircraftDerivedData.machNumber = (Convert.ToInt32(string.Join("", BinADD_Subfield), 2) * 0.008).ToString();
                            this.aircraftDerivedData.InsertADDinfoInTable("Mach Number", this.aircraftDerivedData.machNumber);
                        }
                        else if (bit == 30) //BPS Subfield
                        {
                            this.aircraftDerivedData.barometricPressureSetting = (Convert.ToInt32(string.Join("", BinADD_Subfield.GetRange(4, 12)), 2) * 0.1).ToString();
                            this.aircraftDerivedData.InsertADDinfoInTable("Barometric Pressure Setting [mb]", this.aircraftDerivedData.barometricPressureSetting);
                        }
                    }
                }
                this.row[56] = moreInfo; data.filledDataItems[56] = true;
            }
            else if (FRN == 12)
            {
                this.trackNumber = Convert.ToInt32(string.Join("", BinList), 2).ToString().PadLeft(4, '0');
                this.row[5] = this.trackNumber; data.filledDataItems[5] = true;
            }
            else if (FRN == 13)
            {
                this.trackStatusCAT62 = new TrackStatusCAT62(BinList);
                this.row[42] = moreInfo; data.filledDataItems[42] = true;
            }
            else if (FRN == 14)
            {
                Boolean infoSTUA = false;
                for (int bit = 0; bit < BinList.Count; bit++)
                {
                    List<string> BinSTUA_Subfield = new List<string>();
                    if (BinList[bit] == "1" && (bit - 7) % 8 != 0) // eliminate fx=1
                    {
                        infoSTUA = true;
                        List<int> OctetsSTUA = new List<int>() { 1, 1, 1, 1, 2, 1, 1, 0, 1, 1, 1 };
                        for (int octets = 0; octets < OctetsSTUA[bit]; octets++)
                        { BinSTUA_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                        if (bit == 0) //TRK Subfield
                        {
                            this.systemTrackUpdateAges.TRK = (Convert.ToInt32(string.Join("", BinSTUA_Subfield), 2) * 0.25).ToString();
                            this.systemTrackUpdateAges.InsertSTUAinfoInTable("Track Age [s]", this.systemTrackUpdateAges.TRK);
                        }
                        else if (bit == 1) //PSR Subfield
                        {
                            this.systemTrackUpdateAges.PSR = (Convert.ToInt32(string.Join("", BinSTUA_Subfield), 2) * 0.25).ToString();
                            this.systemTrackUpdateAges.InsertSTUAinfoInTable("PSR Age [s]", this.systemTrackUpdateAges.PSR);
                        }
                        else if (bit == 2) //SSR Subfield
                        {
                            this.systemTrackUpdateAges.SSR = (Convert.ToInt32(string.Join("", BinSTUA_Subfield), 2) * 0.25).ToString();
                            this.systemTrackUpdateAges.InsertSTUAinfoInTable("SSR Age [s]", this.systemTrackUpdateAges.SSR);
                        }
                        else if (bit == 3) //MDS Subfield
                        {
                            this.systemTrackUpdateAges.MDS = (Convert.ToInt32(string.Join("", BinSTUA_Subfield), 2) * 0.25).ToString();
                            this.systemTrackUpdateAges.InsertSTUAinfoInTable("Mode S Age [s]", this.systemTrackUpdateAges.MDS);
                        }
                        else if (bit == 4) //ADS Subfield
                        {
                            this.systemTrackUpdateAges.ADS = (Convert.ToInt32(string.Join("", BinSTUA_Subfield), 2) * 0.25).ToString();
                            this.systemTrackUpdateAges.InsertSTUAinfoInTable("ADS-C Age [s]", this.systemTrackUpdateAges.ADS);
                        }
                        else if (bit == 5) //ES Subfield
                        {
                            this.systemTrackUpdateAges.ES = (Convert.ToInt32(string.Join("", BinSTUA_Subfield), 2) * 0.25).ToString();
                            this.systemTrackUpdateAges.InsertSTUAinfoInTable("ES Age [s]", this.systemTrackUpdateAges.ES);
                        }
                        else if (bit == 6) //VDL Subfield
                        {
                            this.systemTrackUpdateAges.VDL = (Convert.ToInt32(string.Join("", BinSTUA_Subfield), 2) * 0.25).ToString();
                            this.systemTrackUpdateAges.InsertSTUAinfoInTable("VDL Age [s]", this.systemTrackUpdateAges.VDL);
                        }
                        else if (bit == 8) //UAT Subfield
                        {
                            this.systemTrackUpdateAges.UAT = (Convert.ToInt32(string.Join("", BinSTUA_Subfield), 2) * 0.25).ToString();
                            this.systemTrackUpdateAges.InsertSTUAinfoInTable("UAT Age [s]", this.systemTrackUpdateAges.UAT);
                        }
                        else if (bit == 9) //LOP Subfield
                        {
                            this.systemTrackUpdateAges.ADS = (Convert.ToInt32(string.Join("", BinSTUA_Subfield), 2) * 0.25).ToString();
                            this.systemTrackUpdateAges.InsertSTUAinfoInTable("Loop Age [s]", this.systemTrackUpdateAges.LOP);
                        }
                        else if (bit == 10) //MLT Subfield
                        {
                            this.systemTrackUpdateAges.MLT = (Convert.ToInt32(string.Join("", BinSTUA_Subfield), 2) * 0.25).ToString();
                            this.systemTrackUpdateAges.InsertSTUAinfoInTable("Multilateration Age [s]", this.systemTrackUpdateAges.MLT);
                        }
                    }
                }
                if (infoSTUA)
                {this.row[57] = moreInfo; data.filledDataItems[57] = true; }
                else
                    this.row[57] = "N/A";
            }
            else if (FRN == 15)
            {
                this.modeOfMovement = new ModeOfMovement(BinList);
                this.row[58] = moreInfo; data.filledDataItems[58] = true;
            }
            else if (FRN == 16)
            {
                for (int bit = 0; bit < BinList.Count; bit++)
                {
                    List<string> BinTDA_Subfield = new List<string>();
                    if (BinList[bit] == "1" && (bit - 7) % 8 != 0) // eliminate fx=1
                    {
                        BinTDA_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex]));
                        this.firstIndex += 1;
                        if (bit == 0) //Measured Flight Level Age Subfield
                        {
                            this.trackDataAges.MFL = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Measured Flight Level [s]", this.trackDataAges.MFL);
                        }
                        else if (bit == 1) //Mode 1 Age Subfield
                        {
                            this.trackDataAges.MD1 = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Mode 1[s]", this.trackDataAges.MD1);
                        }
                        else if (bit == 2) //Mode 2 Age Subfield
                        {
                            this.trackDataAges.MD2 = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Mode 2 [s]", this.trackDataAges.MD2);
                        }
                        else if (bit == 3) //Mode 3/A Age Subfield
                        {
                            this.trackDataAges.MDA = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Mode 3/A [s]", this.trackDataAges.MDA);
                        }
                        else if (bit == 4) //Mode 4 Age Subfield
                        {
                            this.trackDataAges.MD4 = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Mode 4 [s]", this.trackDataAges.MD4);
                        }
                        else if (bit == 5) //Mode 5 Age Subfield
                        {
                            this.trackDataAges.MD5 = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Mode 5 [s]", this.trackDataAges.MD5);
                        }
                        else if (bit == 6) //Magnetic Heading Age Subfield
                        {
                            this.trackDataAges.MHG = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Magnetic Heading [s]", this.trackDataAges.MHG);
                        }
                        else if (bit == 8) //Indicated Airspeed/Mach Number Age Subfield
                        {
                            this.trackDataAges.IAS = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Indicated Airspeed/Mach Number [s]", this.trackDataAges.IAS);
                        }
                        else if (bit == 9) //True Airspeed Age Subfield
                        {
                            this.trackDataAges.TAS = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("True Airspeed [s]", this.trackDataAges.TAS);
                        }
                        else if (bit == 10) //Selected Altitude Age Subfield
                        {
                            this.trackDataAges.SAL = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Selected Altitude [s]", this.trackDataAges.SAL);
                        }
                        else if (bit == 11) //Final State Selected Altitude Age Subfield
                        {
                            this.trackDataAges.FSS = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Final State Selected Altitude [s]", this.trackDataAges.FSS);
                        }
                        else if (bit == 12) //Trajectory Intent Age Subfield
                        {
                            this.trackDataAges.TID = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Trajectory Intent [s]", this.trackDataAges.TID);
                        }
                        else if (bit == 13) //Communication/ACAS Capability and Flight Status Age Subfield
                        {
                            this.trackDataAges.COM = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("ACAS Capability and Flight Status [s]", this.trackDataAges.COM);
                        }
                        else if (bit == 14) //Status Reported by ADS-B Age Subfield
                        {
                            this.trackDataAges.SAB = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Status Reported by ADS-B [s]", this.trackDataAges.SAB);
                        }
                        else if (bit == 16) //ACAS Resolution Advisory Report Age Subfield
                        {
                            this.trackDataAges.ACS = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("ACAS Resolution Advisory Report [s]", this.trackDataAges.ACS);
                        }
                        else if (bit == 17) //Barometric Vertical Rate Age Subfield
                        {
                            this.trackDataAges.BVR = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Barometric Vertical Rate [s]", this.trackDataAges.BVR);
                        }
                        else if (bit == 18) //Geometrical Vertical Rate Age Subfield
                        {
                            this.trackDataAges.GVR = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Geometrical Vertical Rate [s]", this.trackDataAges.GVR);
                        }
                        else if (bit == 19) //Roll Angle Age Subfield
                        {
                            this.trackDataAges.RAN = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Roll Angle Rate [s]", this.trackDataAges.RAN);
                        }
                        else if (bit == 20) //Track Angle Rate Age Subfield
                        {
                            this.trackDataAges.TAR = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Track Angle Rate [s]", this.trackDataAges.TAR);
                        }
                        else if (bit == 21) //Track Angle Age Subfield
                        {
                            this.trackDataAges.TAN = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("//Track Angle [s]", this.trackDataAges.TAN);
                        }
                        else if (bit == 22) //Ground Speed Age Subfield
                        {
                            this.trackDataAges.GSP = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Ground Speed [s]", this.trackDataAges.GSP);
                        }
                        else if (bit == 24) //Velocity Uncertainty Age Subfield
                        {
                            this.trackDataAges.VUN = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Velocity Uncertainty [s]", this.trackDataAges.VUN);
                        }
                        else if (bit == 25) //Meteorological Data Age Subfield
                        {
                            this.trackDataAges.MET = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Meteorological Data [s]", this.trackDataAges.MET);
                        }
                        else if (bit == 26) //Emitter Category Age Subfield
                        {
                            this.trackDataAges.EMC = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Emitter Category [s]", this.trackDataAges.EMC);
                        }
                        else if (bit == 27) //Position Age Subfield
                        {
                            this.trackDataAges.POS = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Position [s]", this.trackDataAges.POS);
                        }
                        else if (bit == 28) //Geometric Altitude Age Subfield
                        {
                            this.trackDataAges.GAL = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Geometric Altitude [s]", this.trackDataAges.GAL);
                        }
                        else if (bit == 29) //Position Uncertainty Age Subfield
                        {
                            this.trackDataAges.PUN = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Position Uncertainty [s]", this.trackDataAges.PUN);
                        }
                        else if (bit == 30) //Mode S MB Data Age Subfield
                        {
                            this.trackDataAges.MB = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Mode S MB Data [s]", this.trackDataAges.MB);
                        }
                        else if (bit == 32) //Indicated Airspeed Data Age Subfield
                        {
                            this.trackDataAges.IAR = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Indicated Airspeed Data [s]", this.trackDataAges.IAR);
                        }
                        else if (bit == 33) //Mach Number Data Age Subfield
                        {
                            this.trackDataAges.MAC = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Mach Number Data [s]", this.trackDataAges.MAC);
                        }
                        else if (bit == 34) //Barometric Pressure Setting Age Subfield
                        {
                            this.trackDataAges.BPS = (Convert.ToInt32(string.Join("", BinTDA_Subfield), 2) * 0.25).ToString();
                            this.trackDataAges.InsertTDAinfoInTable("Barometric Pressure Setting [s]", this.trackDataAges.BPS);
                        }
                    }
                }
                this.row[51] = moreInfo; data.filledDataItems[51] = true;
            }
            else if (FRN == 17)
            {
                this.flightLevel.FL = (binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count) * 0.25).ToString(); //[FL]
                this.flightLevel.altitude = Convert.ToDouble(this.flightLevel.FL) * 30.48; // [m]
                if (this.flightLevel.altitude < 0)
                    this.flightLevel.altitude = 0;
                this.row[17] = "FL" + this.flightLevel.FL; data.filledDataItems[17] = true;
            }
            else if (FRN == 18)
            {
                this.geometricAltitude = (binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count) * 6.25).ToString(); //[ft]
                this.row[18] = this.geometricAltitude; data.filledDataItems[18] = true;
            }
            else if (FRN == 19)
            {
                List<string> defaultQNH = new List<string>() { "QNH not applied", "QHN applied" };
                this.barometricAltitude = (binTwosComplementToSignedDecimal(string.Join("", BinList.GetRange(1, 15)), 15) * 0.25).ToString(); //[FL]
                this.row[19] = "FL" + this.barometricAltitude + " (" + defaultQNH[Convert.ToInt32(BinList[0], 2)] + ")";
                data.filledDataItems[19] = true;
            }
            else if (FRN == 20)
            {
                this.rateOfClimb = (binTwosComplementToSignedDecimal(string.Join("", BinList), BinList.Count) * 6.25).ToString(); //[ft/min]
                this.row[21] = this.rateOfClimb; data.filledDataItems[21] = true;
            }
            else if (FRN == 21)
            {
                for (int bit = 0; bit < BinList.Count; bit++)
                {
                    List<string> BinFPRD_Subfield = new List<string>();
                    if (BinList[bit] == "1" && (bit - 7) % 8 != 0) // eliminate fx=1
                    {
                        List<int> OctetsFPRD = new List<int>() { 2, 7, 4, 1, 4, 1, 4, 0, 4, 3, 2, 2, 1, 6, 1, 0, 7, 7, 2, 7 };
                        for (int octets = 0; octets < OctetsFPRD[bit]; octets++)
                        { BinFPRD_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                        if (bit == 0) //SAC/SIC Subfield
                        {
                            string SAC = Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(0, 8)), 2).ToString().PadLeft(3, '0');
                            string SIC = Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(8, 8)), 2).ToString().PadLeft(3, '0');
                            this.flightPlanRelatedData.DSI = string.Join("/", SAC, SIC);
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("SAC/SIC", this.flightPlanRelatedData.DSI);
                        }
                        else if (bit == 1) //Callsign Subfield
                        {
                            this.flightPlanRelatedData.callsign = "";
                            for (int ch = 0; ch < 7; ch++)
                            { string character = string.Join("", BinFPRD_Subfield.GetRange(2 + ch * 8, 6)); this.flightPlanRelatedData.callsign += this.callsign.CodingRules(character); }
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Callsign", this.flightPlanRelatedData.callsign);
                        }
                        else if (bit == 2) //IFPS_FLIGHT_ID Subfield
                        {
                            List<string> defaultTYP = new List<string>() { "Plan Number", "Unit 1 internal flight number", "Unit 2 internal flight number", "Unit 3 internal flight number" };
                            this.flightPlanRelatedData.IFPS_FLIGHT_ID = Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(5, 27)), 2).ToString() + " (" + defaultTYP[Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(0, 2)), 2)] + ")";
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("IFPS flight ID", this.flightPlanRelatedData.IFPS_FLIGHT_ID);
                        }
                        else if (bit == 3) //Flight Category Subfield
                        {
                            this.flightPlanRelatedData.flightCategory = new FlightCategory(BinFPRD_Subfield);
                            for (int i = 0; i < this.flightPlanRelatedData.flightCategory.TableFC.Count; i += 2)
                                this.flightPlanRelatedData.InsertFPRDinfoInTable(this.flightPlanRelatedData.flightCategory.TableFC[i], this.flightPlanRelatedData.flightCategory.TableFC[i + 1]);
                        }
                        else if (bit == 4) //Type of Aircraft Subfield
                        {
                            this.flightPlanRelatedData.aircraftType = "";
                            for (int ch = 0; ch < 4; ch++)
                            { string character = string.Join("", BinFPRD_Subfield.GetRange(2 + ch * 8, 6)); this.flightPlanRelatedData.aircraftType += this.callsign.CodingRules(character); }
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Aircraft Type", this.flightPlanRelatedData.aircraftType);
                        }
                        else if (bit == 5) //Wake Turbulence Category Subfield
                        {
                            List<string> defaultWTC = new List<string>() { "Light", "Medium", "Heavy", "“Super”" };
                            List<string> defaultInitialWTC = new List<string>() { "L", "M", "H", " J" };
                            for (int i = 0; i < defaultInitialWTC.Count; i++)
                            {
                                if (this.callsign.CodingRules(string.Join("", BinFPRD_Subfield)) == defaultInitialWTC[i])
                                    this.flightPlanRelatedData.wakeTurbulenceCategory = defaultWTC[i];
                            }
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Wake Turbulence Category", this.flightPlanRelatedData.wakeTurbulenceCategory);
                        }
                        else if (bit == 6) //Departure Airport Subfield
                        {
                            this.flightPlanRelatedData.departureAirport = "";
                            for (int ch = 0; ch < 4; ch++)
                            { string character = string.Join("", BinFPRD_Subfield.GetRange(2 + ch * 8, 6)); this.flightPlanRelatedData.departureAirport += this.callsign.CodingRules(character); }
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Departure Airport", this.flightPlanRelatedData.departureAirport);
                        }
                        else if (bit == 8) //Destination Airport Subfield
                        {
                            this.flightPlanRelatedData.destinationAirport = "";
                            for (int ch = 0; ch < 4; ch++)
                            { string character = string.Join("", BinFPRD_Subfield.GetRange(2 + ch * 8, 6)); this.flightPlanRelatedData.destinationAirport += this.callsign.CodingRules(character); }
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Destination Airport", this.flightPlanRelatedData.destinationAirport);
                        }
                        else if (bit == 9) //Runway Designation Subfield
                        {
                            this.flightPlanRelatedData.runwayDesignation = "";
                            for (int ch = 0; ch < 3; ch++)
                            { string character = string.Join("", BinFPRD_Subfield.GetRange(2 + ch * 8, 6)); this.flightPlanRelatedData.runwayDesignation += this.callsign.CodingRules(character); }
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Destination Airport", this.flightPlanRelatedData.runwayDesignation);
                        }
                        else if (bit == 10) //Current Cleared Flight Level Subfield
                        {
                            this.flightPlanRelatedData.currentClearedFL = (Convert.ToInt32(string.Join("", BinFPRD_Subfield), 2) * 0.25).ToString();
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Current Cleared Flight Level", this.flightPlanRelatedData.currentClearedFL);
                        }
                        else if (bit == 11) //Current Control Position Subfield
                        {
                            this.flightPlanRelatedData.currentControlPosition = "Centre: " + Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(0, 8)), 2).ToString() + ", Position: " + Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(8, 8)), 2).ToString();
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Current Control Position", this.flightPlanRelatedData.currentControlPosition);
                        }
                        else if (bit == 12) //Time of Departure/Arrival Subfield
                        {
                            int REP = Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(0, 8)), 2);
                            for (int i = 0; i < 4 * REP; i++)
                            { BinFPRD_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                            for (int i = 0; i < REP; i++)
                            {
                                List<string> defaultTYP = new List<string>() { "Scheduled off-block time", "Estimated off-block time", "Estimated take-off time", "Actual off-block time", "Predicted time at runway hold", "Actual time at runway hold", "Actual line-up time", "Actual take-off time", "Estimated time of arrival", "Predicted landing time", "Actual landing time", "Actual time off runway", "Predicted time to gate", "Actual on-block time" };
                                List<string> defaultDAY = new List<string>() { "Today", "Yesterday", "Tomorrow", "Invalid" };
                                this.flightPlanRelatedData.departureArrivalTime = defaultDAY[Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(13 + 32 * i, 2)), 2)] + ", " + Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(19 + 32 * i, 5)), 2).ToString() + ":" + Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(26 + 32 * i, 6)), 2).ToString() + ":" + Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(34 + 32 * i, 6)), 2).ToString();
                                this.flightPlanRelatedData.InsertFPRDinfoInTable(defaultTYP[Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(8 + 32 * i, 5)), 2)], this.flightPlanRelatedData.departureArrivalTime);
                            }
                        }
                        else if (bit == 13) //Aircraft Stand Subfield
                        {
                            this.flightPlanRelatedData.aircraftStand = "";
                            for (int ch = 0; ch < 6; ch++)
                            { string character = string.Join("", BinFPRD_Subfield.GetRange(2 + ch * 8, 6)); this.flightPlanRelatedData.aircraftStand += this.callsign.CodingRules(character); }
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Aircraft Stand", this.flightPlanRelatedData.aircraftStand);
                        }
                        else if (bit == 14) //Stand Status Subfield
                        {
                            List<string> defaultEMP = new List<string>() { "Empty", "Occupied", "Unknown", "Invalid" };
                            List<string> defaultAVL = new List<string>() { "Available", "Not available", "Unknown", "Invalid" };
                            this.flightPlanRelatedData.standStatus = "EMP: " + defaultEMP[Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(0, 2)), 2)] + ", AVL: " + defaultAVL[Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(2, 2)), 2)];
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Stand Status", this.flightPlanRelatedData.standStatus);
                        }
                        else if (bit == 16) //Standard Instrument Departure Subfield
                        {
                            this.flightPlanRelatedData.standardInstrumentDeparture = "";
                            for (int ch = 0; ch < 7; ch++)
                            { string character = string.Join("", BinFPRD_Subfield.GetRange(2 + ch * 8, 6)); this.flightPlanRelatedData.standardInstrumentDeparture += this.callsign.CodingRules(character); }
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Standard Instrument Departure", this.flightPlanRelatedData.standardInstrumentDeparture);
                        }
                        else if (bit == 17) //Standard Instrument Arrival Subfield
                        {
                            this.flightPlanRelatedData.standardInstrumentArrival = "";
                            for (int ch = 0; ch < 7; ch++)
                            { string character = string.Join("", BinFPRD_Subfield.GetRange(2 + ch * 8, 6)); this.flightPlanRelatedData.standardInstrumentArrival += this.callsign.CodingRules(character); }
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Standard Instrument Arrival", this.flightPlanRelatedData.standardInstrumentArrival);
                        }
                        else if (bit == 18) //Pre-Emergency Mode 3/A Subfield
                        {
                            List<string> defaultVA = new List<string>() { "No valid", "Valid" };
                            this.flightPlanRelatedData.preEmergencyMode3A = Convert.ToString(Convert.ToInt32(string.Join("", BinFPRD_Subfield.GetRange(4, 12)), 2), 8) + "( " + defaultVA[Convert.ToInt32(BinFPRD_Subfield[3], 2)] + " )";
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Pre-Emergency Mode 3/A", this.flightPlanRelatedData.preEmergencyMode3A);
                        }
                        else if (bit == 19) //Pre-Emergency Callsign Subfield
                        {
                            this.flightPlanRelatedData.preEmergencyCallsign = "";
                            for (int ch = 0; ch < 7; ch++)
                            { string character = string.Join("", BinFPRD_Subfield.GetRange(2 + ch * 8, 6)); this.flightPlanRelatedData.preEmergencyCallsign += this.callsign.CodingRules(character); }
                            this.flightPlanRelatedData.InsertFPRDinfoInTable("Pre-Emergency Callsign", this.flightPlanRelatedData.preEmergencyCallsign);
                        }
                    }
                }
                this.row[59] = moreInfo; data.filledDataItems[59] = true;
            }
            else if (FRN == 22)
            {
                this.targetSizeAndOrientation = new TargetSizeAndOrientation(BinList);
                this.row[33] = this.targetSizeAndOrientation.length + " || " + this.targetSizeAndOrientation.orientation + " || " + this.targetSizeAndOrientation.width;
                data.filledDataItems[33] = true;
            }
            else if (FRN == 23)
            {
                List<string> DefaultVFI = new List<string>() { "Unknown", "ATC equipment maintenance", "Airport maintenance", "Fire", "Bird scarer", "Snow plough", "Runway sweeper", "Emergency", "Police", "Bus", "Tug (push/tow)", "Grass cutter", "Fuel", "Baggage", "Catering", "Aircraft maintenance", "Flyco (follow me)" };
                if (Convert.ToInt32(string.Join("", BinList), 2) < DefaultVFI.Count() - 1)
                    this.vehicleFleetIdentification = DefaultVFI[Convert.ToInt32(string.Join("", BinList), 2)];
                this.row[76] = this.vehicleFleetIdentification; data.filledDataItems[76] = true;
            }
            else if (FRN == 24)
            {
                for (int bit = 0; bit < BinList.Count; bit++)
                {
                    List<string> BinM5DR_Subfield = new List<string>();
                    if (BinList[bit] == "1" && (bit - 7) % 8 != 0) // eliminate fx=1
                    {
                        List<int> OctetsM5DR = new List<int>() { 1, 4, 6, 2, 2, 1, 1 };
                        for (int octets = 0; octets < OctetsM5DR[bit]; octets++)
                        { BinM5DR_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                        if (bit == 0) //Mode 5 Summary Subfield
                        {
                            this.mode5DataReports.SUM = new Mode5Summary(BinM5DR_Subfield);
                            for (int i = 0; i < this.mode5DataReports.SUM.TableM5S.Count; i += 2)
                                this.mode5DataReports.InsertM5DRinfoInTable(this.mode5DataReports.SUM.TableM5S[i], this.mode5DataReports.SUM.TableM5S[i + 1]);
                        }
                        else if (bit == 1) //Mode 5 PIN/National Origin/Mission Code Subfield
                        {
                            this.mode5DataReports.PMN = "PIN Code: " + Convert.ToInt32(string.Join("", BinM5DR_Subfield.GetRange(2, 14)), 2).ToString() + " National Origin: " + Convert.ToInt32(string.Join("", BinM5DR_Subfield.GetRange(19, 5)), 2).ToString() + " Mission Code: " + Convert.ToInt32(string.Join("", BinM5DR_Subfield.GetRange(26, 6)), 2).ToString();
                            this.mode5DataReports.InsertM5DRinfoInTable("Mode 5 PIN /National Origin/ Mission Code", this.mode5DataReports.PMN);
                        }
                        else if (bit == 2) //Mode 5 Reported Position Subfield
                        {
                            this.mode5DataReports.POS = new PositionWGS84Coordinates(BinM5DR_Subfield, "21");
                            this.mode5DataReports.InsertM5DRinfoInTable("Lat || Lon [º]", this.mode5DataReports.POS.latitude.ToString() + " || " + this.mode5DataReports.POS.longitude.ToString());
                        }
                        else if (bit == 3) //Mode 5 GNSS-derived Altitude Subfield
                        {
                            List<string> defaultRES = new List<string>() { "100 ft resolution", "25 ft resolution" };
                            this.mode5DataReports.GA = (binTwosComplementToSignedDecimal(string.Join("", BinM5DR_Subfield.GetRange(2, 14)), 14) * 25).ToString() + " (" + defaultRES[Convert.ToInt32(BinM5DR_Subfield[1], 2)] + " )";
                            this.mode5DataReports.InsertM5DRinfoInTable("Mode 5 GNSS-derived Altitude [ft]", this.mode5DataReports.GA);
                        }
                        else if (bit == 4) //Extended Mode 1 Code in Octal Representation Subfield
                        {
                            this.mode5DataReports.EM1 = (Convert.ToInt32(string.Join("", BinM5DR_Subfield.GetRange(4, 12)), 2), 8).ToString();
                            this.mode5DataReports.InsertM5DRinfoInTable("Extended Mode 1 Code", this.mode5DataReports.EM1);
                        }
                        else if (bit == 5) //Time Offset for POS and GA Subfield
                        {
                            this.mode5DataReports.TOS = (Convert.ToInt32(string.Join("", BinM5DR_Subfield), 2) * 1 / 128.0).ToString();
                            this.mode5DataReports.InsertM5DRinfoInTable("Time Offset for POS [s]", this.mode5DataReports.TOS);
                        }
                        else if (bit == 6) //X Pulse Presence Subfield
                        {
                            this.mode5DataReports.XP = new PresenceX_Pulse(BinM5DR_Subfield, category);
                            for (int i = 0; i < this.mode5DataReports.XP.TablePXP.Count; i += 2)
                                this.mode5DataReports.InsertM5DRinfoInTable(this.mode5DataReports.XP.TablePXP[i], this.mode5DataReports.XP.TablePXP[i + 1]);
                        }
                    }
                }
                this.row[100] = moreInfo; data.filledDataItems[100] = true;
            }
            else if (FRN == 25)
            {
                this.mode2_str = Convert.ToString(Convert.ToInt32(string.Join("", BinList.GetRange(4, 12)), 2), 8);
                this.row[62] = this.mode2_str; data.filledDataItems[62] = true;
            }
            else if (FRN == 26)
            {
                this.composedTrackNumber = new ComposedTrackNumber(BinList);
                this.row[101] = moreInfo; data.filledDataItems[101] = true;
            }
            else if (FRN == 27)
            {
                for (int bit = 0; bit < BinList.Count; bit++)
                {
                    List<string> BinEA_Subfield = new List<string>();
                    if (BinList[bit] == "1" && (bit - 7) % 8 != 0) // eliminate fx=1
                    {
                        List<int> OctetsEA = new List<int>() { 2, 2, 4, 1, 1, 2, 2, 1 };
                        for (int octets = 0; octets < OctetsEA[bit - 1]; octets++)
                        {
                            BinEA_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex]));
                            this.firstIndex += 1;
                        }
                        if (bit == 0) //Estimated Accuracy Of Track Position (Cartesian) Subfield
                        {
                            this.estimatedAccuracies.APC = (Convert.ToInt32(string.Join("", BinEA_Subfield.GetRange(0, 16)), 2) * 0.5).ToString() + " || " + (Convert.ToInt32(string.Join("", BinEA_Subfield.GetRange(16, 16)), 2) * 0.5).ToString();
                            this.estimatedAccuracies.InsertEAinfoInTable("Cartesian Track Position (X||Y) [m]", this.estimatedAccuracies.APC);
                        }
                        else if (bit == 1) //XY Covariance Subfield
                        {
                            this.estimatedAccuracies.COV = (Convert.ToInt32(string.Join("", BinEA_Subfield), 2) * 0.5).ToString();
                            this.estimatedAccuracies.InsertEAinfoInTable("XY Covariance [m]", this.estimatedAccuracies.COV);
                        }
                        else if (bit == 2) //Estimated Accuracy Of Track Position (WGS-84) Subfield
                        {
                            this.estimatedAccuracies.APW = (Convert.ToInt32(string.Join("", BinEA_Subfield.GetRange(0, 16)), 2) * 180 / Math.Pow(2, 25)).ToString() + " || " + (Convert.ToInt32(string.Join("", BinEA_Subfield.GetRange(16, 16)), 2) * 180 / Math.Pow(2, 25)).ToString();
                            this.estimatedAccuracies.InsertEAinfoInTable("WGS-84 Track Position (Lat||Lon) [º]", this.estimatedAccuracies.APC);
                        }
                        else if (bit == 3) //Estimated Accuracy Of Calculated Track Geometric Altitude Subfield
                        {
                            this.estimatedAccuracies.AGA = (Convert.ToInt32(string.Join("", BinEA_Subfield), 2) * 6.25).ToString();
                            this.estimatedAccuracies.InsertEAinfoInTable("Track Geometric Altitude [ft]", this.estimatedAccuracies.AGA);
                        }
                        else if (bit == 4) //Estimated Accuracy Of Calculated Track Barometric Altitude Subfield
                        {
                            this.estimatedAccuracies.ABA = (Convert.ToInt32(string.Join("", BinEA_Subfield), 2) * 0.25).ToString();
                            this.estimatedAccuracies.InsertEAinfoInTable("Track Barometric Altitude [FL]", this.estimatedAccuracies.ABA);
                        }
                        else if (bit == 5) //Estimated Accuracy Of Track Velocity (Cartesian) Subfield
                        {
                            this.estimatedAccuracies.ATV = (Convert.ToInt32(string.Join("", BinEA_Subfield.GetRange(0, 8)), 2) * 0.25).ToString() + " || " + (Convert.ToInt32(string.Join("", BinEA_Subfield.GetRange(8, 8)), 2) * 0.25).ToString();
                            this.estimatedAccuracies.InsertEAinfoInTable("Cartesian Track Velocity (Vx||Vy) [m/s]", this.estimatedAccuracies.ATV);
                        }
                        else if (bit == 6) //Estimated Accuracy Of Acceleration (Cartesian) Subfield
                        {
                            this.estimatedAccuracies.AA = (Convert.ToInt32(string.Join("", BinEA_Subfield.GetRange(0, 8)), 2) * 0.25).ToString() + " || " + (Convert.ToInt32(string.Join("", BinEA_Subfield.GetRange(8, 8)), 2) * 0.25).ToString();
                            this.estimatedAccuracies.InsertEAinfoInTable("Cartesian Acceleration (Ax||Ay) [m/s^2]", this.estimatedAccuracies.AA);
                        }
                        else if (bit == 7) //Estimated Accuracy Of Rate Of Climb/Descent Subfield
                        {
                            this.estimatedAccuracies.ARC = (Convert.ToInt32(string.Join("", BinEA_Subfield), 2) * 6.25).ToString();
                            this.estimatedAccuracies.InsertEAinfoInTable("Rate of Climb [ft/min]", this.estimatedAccuracies.ARC);
                        }
                    }
                }
                this.row[102] = moreInfo; data.filledDataItems[102] = true;
            }
            else if (FRN == 28)
            {
                for (int bit = 0; bit < BinList.Count; bit++)
                {
                    List<string> BinMI_Subfield = new List<string>();
                    if (BinList[bit] == "1" && (bit - 7) % 8 != 0) // eliminate fx=1
                    {
                        List<int> OctetsMI = new List<int>() { 2, 4, 2, 2, 2, 1 };
                        for (int octets = 0; octets < OctetsMI[bit]; octets++)
                        { BinMI_Subfield.AddRange(HexToBinary(this.Message[this.firstIndex])); this.firstIndex += 1; }
                        if (bit == 0) //Sensor Identification Subfield
                        {
                            string SAC = Convert.ToInt32(string.Join("", BinMI_Subfield.GetRange(0, 8)), 2).ToString();
                            string SIC = Convert.ToInt32(string.Join("", BinMI_Subfield.GetRange(8, 8)), 2).ToString();
                            while (SIC.Length < 3)
                                SIC = SIC.Insert(0, "0");
                            while (SAC.Length < 3)
                                SAC = SAC.Insert(0, "0");
                            this.measuredInformation.SID = string.Join("/", SAC, SIC);
                            this.measuredInformation.InsertMIinfoInTable("SAC/SIC", this.measuredInformation.SID);
                        }
                        else if (bit == 1) //Measured Position(Polar) Subfield
                        {
                            this.measuredInformation.POS = new PositionPolarCoordinates(BinMI_Subfield, category);
                            this.measuredInformation.InsertMIinfoInTable("Rho||Theta [NM||º]", Math.Round(this.measuredInformation.POS.rho, 3) + " || " + Math.Round(this.measuredInformation.POS.theta, 3));
                        }
                        else if (bit == 2) //Measured 3-D Height Subfield
                        {
                            this.measuredInformation.HEI = (Convert.ToInt32(string.Join("", BinMI_Subfield), 2) * 25).ToString();
                            this.measuredInformation.InsertMIinfoInTable("Measured 3-D Height [ft]", this.measuredInformation.HEI);
                        }
                        else if (bit == 3) //Last Measured Mode C code Subfield
                        {
                            this.measuredInformation.MDC = new FlightLevel(BinMI_Subfield);
                            this.measuredInformation.InsertMIinfoInTable("V", this.measuredInformation.MDC.V);
                            this.measuredInformation.InsertMIinfoInTable("G", this.measuredInformation.MDC.G);
                            this.measuredInformation.InsertMIinfoInTable("Mode C Code", this.measuredInformation.MDC.FL);
                        }
                        else if (bit == 4) //Last Measured Mode 3/A code Subfield
                        {
                            this.measuredInformation.MDA = new Mode3A(BinMI_Subfield, "21");
                            this.measuredInformation.InsertMIinfoInTable("V", this.measuredInformation.MDA.V);
                            this.measuredInformation.InsertMIinfoInTable("G", this.measuredInformation.MDA.G);
                            this.measuredInformation.InsertMIinfoInTable("L", this.measuredInformation.MDA.L);
                            this.measuredInformation.InsertMIinfoInTable("Mode 3/A Code", this.measuredInformation.MDA.Reply);
                        }
                        else if (bit == 5) //Report Type Subfield
                        {
                            this.measuredInformation.TYP = new ReportType(BinMI_Subfield);
                            for (int i = 0; i < this.measuredInformation.TYP.TableRT.Count; i += 2)
                                this.measuredInformation.InsertMIinfoInTable(this.measuredInformation.TYP.TableRT[i], this.measuredInformation.TYP.TableRT[i + 1]);
                        }
                    }
                }
                this.row[60] = moreInfo; data.filledDataItems[60] = true;
            }
        }

        // Function that converts from Cartesian coordinates to WGS84 to show it on the Google map
        public void UTM2WGS84(string utmZone, double radarUTM_Northing, double radarUTM_Easting)
        {
            bool isNorthHemisphere = utmZone.Last() >= 'N';
            var zone = int.Parse(utmZone.Remove(utmZone.Length - 1));
            var c_sa = 6378137.000000;
            var c_sb = 6356752.31424518;
            var e2 = Math.Pow((Math.Pow(c_sa, 2) - Math.Pow(c_sb, 2)), 0.5) / c_sb;
            var e2cuadrada = Math.Pow(e2, 2);
            var c = Math.Pow(c_sa, 2) / c_sb;
            var x = radarUTM_Easting + this.positionCartesian.x * 1852 - 500000;
            var y = isNorthHemisphere ? radarUTM_Northing + this.positionCartesian.y * 1852 : radarUTM_Northing - this.positionCartesian.y * 1852 - 10000000;
            var s = (zone * 6.0) - 183.0;
            var lat = y / (6366197.724 * 0.9996);
            var v = (c / Math.Pow(1 + (e2cuadrada * Math.Pow(Math.Cos(lat), 2)), 0.5)) * 0.9996;
            var a = x / v;
            var a1 = Math.Sin(2 * lat);
            var a2 = a1 * Math.Pow((Math.Cos(lat)), 2);
            var j2 = lat + (a1 / 2.0);
            var j4 = ((3 * j2) + a2) / 4.0;
            var j6 = (5 * j4 + a2 * Math.Pow((Math.Cos(lat)), 2)) / 3.0;
            var alfa = (3.0 / 4.0) * e2cuadrada;
            var beta = (5.0 / 3.0) * Math.Pow(alfa, 2);
            var gama = (35.0 / 27.0) * Math.Pow(alfa, 3);
            var bm = 0.9996 * c * (lat - alfa * j2 + beta * j4 - gama * j6);
            var b = (y - bm) / v;
            var epsi = ((e2cuadrada * Math.Pow(a, 2)) / 2.0) * Math.Pow((Math.Cos(lat)), 2);
            var eps = a * (1 - (epsi / 3.0));
            var nab = (b * (1 - epsi)) + lat;
            var senoheps = (Math.Exp(eps) - Math.Exp(-eps)) / 2.0;
            var delt = Math.Atan(senoheps / (Math.Cos(nab)));
            var tao = Math.Atan(Math.Cos(delt) * Math.Tan(nab));
            this.positionWGS84.longitude = (delt / Math.PI) * 180 + s;
            this.positionWGS84.latitude = (((lat + (1 + e2cuadrada * Math.Pow(Math.Cos(lat), 2) - (3.0 / 2.0) * e2cuadrada * Math.Sin(lat) * Math.Cos(lat) * (tao - lat)) * (tao - lat))) / Math.PI) * 180;
        }

        // Function that converts geodesic coordinates (Lat, Lon) to UTM (x, y)
        public static (double eastingUTM, double northingUTM) LLA2UTM(double longitude, double latitude, string hemisphere)
        {
            var c_sa = 6378137;
            var c_sb = 6356752.31424518;
            var e2 = Math.Sqrt(Math.Pow(c_sa, 2) - Math.Pow(c_sb, 2)) / c_sb;
            var c = Math.Pow(c_sa, 2) / c_sb;
            var lonRad = longitude * Math.PI / 180;
            var latRad = latitude * Math.PI / 180;
            var huso = Math.Truncate(longitude / 6 + 31);
            var husoMeridiano = 6 * huso - 183;
            var deltaLambda = lonRad - (husoMeridiano * Math.PI / 180);
            var A = Math.Cos(latRad) * Math.Sin(deltaLambda);
            var xi = 0.5 * Math.Log((1 + A) / (1 - A));
            var eta = Math.Atan(Math.Tan(latRad) / Math.Cos(deltaLambda)) - latRad;
            var nu = (c * 0.9996) / Math.Sqrt((1 + e2 * e2 * Math.Cos(latRad) * Math.Cos(latRad)));
            var zeta = (e2 * e2 / 2) * (xi * xi) * (Math.Cos(latRad) * Math.Cos(latRad));
            var A1 = Math.Sin(2.0 * latRad);
            var A2 = A1 * (Math.Cos(latRad) * Math.Cos(latRad));
            var J2 = latRad + A1 / 2.0;
            var J4 = (3 * J2 + A2) / 4;
            var J6 = (5 * J4 + A2 * (Math.Cos(latRad) * Math.Cos(latRad))) / 3;
            var alpha2 = (3.0 / 4.0) * (e2 * e2);
            var beta = (5.0 / 3.0) * (alpha2 * alpha2);
            var gamma = (35.0 / 27.0) * (Math.Pow(alpha2, 3));
            var B_phi = 0.9996 * c * (latRad - alpha2 * J2 + beta * J4 - gamma * J6);
            var eastingUTM = xi * nu * (1 + zeta / 3.0) + 500000.00;
            var northingUTM = eta * nu * (1 + zeta) + B_phi;
            if (hemisphere == "S")
                northingUTM += 10000000.0;
            return (eastingUTM, northingUTM);
        }
    }
}