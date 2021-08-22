using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class Mode5DataReports
    {
        public Mode5Summary SUM; //Mode 5 Summary Subfield
        public string PMN; //Mode 5 PIN/National Origin/Mission Code Subfield
        public PositionWGS84Coordinates POS; //Mode 5 Reported Position Subfield
        public string GA; //Mode 5 GNSS-derived Altitude Subfield
        public string EM1; //Extended Mode 1 Code in Octal Representation Subfield
        public string TOS; //Time Offset for POS and GA Subfield
        public PresenceX_Pulse XP; //X Pulse Presence Subfield

        public List<string> TableM5DR = new List<string>();
        
        public Mode5DataReports()
        {
            this.SUM = new Mode5Summary(); //Mode 5 Summary Subfield
            this.PMN = "N/A"; //Mode 5 PIN/National Origin/Mission Code Subfield
            this.POS = new PositionWGS84Coordinates(); //Mode 5 Reported Position Subfield
            this.GA = "N/A"; //Mode 5 GNSS-derived Altitude Subfield
            this.EM1 = "N/A"; //Extended Mode 1 Code in Octal Representation Subfield
            this.TOS = "N/A"; //Time Offset for POS and GA Subfield
            this.XP = new PresenceX_Pulse(); //X Pulse Presence Subfield
        }

        public void InsertM5DRinfoInTable(string field, string value)
        {
            this.TableM5DR.Add(field);
            this.TableM5DR.Add(value);
        }
    }
}
