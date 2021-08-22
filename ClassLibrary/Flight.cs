using System;
using System.Collections.Generic;
using GMap.NET.WindowsForms.Markers;

namespace ClassLibrary
{
    public class Flight
    {
        public int index = 0;
        public string callsign;
        public string ICAOadress;
        public List<string> trackNumber = new List<string>();
        public string mode3A;
        public List<string> category = new List<string>();
        public List<string> sensor = new List<string>();
        public List<double> seconds = new List<double>();
        public List<double> decimalSeconds = new List<double>();
        public List<double> longitude = new List<double>();
        public List<double> latitude = new List<double>();
        public List<double> altitude = new List<double>();
        public List<GMarkerGoogle> pointList = new List<GMarkerGoogle>();
        public List<string> FL = new List<string>();
        public List<double> groundSpeed = new List<double>();
        public List<double> trackVelocity = new List<double>();

        public void fillFlight(string category, string sensor, string callsign, string ICAOadress, string trackNumber, string mode3A, double seconds, double decimalSeconds, double longitude, double latitude, double altitude, string FL, double GS, double trackVelocity)
        {
            this.category.Add(category);
            this.sensor.Add(sensor);
            this.callsign = callsign;
            this.ICAOadress = ICAOadress;
            this.trackNumber.Add(trackNumber);
            this.mode3A = mode3A;
            this.seconds.Add(seconds);
            this.decimalSeconds.Add(decimalSeconds);
            this.longitude.Add(longitude);
            this.latitude.Add(latitude);
            this.altitude.Add(altitude);
            this.FL.Add(FL);
            this.groundSpeed.Add(GS);
            this.trackVelocity.Add(trackVelocity);
        }
        public void addValueFlight(string category, string sensor, string trackNumber, double timeUTC, double decimalSeconds, double longitude, double latitude, double altitude, string FL, double GS, double trackVelocity)
        {
            this.category.Add(category);
            this.sensor.Add(sensor);
            this.trackNumber.Add(trackNumber);
            this.seconds.Add(timeUTC);
            this.decimalSeconds.Add(decimalSeconds);
            this.longitude.Add(longitude);
            this.latitude.Add(latitude);
            this.altitude.Add(altitude);
            this.FL.Add(FL);
            this.groundSpeed.Add(GS);
            this.trackVelocity.Add(trackVelocity);
        }
        public void insertValueFlight(int index, string category, string sensor, string trackNumber, double timeUTC, double decimalSeconds, double longitude, double latitude, double altitude, string FL, double GS, double trackVelocity)
        {
            this.category.Insert(index, category);
            this.sensor.Insert(index, sensor);
            this.trackNumber.Insert(index, trackNumber);
            this.seconds.Insert(index, timeUTC);
            this.decimalSeconds.Insert(index, decimalSeconds);
            this.longitude.Insert(index, longitude);
            this.latitude.Insert(index, latitude);
            this.altitude.Insert(index, altitude);
            this.FL.Insert(index, FL);
            this.groundSpeed.Insert(index, GS);
            this.trackVelocity.Insert(index, trackVelocity);
        }
    }
}
