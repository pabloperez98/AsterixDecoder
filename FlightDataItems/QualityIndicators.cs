using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightDataItems
{
    public class QualityIndicators
    {
        //First octet
        public string NUCr_or_NACv;
        public string NUCp_or_NIC;
        //First extension
        public string NICbaro;
        public string SIL;
        public string NACp;
        //Second extension
        public string SILsupplement;
        public string SDA;
        public string GVA;
        //Third extension
        public string PIC;

        public double HorizontalAccuracy;
        public double VerticalAccuracy;
        public double doublePIC;

        public List<string> TableQI = new List<string>();

        public QualityIndicators(List<string> BinaryQualityIndicator)
        {
            
            int nextOctet = 0;
            for (int octet = 0; octet < BinaryQualityIndicator.Count() / 8; octet++)
            {
                List<string> infoOctet = new List<string>();
                for (int bit = 0; bit < 7; bit++)    
                    infoOctet.Add(BinaryQualityIndicator[bit + nextOctet]);
                if (octet == 0)
                {
                    List<string> defaultNIC = new List<string>() { "Rc unknown", "Rc < 37.04km (20NM)", "Rc < 14.816km (8NM)", "Rc < 7.408km (4NM)", "Rc < 3.704km (2NM)", "Rc < 1852m (1NM)", "Rc < 926m (0.5NM)", "Rc < 370.4m (0.2NM)", "Rc < 185.2m (0.1NM)", "Rc < 75m", "Rc < 25m", "Rc < 7.5m", "Reserved", "Reserved", "Reserved", "Reserved" };
                    this.NUCr_or_NACv = Convert.ToInt32(string.Join("",infoOctet.GetRange(0,3)), 2).ToString();
                    this.NUCp_or_NIC = defaultNIC[Convert.ToInt32(string.Join("", infoOctet.GetRange(3, 4)), 2)];
                    this.TableQI.Add("NUCr or NAVc"); this.TableQI.Add(this.NUCr_or_NACv);
                    this.TableQI.Add("NUCp or NIC"); this.TableQI.Add(this.NUCp_or_NIC);
                }
                if (octet == 1)
                {
                    List<double> defaultHorizontalAccuracy = new List<double>() { 18520, 7402, 3704, 1852, 926, 555.6, 185.2, 92.6, 30, 10, 3, 0, 0, 0, 0 };
                    List<string> defaultNACp = new List<string>() { "EPU >= 18.52km (10NM)", "EPU < 18.52km (10NM)", "EPU < 7.408km (4NM)", "EPU < 3.704km (2NM)", "EPU < 1852m (1NM)", "EPU < 926m (0.5NM)", "EPU < 555.6m (0.3NM)", "EPU < 185.2m (0.1NM)", "EPU < 92.6m (0.05NM)", "EPU < 30m", "EPU < 10m", "EPU < 3m", "Reserved", "Reserved", "Reserved", "Reserved" };
                    this.NICbaro = Convert.ToInt32(string.Join("", infoOctet.GetRange(0, 1)), 2).ToString();
                    this.SIL = Convert.ToInt32(string.Join("", infoOctet.GetRange(1, 2)), 2).ToString();
                    this.NACp = defaultNACp[Convert.ToInt32(string.Join("", infoOctet.GetRange(3, 4)), 2)];
                    this.HorizontalAccuracy = defaultHorizontalAccuracy[Convert.ToInt32(string.Join("", infoOctet.GetRange(3, 4)), 2)];
                    this.TableQI.Add("NICbaro"); this.TableQI.Add(this.NICbaro);
                    this.TableQI.Add("SIL"); this.TableQI.Add(this.SIL);
                    this.TableQI.Add("NACp"); this.TableQI.Add(NACp);
                }  
                if (octet == 2)
                {
                    List<string> defaultGVA = new List<string>() { "Unknown or > 150m", "<= 150m", "<= 45m", "Reserved"};
                    List<double> defaultVerticalAccuracy = new List<double>() {150, 150, 45, 0 };
                    this.SILsupplement = Convert.ToInt32(string.Join("", infoOctet.GetRange(2, 1)), 2).ToString();
                    this.SDA = Convert.ToInt32(string.Join("", infoOctet.GetRange(3, 2)), 2).ToString();
                    this.GVA = defaultGVA[Convert.ToInt32(string.Join("", infoOctet.GetRange(5, 2)), 2)];
                    this.VerticalAccuracy = defaultVerticalAccuracy[Convert.ToInt32(string.Join("", infoOctet.GetRange(5, 2)), 2)];
                    this.TableQI.Add("SIL Supplement"); this.TableQI.Add(this.SILsupplement);
                    this.TableQI.Add("SDA"); this.TableQI.Add(this.SDA);
                    this.TableQI.Add("GVA"); this.TableQI.Add(this.GVA);
                }
                if (octet ==3)
                {
                    List<double> defaultDoblePIC = new List<double> { 0, 20, 10, 8, 4, 2, 1, 0.6, 0.5, 0.3, 0.2, 0.1, 0.04, 0.013, 0.004, 0};
                    List<string> defaultPIC = new List<string>() { "No integrity", "<20.0NM", "<10.0NM", "<8.0NM", "<4.0NM", "<2.0NM", "<1.0NM", "<0.6NM", "<0.5NM", "<0.3NM", "<0.2NM", "<0.1NM", "<0.04NM", "<0.013NM", "<0.004NM", "Not defined" };
                    this.PIC = defaultPIC[Convert.ToInt32(string.Join("", infoOctet.GetRange(0, 4)), 2)];
                    this.doublePIC = defaultDoblePIC[Convert.ToInt32(string.Join("", infoOctet.GetRange(0, 4)), 2)];
                    this.TableQI.Add("PIC"); this.TableQI.Add(this.PIC);
                }
                nextOctet += 8;
            }
        }

        public QualityIndicators()
        {
            this.NUCp_or_NIC = "N/A";
            this.NUCr_or_NACv = "N/A";
            this.NICbaro = "N/A";
            this.SIL = "N/A";
            this.SILsupplement = "N/A";
            this.NACp = "N/A";
            this.SDA = "N/A";
            this.GVA = "N/A";
            this.PIC = "N/A";
            this.HorizontalAccuracy = 0;
            this.VerticalAccuracy = 0;
        }
    }
}
