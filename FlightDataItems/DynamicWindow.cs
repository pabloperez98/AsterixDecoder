using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDataItems
{
    public class DynamicWindow
    {
        public string rhoStart;
        public string rhoEnd;
        public string thetaStart;
        public string thetaEnd;

        public DynamicWindow(List<string> BinaryDynamicWindow, string category)
        {
            double modRho = 1 / 128.0; //CAT02
            if (category == "34")
                modRho = 1 / 256.0;
            this.rhoStart = (Convert.ToInt32(string.Join("", BinaryDynamicWindow.GetRange(0, 16)), 2) * modRho).ToString(); // [NM]
            this.rhoEnd = (Convert.ToInt32(string.Join("", BinaryDynamicWindow.GetRange(16, 16)), 2) * modRho).ToString(); // [NM]
            this.thetaStart = (Convert.ToInt32(string.Join("", BinaryDynamicWindow.GetRange(32, 16)), 2) * 360 / Math.Pow(2, 16)).ToString(); // [º]
            this.thetaEnd = (Convert.ToInt32(string.Join("", BinaryDynamicWindow.GetRange(48, 16)), 2) * 360 / Math.Pow(2, 16)).ToString(); // [º]
        }

        public DynamicWindow()
        {
            this.rhoStart = "N/A";
            this.rhoEnd = "N/A";
            this.thetaStart = "N/A";
        }
    }
}
