using System.Collections.Generic;

namespace FlightDataItems
{
    public class FlightPlanRelatedData
    {
        public string DSI; //SAC/SIC Subfield
        public string callsign; //Callsign Subfield
        public string IFPS_FLIGHT_ID; //IFPS_FLIGHT_ID Subfield
        public FlightCategory flightCategory; //Flight Category Subfield
        public string aircraftType; //Type of Aircraft Subfield
        public string wakeTurbulenceCategory; //Wake Turbulence Category Subfield
        public string departureAirport; //Departure Airport Subfield
        public string destinationAirport; //Destination Airport Subfield
        public string runwayDesignation; //Runway Designation Subfield
        public string currentClearedFL; //Current Cleared Flight Level Subfield
        public string currentControlPosition; //Current Control Position Subfield
        public string departureArrivalTime; //Time of Departure/Arrival Subfield
        public string aircraftStand; //Aircraft Stand Subfield
        public string standStatus; //Stand Status Subfield
        public string standardInstrumentDeparture; //Standard Instrument Departure Subfield
        public string standardInstrumentArrival; //Standard Instrument Arrival Subfield
        public string preEmergencyMode3A; //Pre-Emergency Mode 3/A Subfield
        public string preEmergencyCallsign; //Pre-Emergency Callsign Subfield

        public List<string> TableFPRD = new List<string>();

        public FlightPlanRelatedData()
        {
            this.DSI = "N/A"; //SAC/SIC Subfield
            this.callsign = "N/A"; //Callsign Subfield
            this.IFPS_FLIGHT_ID = "N/A"; //IFPS_FLIGHT_ID Subfield
            this.flightCategory = new FlightCategory(); //Flight Category Subfield
            this.aircraftType = "N/A"; //Type of Aircraft Subfield
            this.wakeTurbulenceCategory = "N/A"; //Wake Turbulence Category Subfield
            this.departureAirport = "N/A"; //Departure Airport Subfield
            this.destinationAirport = "N/A"; //Destination Airport Subfield
            this.runwayDesignation = "N/A"; //Runway Designation Subfield
            this.currentClearedFL = "N/A"; //Current Cleared Flight Level Subfield
            this.currentControlPosition = "N/A"; //Current Control Position Subfield
            this.departureArrivalTime = "N/A"; //Time of Departure/Arrival Subfield
            this.aircraftStand = "N/A"; //Aircraft Stand Subfield
            this.standStatus = "N/A"; //Stand Status Subfield
            this.standardInstrumentDeparture = "N/A"; //Standard Instrument Departure Subfield
            this.standardInstrumentArrival = "N/A"; //Standard Instrument Arrival Subfield
            this.preEmergencyMode3A = "N/A"; //Pre-Emergency Mode 3/A Subfield
            this.preEmergencyCallsign = "N/A"; //Pre-Emergency Callsign Subfield
        }

        public void InsertFPRDinfoInTable(string field, string value)
        {
            this.TableFPRD.Add(field);
            this.TableFPRD.Add(value);
        }
    }
}
