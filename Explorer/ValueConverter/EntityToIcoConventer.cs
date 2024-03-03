using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Explorer.ViewModels
{
    internal class EntityToIcoConventer : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is FileViewModel)
            {
                return new Bitmap(AssetLoader.Open(new Uri("avares://Explorer/Assets/Documents.ico")));
            }

            return new Bitmap(AssetLoader.Open(new Uri("avares://Explorer/Assets/Folder-Yellow.ico")));
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
