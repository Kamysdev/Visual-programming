using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorPicker.ColorCore
{
    internal class ColorParser
    {
        public string ConverToHEX(CoreColorsRGBA coreRGBA)
        {
            string HEX = "#";

            HEX += Get16X(coreRGBA.R) + Get16X(coreRGBA.G) + Get16X(coreRGBA.B);

            return HEX;
        }
        private string Get16X(int colorCode)
        {
            if (colorCode >= 16) 
            { 
                return Convert.ToString(colorCode, 16).ToUpper();
            }
            else
            {
                return "0" + Convert.ToString(colorCode, 16).ToUpper();
            }
        }

        public CoreColorsRGBA ParseToBYTE(string HEX)
        {
            HEX = HEX.Remove(0, 1);

            return new CoreColorsRGBA(int.Parse(HEX.Remove(2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(HEX.Remove(0, 2).Remove(2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(HEX.Remove(0, 4), System.Globalization.NumberStyles.HexNumber), 255);
        }
    }
}
