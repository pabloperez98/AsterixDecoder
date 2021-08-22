using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class ContourIdentifier
    {
        public string ORG;
        public string intensityLevel;
        public string FST;
        public string CSN;

        public List<string> TableCI = new List<string>();

        public ContourIdentifier()
        {
            this.ORG = "N/A";
            this.intensityLevel = "N/A";
            this.FST = "N/A";
            this.CSN = "N/A";
        }

        public ContourIdentifier(List<string> BinaryContourIdentifier)
        {
            List<string> defaultORG = new List<string>() { "Local Coordinates", "System Coordinates" };
            List<string> defaultFST = new List<string>() { "Intermediate record of a contour", "Last record of a contour of at least two records", "First record of a contour of at least two records", "First and only record, fully defining a contour" };
            this.ORG = defaultORG[Convert.ToInt32(string.Join("", BinaryContourIdentifier.GetRange(0, 1)), 2)];
            this.intensityLevel = Convert.ToInt32(string.Join("", BinaryContourIdentifier.GetRange(1, 3)), 2).ToString();
            this.FST = defaultFST[Convert.ToInt32(string.Join("", BinaryContourIdentifier.GetRange(6, 2)), 2)];
            this.CSN = Convert.ToInt32(string.Join("", BinaryContourIdentifier.GetRange(8, 8)), 2).ToString();
            TableCI.Add("ORG"); TableCI.Add(this.ORG);
            TableCI.Add("FST/LST"); TableCI.Add(this.FST);
        }
    }
}
