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

namespace Weater_Application.ViewModels
{
    internal class WeatherToIcoConverter : IValueConverter
    {
        private string Path = "avares://Weater Application/Assets/ico style 2/";


        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is UserWeather userWeater)
            {
                return Loader(userWeater.Time, userWeater.WeatherID);
            }
            if (value is WeeklyUserWeather weeklyUserWeather)
            {
                return Loader(weeklyUserWeather.Time, weeklyUserWeather.WeatherID);
            }

            return new Bitmap(AssetLoader.Open(new Uri($"{Path}blue-cloud-and-weather.png")));
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public Bitmap Loader(string Time, int WeatherID)
        {
            // Day
            if (System.Convert.ToInt32(Time.Substring(0, Time.LastIndexOf(":"))) < 17 &&
                        System.Convert.ToInt32(Time.Substring(0, Time.LastIndexOf(":"))) > 6)
            {
                switch (WeatherID)
                {
                    case 500:
                        return new Bitmap(AssetLoader.Open(new Uri($"{Path}rainy-and-cloudy-day.png")));
                    case 600:
                        return new Bitmap(AssetLoader.Open(new Uri($"{Path}yellow-sun-and-snow-with-blue-cloud.png")));
                    case 601:
                        return new Bitmap(AssetLoader.Open(new Uri($"{Path}snowfall-and-blue-cloud.png")));
                    case 804:
                        return new Bitmap(AssetLoader.Open(new Uri($"{Path}blue-clouds-and-yellow-sun.png")));
                    default:
                        return new Bitmap(AssetLoader.Open(new Uri($"{Path}yellow-sun.png")));
                }
            }
            else // Night
            {
                switch (WeatherID)
                {
                    case 500:
                        return new Bitmap(AssetLoader.Open(new Uri($"{Path}rainy-and-cloudy-day.png")));
                    case 600:
                        return new Bitmap(AssetLoader.Open(new Uri($"{Path}blue-moon-and-snowy-night.png")));
                    case 601:
                        return new Bitmap(AssetLoader.Open(new Uri($"{Path}snowfall-and-blue-cloud.png")));
                    case 804:
                        return new Bitmap(AssetLoader.Open(new Uri($"{Path}blue-clouds-and-blue-moon.png")));
                    default:
                        return new Bitmap(AssetLoader.Open(new Uri($"{Path}yellow-moon.png")));
                }
            }
        }
    }
}
