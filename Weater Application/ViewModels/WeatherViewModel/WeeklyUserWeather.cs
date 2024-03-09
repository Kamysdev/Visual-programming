using Avalonia.Media.Imaging;

namespace Weater_Application.ViewModels;

public class WeeklyUserWeather : UserWeather
{
    public WeeklyUserWeather(string? temperature, string? humidity, string? wind, string? airPressure, string? uV, int weatherID, string? time, string? secondTemperature) : base(temperature, humidity, wind, airPressure, uV, weatherID, time)
    {
        SecondTemperature = secondTemperature;
    }

    public string? DayTime { get; set; }
    public string? SecondTemperature { get; set; }
}