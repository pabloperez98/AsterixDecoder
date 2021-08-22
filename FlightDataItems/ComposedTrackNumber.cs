using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class ComposedTrackNumber
    {
        public string systemUnitIdentification;
        public string systemTrackNumber;

        public List<string> TableCTN = new List<string>();

        public ComposedTrackNumber()
        {
            this.systemUnitIdentification = "N/A";
            this.systemTrackNumber = "N/A";
        }

        public ComposedTrackNumber(List<string> BiCTN)
        {
            for (int extents = 0; extents < BiCTN.Count / (8*3); extents++)
            {
                List<string> infoExtent = new List<string>();
                for (int bit = 0; bit < 24; bit++)
                    infoExtent.Add(BiCTN[bit + extents * 24]);
                this.systemUnitIdentification = Convert.ToInt32(string.Join("", infoExtent.GetRange(0 + extents * 24, 8)), 2).ToString();
                this.systemTrackNumber = Convert.ToInt32(string.Join("", infoExtent.GetRange(8 + extents * 24, 15)), 2).ToString();
                this.TableCTN.Add(this.systemUnitIdentification); this.TableCTN.Add(this.systemTrackNumber);
            }
        }
    }
}
