using System;
using System.Collections.Generic;

namespace FlightDataItems
{
    public class FigureOfMerit
    {
        public string AC;
        public string MN;
        public string DC;
        public string PA;

        public List<string> TableFM = new List<string>();
        public FigureOfMerit(List<string> BinFigureOfMerit)
        {
            List<string> defaultAC = new List<string>() { "Unknown", "ACAS not operational", "ACAS operational", "Invalid" };
            List<string> defaultMN = new List<string>() { "Unknown", "Multiple navigational aids not operating", "Multiple navigational aids operating", "Invalid" };
            List<string> defaultDC = new List<string>() { "Unknown", "Differential correction", "No differential correction", "Invalid" };

            AC = defaultAC[Convert.ToInt32(string.Join("", BinFigureOfMerit[0],BinFigureOfMerit[1]), 2)];;
            MN = defaultAC[Convert.ToInt32(string.Join("", BinFigureOfMerit[2], BinFigureOfMerit[3]), 2)];
            DC = defaultAC[Convert.ToInt32(string.Join("", BinFigureOfMerit[4], BinFigureOfMerit[5]), 2)];
            PA = Convert.ToString(Convert.ToInt32(string.Join("", BinFigureOfMerit[12], BinFigureOfMerit[13], BinFigureOfMerit[14], BinFigureOfMerit[15]), 2));

            this.TableFM.Add("AC"); this.TableFM.Add(this.AC);
            this.TableFM.Add("MN"); this.TableFM.Add(this.MN);
            this.TableFM.Add("DC"); this.TableFM.Add(this.DC);
            this.TableFM.Add("PA"); this.TableFM.Add(this.PA);
        }
        public FigureOfMerit()
        {
            AC = "N/A";
            MN = "N/A";
            DC = "N/A";
            PA = "N/A";
        }
    }
}
