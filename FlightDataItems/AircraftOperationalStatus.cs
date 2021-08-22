using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class AircraftOperationalStatus
    {
        public string RA;
        public string TC;
        public string TS;
        public string ARV;
        public string CDTI_A;
        public string Not_TCAS;
        public string SA;
        public List<string> TableAOS = new List<string>();

        public AircraftOperationalStatus(List<string> BinaryAircraftOperationalStatus)
        {
            List<string> defaultRA = new List<string>() { "TCAS II or ACAS RA not active", "TCAS RA active" };
            List<string> defaultTC = new List<string>() { "no capability for Trajectory Change Reports", "support for TC+0 reposrts only", "support for multiple TC reports", "reserved" };
            List<string> defaultTS = new List<string>() { "no capability to support Target State Reports", "capable of supporting target State Reports" };
            List<string> defaultARV = new List<string>() { "no capability to generate ARV-reports", "capable of generate ARV-reports" };
            List<string> defaultCDTI = new List<string>() { "CDTI not operational", "CDTI operational" };
            List<string> defaultnotTCAS = new List<string>() { "TCAS operational", "TCAS not oeprational" };
            List<string> defaultSA = new List<string>() { "Antenna Diversity", "Single Antenna only" };

            this.RA = defaultRA[Convert.ToInt32(BinaryAircraftOperationalStatus[0], 2)];
            this.TC = defaultTC[Convert.ToInt32(BinaryAircraftOperationalStatus[1] + BinaryAircraftOperationalStatus[2], 2)];
            this.TS = defaultTS[Convert.ToInt32(BinaryAircraftOperationalStatus[3], 2)];
            this.ARV = defaultARV[Convert.ToInt32(BinaryAircraftOperationalStatus[4], 2)];
            this.CDTI_A = defaultCDTI[Convert.ToInt32(BinaryAircraftOperationalStatus[5], 2)];
            this.Not_TCAS = defaultnotTCAS[Convert.ToInt32(BinaryAircraftOperationalStatus[6], 2)];
            this.SA = defaultSA[Convert.ToInt32(BinaryAircraftOperationalStatus[7], 2)];
            
            TableAOS.Add("RA"); TableAOS.Add(this.RA);
            TableAOS.Add("TC"); TableAOS.Add(this.TC);
            TableAOS.Add("TS"); TableAOS.Add(this.TS);
            TableAOS.Add("ARV"); TableAOS.Add(this.ARV);
            TableAOS.Add("CDTI_A"); TableAOS.Add(this.CDTI_A);
            TableAOS.Add("Not_TCAS"); TableAOS.Add(this.Not_TCAS);
            TableAOS.Add("SA"); TableAOS.Add(this.SA);
        }

        public AircraftOperationalStatus()
        {
            this.RA = "N/A";
            this.TC = "N/A";
            this.TS = "N/A";
            this.ARV = "N/A";
            this.CDTI_A = "N/A";
            this.Not_TCAS = "N/A";
            this.SA = "N/A";
        }
    }
}
