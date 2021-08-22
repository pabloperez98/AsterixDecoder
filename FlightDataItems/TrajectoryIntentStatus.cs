using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class TrajectoryIntentStatus
    {
        public string NAV;
        public string NVB;

        public List<string> TableTIS = new List<string>();

        public TrajectoryIntentStatus()
        {
            this.NAV = "N/A";
            this.NVB = "N/A";
        }

        public TrajectoryIntentStatus(List<string> BinaryTrajectoryIntent)
        {
            
            List<string> defaultNAV = new List<string>() { "Trajectory Intent Data is available for this aircraft", "Trajectory Intent Data is not available for this aircraft" };
            List<string> defaultNVB = new List<string>() { "Trajectory Intent Data is valid", "Trajectory Intent Data is not valid" };

            this.NAV = defaultNAV[Convert.ToInt32(BinaryTrajectoryIntent[0], 2)];
            this.NVB = defaultNVB[Convert.ToInt32(BinaryTrajectoryIntent[1], 2)];

            this.TableTIS.Add("NAV"); this.TableTIS.Add(this.NAV);
            this.TableTIS.Add("NVB"); this.TableTIS.Add(this.NVB);
        }
    }
}
