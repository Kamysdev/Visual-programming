using Avalonia.Media.Imaging;
using ExCSS;

namespace Weater_Application.ViewModels;

public class UserWeather : WeatherViewModel
{
    public UserWeather(string? temperature, string? humidity, string? wind, string? airPressure, string? uV, int weatherID, string? time) : base(temperature, humidity, wind, airPressure, uV, weatherID)
    {
        Time = time;
    }
    public string? Time { get; set; }
}

