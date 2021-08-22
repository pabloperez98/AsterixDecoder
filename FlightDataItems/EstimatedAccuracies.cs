using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDataItems
{
    public class EstimatedAccuracies
    {
        public string APC; //Estimated Accuracy Of Track Position (Cartesian) Subfield
        public string COV; //XY Covariance Subfield
        public string APW; //Estimated Accuracy Of Track Position (WGS-84) Subfield
        public string AGA; //Estimated Accuracy Of Calculated Track Geometric Altitude Subfield
        public string ABA; //Estimated Accuracy Of Calculated Track Barometric Altitude Subfield
        public string ATV; //Estimated Accuracy Of Track Velocity (Cartesian) Subfield
        public string AA; //Estimated Accuracy Of Acceleration (Cartesian) Subfield
        public string ARC; //Estimated Accuracy Of Rate Of Climb/Descent Subfield

        public List<string> TableEA = new List<string>();

        public EstimatedAccuracies()
        {
            this.APC = "N/A"; //Estimated Accuracy Of Track Position (Cartesian) Subfield
            this.COV = "N/A"; //XY Covariance Subfield
            this.APW = "N/A"; //Estimated Accuracy Of Track Position (WGS-84) Subfield
            this.AGA = "N/A"; //Estimated Accuracy Of Calculated Track Geometric Altitude Subfield
            this.ABA = "N/A"; //Estimated Accuracy Of Calculated Track Barometric Altitude Subfield
            this.ATV = "N/A"; //Estimated Accuracy Of Track Velocity (Cartesian) Subfield
            this.AA = "N/A"; //Estimated Accuracy Of Acceleration (Cartesian) Subfield
            this.ARC = "N/A"; //Estimated Accuracy Of Rate Of Climb/Descent Subfield
        }

        public void InsertEAinfoInTable(string field, string value)
        {
            this.TableEA.Add(field);
            this.TableEA.Add(value);
        }
    }
}
