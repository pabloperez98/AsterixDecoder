using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class TrajectoryIntentData
    {
        public string REP;
        public string TCA;
        public string NC;
        public string TCPNumber;
        public string Altitude;
        public string Latitude;
        public string Longitude;
        public string PointType;
        public string TD;
        public string TRA;
        public string TOA;
        public string TOV;
        public string TTR;

        public List<string> TableTID = new List<string>();
        public TrajectoryIntentData()
        {
            this.REP = "N/A";
            this.TCA = "N/A";
            this.NC = "N/A";
            this.TCPNumber = "N/A";
            this.Altitude = "N/A";
            this.Latitude = "N/A";
            this.Longitude = "N/A";
            this.PointType = "N/A";
            this.TD = "N/A";
            this.TRA = "N/A";
            this.TOA = "N/A";
            this.TOV = "N/A";
            this.TTR = "N/A";
        }

        public TrajectoryIntentData(List<string> BinaryTrajectoryIntent)
        {
            List<string> defaultTCA = new List<string>() { "TCP number available", "TCP number not available" };
            List<string> defaultNC = new List<string>() { "TCP compliance", "TCP non-compliance" };
            List<string> defaultPointType = new List<string>() { "Unknon", "Fly by waypoint", "Fly over waypoint", "Hold patter", "Procedure hold", "Procedure turn", "RF leg", "Top of climb", "Top of descent", "Start of level", "Cross-over altitude", "Tranition altitude" };
            List<string> defaultTD = new List<string>() { "N/A", "Turn right", "Turn left", "No turn" };
            List<string> defaultTRA = new List<string>() { "TTR not available", "TTR available" };
            List<string> defaultTOA = new List<string>() { "TOV available", "TOV not available" };

            this.REP = Convert.ToString(Convert.ToInt32(string.Join("", BinaryTrajectoryIntent.GetRange(0, 8))), 2);
            this.TableTID.Add("REP"); this.TableTID.Add(this.REP);
            for (int i = 0; i < Convert.ToInt32(this.REP); i++)
            {
                this.TCA = defaultTCA[Convert.ToInt32(BinaryTrajectoryIntent[8], 2)];
                this.TableTID.Add("TCA"); this.TableTID.Add(this.TCA);

                this.NC = defaultNC[Convert.ToInt32(BinaryTrajectoryIntent[9], 2)];
                this.TableTID.Add("NC"); this.TableTID.Add(this.NC);

                this.TCPNumber = Convert.ToString(Convert.ToInt32(string.Join("", BinaryTrajectoryIntent.GetRange(10, 6)), 2));
                this.TableTID.Add("TCPNumber"); this.TableTID.Add(this.TCPNumber);

                this.Altitude = Convert.ToString(binTwosComplementToSignedDecimal(string.Join("", BinaryTrajectoryIntent.GetRange(16, 16)), 16) * 10);
                this.TableTID.Add("Altitude [ft]"); this.TableTID.Add(this.Altitude);

                this.Latitude = Convert.ToString(binTwosComplementToSignedDecimal(string.Join("", BinaryTrajectoryIntent.GetRange(32, 24)), 24) * (180 / Math.Pow(2, 23)));
                this.TableTID.Add("Latitude [º]"); this.TableTID.Add(this.Latitude);

                this.Longitude = Convert.ToString(binTwosComplementToSignedDecimal(string.Join("", BinaryTrajectoryIntent.GetRange(56, 24)), 24) * (180 / Math.Pow(2, 23)));
                this.TableTID.Add("Longitude [º]"); this.TableTID.Add(this.Longitude);

                this.PointType = defaultPointType[Convert.ToInt32(string.Join("", BinaryTrajectoryIntent.GetRange(80, 4)), 2)];
                this.TableTID.Add("Point Type"); this.TableTID.Add(this.PointType);

                this.TD = defaultTD[Convert.ToInt32(string.Join("", BinaryTrajectoryIntent.GetRange(84, 2)), 2)];
                this.TableTID.Add("TD"); this.TableTID.Add(this.TD);

                this.TRA = defaultTRA[Convert.ToInt32(BinaryTrajectoryIntent[86], 2)];
                this.TableTID.Add("TRA"); this.TableTID.Add(this.TRA);

                this.TOA = defaultTOA[Convert.ToInt32(BinaryTrajectoryIntent[87], 2)];
                this.TableTID.Add("TOA"); this.TableTID.Add(this.TOA);

                this.TOV = Convert.ToString(Convert.ToInt32(string.Join("", BinaryTrajectoryIntent.GetRange(88, 24)), 2));
                this.TableTID.Add("TOV [s]"); this.TableTID.Add(this.TOV);

                this.TTR = Convert.ToString(Convert.ToInt32(string.Join("", BinaryTrajectoryIntent.GetRange(112, 16)), 2) * 0.01);
                this.TableTID.Add("TTR [Nm]"); this.TableTID.Add(this.TTR);
            }
        }

        public static double binTwosComplementToSignedDecimal(string binary, int significantBits)
        {
            double power = Math.Pow(2, significantBits - 1);
            double sum = 0;
            int i;
            for (i = 0; i < significantBits; ++i)
            {
                if (i == 0 && binary[i] != '0')
                    sum = power * -1;
                else
                    sum += (binary[i] - '0') * power;
                power /= 2;
            }
            return sum;
        }
    }
}
