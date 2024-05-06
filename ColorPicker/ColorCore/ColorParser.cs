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
    }
}
