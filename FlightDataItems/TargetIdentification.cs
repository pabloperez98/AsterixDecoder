using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class TargetIdentification
    {
        public string STI;
        public string TargetID;

        public TargetIdentification()
        {
            this.STI = "N/A";
            this.TargetID = "N/A";
        }

        public TargetIdentification(List<string> BinTargetIdentification)
        {
            List<string> defaultSTI = new List<string>() { "Callsign or registration downlinked from transponder", "Callsign not downlinked from transponder", "Registration not downlinked from transponder" };
            int pos = 0;
            if (BinTargetIdentification.Count == 8*7) //CAT10 & CAT62
            {
                this.STI = defaultSTI[Convert.ToInt32(string.Join("", BinTargetIdentification.GetRange(0,2)), 2)];
                pos += 8;
            }
            for (int ch = 0; ch < 8; ch++)
            {
                string character = string.Join("",BinTargetIdentification.GetRange(pos, 6));
                this.TargetID += CodingRules(character);
                pos += 6;
            }
            if (this.TargetID == "") //Algunos paquetes del ADS-B v023 el FSPEC te dice que tiene Target ID y luego el campo son bits en 0
                this.TargetID = "N/A";
        }

        public string CodingRules(string CharacterStr)
        {
            List<string> code = new List<string>() { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string Character = code[Convert.ToInt32(CharacterStr, 2)];
            return Character;
        }
    }
}
