using System.Threading;
using System.Text.Json;
using System.IO;
using System.Net.Http;
using System;
using System.Net.Http.Json;
using System.Collections.ObjectModel;

namespace Weater_Application.ViewModels;

public class MainViewModel : BaseViewModel
{
    private string APIKEY = "e2ed2c756067721c0b6d55a31ca957d0";

    public ObservableCollection<WeatherViewModel> WeatherList { get; set; } = [];

    public WeatherViewModel? SelectedWeather {  get; set; }

    public string CurrentDay
    {
        get => _CurrentDay;
        set { _CurrentDay = value; OnPropertyChanged(nameof(CurrentDay)); }
    }

    public string _CurrentDay { get; set; }

    public string CurrentTemp { get; set; }


    public MainViewModel()
    {
        SetCurrentTime();
        CurrentTemp = "-27";
        MakeAPIWeatherCall();

        SelectedWeather = new WeatherViewModel("fwfwa", "dawgaw ", "fawga", "waewa", "jtjtdfjr");

        WeatherList.Add(SelectedWeather);
        WeatherList.Add(SelectedWeather);
        WeatherList.Add(SelectedWeather);
    }

    private void SetCurrentTime()
    {
        CurrentDay = System.DateTime.Now.DayOfWeek.ToString() + ", " + System.DateTime.Now.Day.ToString();
    }

    public class WeatherViewModel 
    {
        public WeatherViewModel(string? temperature, string? humidity, string? wind, string? airPressure, string? uV)
        {
            Temperature = temperature;
            Humidity = humidity;
            Wind = wind;
            AirPressure = airPressure;
            UV = uV;
        }

        public string? Temperature { get; }
        public string? Humidity { get; }
        public string? Wind { get; }
        public string? AirPressure { get; }
        public string? UV { get; }


    }

    public class Location 
    { 
        public string? lat { get; set; }
        public string? lng { get; set; }
    }

    public void MakeAPIAdressCall()
    {
        using HttpClient client = new()
        {
            BaseAddress = 
            new Uri("http://api.openweathermap.org/geo/1.0/direct?q=London&limit=5&appid=e2ed2c756067721c0b6d55a31ca957d0")
        };
    }

    public async void MakeAPIWeatherCall()
    {
        using HttpClient client = new()
        {
            BaseAddress = 
            new Uri("https://api.openweathermap.org/data/2.5/weather?lat=44.34&lon=10.99&appid=e2ed2c756067721c0b6d55a31ca957d0")
        };
    }
}
