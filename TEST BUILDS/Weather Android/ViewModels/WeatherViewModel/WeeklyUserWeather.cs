using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Android.ViewModels;
public class WeeklyUserWeather : UserWeather
{
    public WeeklyUserWeather(string? temperature, string? humidity, string? wind, string? airPressure, string? uV, int weatherID, string? time, string? secondTemperature) : base(temperature, humidity, wind, airPressure, uV, weatherID, time)
    {
        SecondTemperature = secondTemperature;
    }

    public string? DayTime { get; set; }
    public string? SecondTemperature { get; set; }
}
