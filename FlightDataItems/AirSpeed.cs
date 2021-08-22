using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class AirSpeed
    {
        public string TypeAirSpeed;
        public string AirSpeedValue;

        public AirSpeed()
        {
            this.TypeAirSpeed = "N/A";
            this.AirSpeedValue = "N/A";
        }

        public AirSpeed(List<string> BinAirSpeed)
        {
            double modIAS = Math.Pow(2, -14)*3600; //[kt]
            double modMach = 0.001;
            if (BinAirSpeed[0] == "0")
            {
                this.TypeAirSpeed = "IAS";
                AirSpeedValue = Convert.ToString(Convert.ToInt32(string.Join("",BinAirSpeed.GetRange(1,15)), 2) * modIAS);
            }
            if (BinAirSpeed[0] == "1")
            {
                this.TypeAirSpeed = "Mach";
                AirSpeedValue = Convert.ToString(Convert.ToInt32(string.Join("", BinAirSpeed.GetRange(1, 15)), 2) * modMach);
            }
        }
    }
}
