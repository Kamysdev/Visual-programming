using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorPicker.ColorCore
{
    public class CoreColors
    {
        public CoreColors(string colorBrush)
        {
            ColorBrush = colorBrush;
        }

        public string ColorBrush { get; set; }
    }
}
