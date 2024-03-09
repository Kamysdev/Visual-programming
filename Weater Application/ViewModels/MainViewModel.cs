using System.Net.Http;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Weater_Application.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly WeatherApiService _weatherApiService;

    public ObservableCollection<UserWeater> WeatherList { get; set; } = [];
    
    public WeatherViewModel? SelectedWeather {
        get => _SelectedWeather;
        set { _SelectedWeather = value; OnPropertyChanged(nameof(SelectedWeather)); }
    }

    public WeatherViewModel? _SelectedWeather { get; set; }

    public string CurrentDay
    {
        get => _CurrentDay;
        set { _CurrentDay = value; OnPropertyChanged(nameof(CurrentDay)); }
    }
    public string _CurrentDay { get; set; }

    public string CurrentTemp { get; set; }

    public ICommand GetWeatherFromCollection { get; }

    public MainViewModel()
    {
        _weatherApiService = new WeatherApiService();

        SetCurrentTime();
        CurrentTemp = "-27";
        FetchWeatherInformation();
    }

    UserWeater weater;

    private void SetCurrentTime()
    {
        CurrentDay = System.DateTime.Now.DayOfWeek.ToString() + ", " + System.DateTime.Now.Day.ToString();
    }

    public class MainUserWeather : WeatherViewModel
    {
        public MainUserWeather(string? temperature, string? humidity, string? wind, string? airPressure, string? uV) : base(temperature, humidity, wind, airPressure, uV)
        {
        }

        public string? City { get; set; }
    }

    public class UserWeater : WeatherViewModel
    {
        public UserWeater(string? temperature, string? humidity, string? wind, string? airPressure, string? uV) : base(temperature, humidity, wind, airPressure, uV)
        {
        }

        public string? Time { get; set; }
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

    private async Task FetchWeatherInformation()
    {
        var weatherApiResponse = await _weatherApiService.GetWeatherInformation("Novosibirsk");
        if (weatherApiResponse != null) 
        {
            for (int i = 0; i < 5; i++) 
            {
                WeatherList.Add(new UserWeater($"{weatherApiResponse.List[i].main.temp}°",
                    $"{weatherApiResponse.List[i].main.humidity}%",
                    $"{weatherApiResponse.List[i].wind.speed} m/s",
                    $"{weatherApiResponse.List[i].main.pressure} mm",
                    $"{weatherApiResponse.List[i].clouds.all}"));
            }
        }
    }
}
