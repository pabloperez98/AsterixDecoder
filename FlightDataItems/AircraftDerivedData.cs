using System.Collections.Generic;

namespace FlightDataItems
{
    public class AircraftDerivedData
    {
        public string ICAOaddress; //ADR Subfield
        public TargetIdentification callsign; //ID Subfield
        public string magneticHeading; //MHG Subfield
        public AirSpeed airspeed; //IAS Subfield
        public string trueAirspeed; //TAS Subfield
        public SelectedAltitude selectedAltitude; //SAL Subfield
        public FinalSelectedAltitude finalSelectedAltitude; //FSS Subfield
        public TrajectoryIntentStatus trajectoryIntentStatus; //TIS Subfield
        public TrajectoryIntentData trajectoryIntentData; //TID Subfield
        public ACAS_CapabilitiesFlightStatus ACAS_CapabilitiesFlightStatus; //COM Subfield
        public StatusADSB statusADSB; //SAB Subfield
        public ACAS_ResolutionAdvisoryReport ACAS_ResolutionAdvisoryReport; //ACS Subfield
        public string barometricVerticalRate; //BVR Subfield
        public string geometricVerticalRate; //GVR Subfield
        public string rollAngle; //RAN Subfield
        public RateOfTurn rateOfTurn; //TAR Subfield
        public string trackAngle; //TAN Subfield
        public string groundSpeed; //GSP Subfield
        public string velocityUncertainty; //VUN Subfield
        public MetInformation metData; //MET Subfield
        public string emitterCategory; //EMC Subfield
        public PositionWGS84Coordinates positionWGS84Coordinates; //POS Subfield
        public string geometricAltitude; //GAL Subfield
        public string positionUncertainty; //PUN Subfield
        public ModeS_MBData modeS_MBData; //MB Subfield
        public string IndicatedAirSpeed; //IAR Subfield
        public string machNumber; //MAC Subfield
        public string barometricPressureSetting; //BPS Subfield

        public List<string> TableADD = new List<string>();

        public AircraftDerivedData()
        {
            this.ICAOaddress = "N/A";
            this.callsign = new TargetIdentification();
            this.magneticHeading = "N/A";
            this.airspeed = new AirSpeed();
            this.trueAirspeed = "N/A";
            this.selectedAltitude = new SelectedAltitude();
            this.finalSelectedAltitude = new FinalSelectedAltitude();
            this.trajectoryIntentStatus = new TrajectoryIntentStatus();
            this.trajectoryIntentData = new TrajectoryIntentData();
            this.ACAS_CapabilitiesFlightStatus = new ACAS_CapabilitiesFlightStatus();
            this.statusADSB = new StatusADSB();
            this.ACAS_ResolutionAdvisoryReport = new ACAS_ResolutionAdvisoryReport();
            this.barometricVerticalRate = "N/A";
            this.geometricVerticalRate = "N/A";
            this.rollAngle = "N/A";
            this.rateOfTurn = new RateOfTurn();
            this.trackAngle = "N/A";
            this.groundSpeed = "N/A";
            this.velocityUncertainty = "N/A";
            this.metData = new MetInformation();
            this.emitterCategory = "N/A";
            this.positionWGS84Coordinates = new PositionWGS84Coordinates();
            this.geometricAltitude = "N/A";
            this.positionUncertainty = "N/A";
            this.modeS_MBData = new ModeS_MBData();
            this.IndicatedAirSpeed = "N/A";
            this.machNumber = "N/A";
            this.barometricPressureSetting = "N/A";
        }

        public void InsertADDinfoInTable(string field, string value)
        {
            this.TableADD.Add(field);
            this.TableADD.Add(value);
        }
    }
}