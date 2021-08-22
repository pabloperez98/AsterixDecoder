using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class VectorQualifier
    {
        public string ORG;
        public string intensityLevel;
        public string shadingOrientation;

        public string TST;
        public string ER;

        public List<string> TableVQ = new List<string>();

        public VectorQualifier()
        {
            this.ORG = "N/A";
            this.intensityLevel = "N/A";
            this.shadingOrientation = "N/A";

            this.TST = "N/A";
            this.ER = "N/A";
        }

        public VectorQualifier(List<string> BinaryVectorQualifier)
        {
            int nextOctet = 0;
            for (int octets = 0; octets < BinaryVectorQualifier.Count / 8; octets++)
            {
                if (octets == 0)
                {
                    List<string> defaultORG = new List<string>() { "Local Coordinates", "System Coordinates" };
                    List<string> defaultShadingOrientation = new List<string>() { "0", "22.5", "45", "67.5", "90", "112.5", "135", "157.5" };
                    this.ORG = defaultORG[Convert.ToInt32(string.Join("", BinaryVectorQualifier.GetRange(0, 1)), 2)];
                    this.intensityLevel = Convert.ToInt32(string.Join("", BinaryVectorQualifier.GetRange(1, 3)), 2).ToString();
                    this.shadingOrientation = defaultShadingOrientation[Convert.ToInt32(string.Join("", BinaryVectorQualifier.GetRange(4, 3)), 2)];
                    this.TableVQ.Add("ORG"); this.TableVQ.Add(this.ORG);
                }
                if (octets == 1)
                {
                    List<string> defaultTST = new List<string>() { "Default", "Test vector" };
                    List<string> defaultER = new List<string>() { "Default", "Error condition encountered" };
                    this.TST = defaultTST[Convert.ToInt32(string.Join("", BinaryVectorQualifier.GetRange(13, 1)), 2)];
                    this.ER = defaultER[Convert.ToInt32(string.Join("", BinaryVectorQualifier.GetRange(14, 1)), 2)];
                    this.TableVQ.Add("TST"); this.TableVQ.Add(this.TST);
                    this.TableVQ.Add("ER"); this.TableVQ.Add(this.ER);
                }
                nextOctet += 8;
            }
        }
    }
}
