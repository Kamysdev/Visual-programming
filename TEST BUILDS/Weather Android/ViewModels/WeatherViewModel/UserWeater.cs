using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Android.ViewModels;

public class UserWeather : WeatherViewModel
{
    public UserWeather(string? temperature, string? humidity, string? wind, string? airPressure, string? uV, int weatherID, string? time) : base(temperature, humidity, wind, airPressure, uV, weatherID)
    {
        Time = time;
    }
    public string? Time { get; set; }
}
