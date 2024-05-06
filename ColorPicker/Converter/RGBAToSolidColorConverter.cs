using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Platform;
using ColorPicker.ColorCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorPicker.Converter
{
    internal class RGBAToSolidColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is CoreColors color)
            {
                ColorParser parser = new ColorParser();

                CoreColorsRGBA _convertSolidColor = new CoreColorsRGBA(parser.ParseToBYTE(color.ColorBrush));

                return new SolidColorBrush(Color.FromArgb(255, (byte)_convertSolidColor.R, (byte)_convertSolidColor.G, (byte)_convertSolidColor.B));
            }

            return new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
