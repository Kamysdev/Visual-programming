using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorPicker.ColorCore
{
    public class CoreColorsRGBA
    {
        public CoreColors CoreColors { get; set; }

        public int R {  get; set; }
        public int G {  get; set; }
        public int B {  get; set; }
        public int A {  get; set; }

        public CoreColorsRGBA(int r, int g, int b, int a, CoreColors hexColor)
        {
            R = r; G = g; B = b; A = a; CoreColors = hexColor;
        }

        public CoreColorsRGBA(int r, int g, int b, int a)
        {
            R = r; G = g; B = b; A = a;
            CoreColors = new CoreColors();
            ColorParser parser = new ColorParser();
            CoreColors.ColorBrush = parser.ConverToHEX(this);
        }

        public CoreColorsRGBA(CoreColors coreColors)
        {
            CoreColors = coreColors;
        }

        public CoreColorsRGBA(CoreColorsRGBA inputColor)
        {
            R = inputColor.R;
            G = inputColor.G;
            B = inputColor.B;
            A = inputColor.A;
            CoreColors = inputColor.CoreColors;
        }

        public CoreColorsRGBA()
        {

        }
    }
}
