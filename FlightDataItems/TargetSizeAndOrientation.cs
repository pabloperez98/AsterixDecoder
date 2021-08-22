using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightDataItems
{
    public class TargetSizeAndOrientation
    {
        public string length;
        public string orientation;
        public string width;

        public TargetSizeAndOrientation()
        {
            this.length = "N/A";
            this.orientation = "N/A";
            this.width = "N/A";
        }

        public TargetSizeAndOrientation(List<string> BinaryTSaO)
        {
            double modOrientation = 360/128.0;
            for (int octets = 0; octets < BinaryTSaO.Count()/8; octets++)
            {
                List<string> infoOctet = new List<string>();
                for (int bit = 0; bit < 7; bit++)
                    infoOctet.Add(BinaryTSaO[bit + octets * 8]);
                if (octets == 0)
                    this.length = Convert.ToInt32(string.Join("", BinaryTSaO.GetRange(0, 7)), 2).ToString();
                if (octets == 1)
                    this.orientation = (Convert.ToInt32(string.Join("", BinaryTSaO.GetRange(0, 7)), 2) * modOrientation).ToString();
                if (octets == 2)
                    this.width = Convert.ToInt32(string.Join("", BinaryTSaO.GetRange(0, 7)), 2).ToString();
            }
        }
    }
}
