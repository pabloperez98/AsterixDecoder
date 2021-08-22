using System.Collections.Generic;

namespace FlightDataItems
{
    public class MeasuredInformation
    {
        public string SID; //Sensor Identification Subfield
        public PositionPolarCoordinates POS; //Measured Position (Polar) Subfield
        public string HEI; //Measured 3-D Height Subfield
        public FlightLevel MDC; //Last Measured Mode C code Subfield
        public Mode3A MDA; //Last Measured Mode 3/A code Subfield
        public ReportType TYP; //Report Type Subfield

        public List<string> TableMI = new List<string>();

        public MeasuredInformation()
        {
            this.SID = "N/A"; //Sensor Identification Subfield
            this.POS = new PositionPolarCoordinates(); //Measured Position(Polar) Subfield
            this.HEI = "N/A"; //Measured 3-D Height Subfield
            this.MDC = new FlightLevel(); //Last Measured Mode C code Subfield
            this.MDA = new Mode3A(); //Last Measured Mode 3/A code Subfield
            this.TYP = new ReportType(); //Report Type Subfield
        }

        public void InsertMIinfoInTable(string field, string value)
        {
            this.TableMI.Add(field);
            this.TableMI.Add(value);
        }
    }
}
