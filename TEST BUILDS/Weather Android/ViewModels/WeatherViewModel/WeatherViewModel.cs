using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Android.ViewModels;

public class WeatherViewModel
{
    public WeatherViewModel(string? temperature, string? humidity, string? wind, string? airPressure, string? uV, int weatherID)
    {
        Temperature = temperature;
        Humidity = humidity;
        Wind = wind;
        AirPressure = airPressure;
        UV = uV;
        WeatherID = weatherID;
    }

    public string? Temperature { get; set; }
    public string? Humidity { get; }
    public string? Wind { get; }
    public string? AirPressure { get; }
    public string? UV { get; }
    public int WeatherID { get; set; }
}

