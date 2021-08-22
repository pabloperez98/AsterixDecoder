using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class SurfaceCapabilitiesAndCharacteristics
    {
        string POA;
        string CDTI_S;
        string B2low;
        string RAS;
        string IDENT;
        string Length;
        string Width;

        public List<string> TableSCC = new List<string>();
        public SurfaceCapabilitiesAndCharacteristics(List<string> BinarySurfaceCapabilitiesAndCharacteristics)
        {
            int nextOctet = 0;
            for (int octets = 0; octets < BinarySurfaceCapabilitiesAndCharacteristics.Count/8; octets++)
            {
                if (octets == 0)
                {
                    List<string> defaultPOA = new List<string>() { "Position transmitted is not ADS-B position reference points", "Position tansmitted is the ADS-B position reference point" };
                    List<string> defaultCDTI = new List<string>() { "CDTI not operational", "CDTI operational" };
                    List<string> defaultB2 = new List<string>() { ">=70Watts", "<70 Watts" };
                    List<string> defaultRAS = new List<string>() { "Aircrafts not receiving ATC-services", "Aircraft receiving ATC services" };
                    List<string> defaultIDENT = new List<string>() { "IDENT switch not active", "IDENT switch active" };
                    this.POA = defaultPOA[Convert.ToInt32(BinarySurfaceCapabilitiesAndCharacteristics[2], 2)];
                    this.CDTI_S = defaultCDTI[Convert.ToInt32(BinarySurfaceCapabilitiesAndCharacteristics[3], 2)];
                    this.B2low = defaultB2[Convert.ToInt32(BinarySurfaceCapabilitiesAndCharacteristics[4], 2)];
                    this.RAS = defaultRAS[Convert.ToInt32(BinarySurfaceCapabilitiesAndCharacteristics[5], 2)];
                    this.IDENT = defaultIDENT[Convert.ToInt32(BinarySurfaceCapabilitiesAndCharacteristics[6], 2)];
                    this.TableSCC.Add("POA"); this.TableSCC.Add(this.POA);
                    this.TableSCC.Add("CDTI_S"); this.TableSCC.Add(this.CDTI_S);
                    this.TableSCC.Add("B2low"); this.TableSCC.Add(this.B2low);
                    this.TableSCC.Add("RAS"); this.TableSCC.Add(this.RAS);
                    this.TableSCC.Add("IDENT"); this.TableSCC.Add(this.IDENT);
                }
                if (octets == 1)
                {
                    List<string> defaultL = new List<string>() { "L<15", "L<15", "L<25", "L<25", "L<35", "L<35", "L<45", "L<45", "L<55", "L<55", "L<65", "L<65", "L<75", "L<75", "L<85", "L>85" };
                    List<string> defaultW = new List<string>() { "W<11,5", "W<23", "W<28,5", "W<34", "W<33", "W<38", "W<39,5", "W<45", "W<45", "W<52", "W<59,5", "W<67", "W<72,5", "W<80", "W<80", "W>80" };
                    int position = Convert.ToInt32(string.Concat(BinarySurfaceCapabilitiesAndCharacteristics[4], BinarySurfaceCapabilitiesAndCharacteristics[5], BinarySurfaceCapabilitiesAndCharacteristics[6], BinarySurfaceCapabilitiesAndCharacteristics[7]), 2);
                    this.Length = defaultL[position];
                    this.Width = defaultW[position];
                    this.TableSCC.Add("Length"); this.TableSCC.Add(this.Length);
                    this.TableSCC.Add("Width"); this.TableSCC.Add(this.Width);
                }
                nextOctet += 8;
            }
        }
        public SurfaceCapabilitiesAndCharacteristics()
        {
            this.POA = "N/A";
            this.CDTI_S = "N/A";
            this.B2low = "N/A";
            this.RAS = "N/A";
            this.IDENT = "N/A";
            this.Length = "N/A";
            this.Width = "N/A";
        }
    }
}
