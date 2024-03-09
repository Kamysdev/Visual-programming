using System.Net.Http;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Weater_Application.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly WeatherApiService _weatherApiService;

    public ObservableCollection<UserWeater> WeatherList { get; set; } = [];
    
    public WeatherViewModel? SelectedWeather {
        get => _SelectedWeather;
        set { _SelectedWeather = value; OnPropertyChanged(nameof(SelectedWeather)); }
    }
    public WeatherViewModel? _SelectedWeather { get; set; }

    public string? CurrentDay
    {
        get => _CurrentDay;
        set { _CurrentDay = value; OnPropertyChanged(nameof(CurrentDay)); }
    }
    public string? _CurrentDay { get; set; }

    public string CurrentTemp { get; set; }

    public ICommand GetWeatherFromCollection { get; }

    public MainViewModel()
    {
        _weatherApiService = new WeatherApiService();

        SetCurrentTime();
        CurrentTemp = "-27";
        FetchWeatherInformation();
    }

    private void SetCurrentTime()
    {
        CurrentDay = System.DateTime.Now.DayOfWeek.ToString() + ", " + System.DateTime.Now.Day.ToString();
    }

    private async Task FetchWeatherInformation()
    {
        var weatherApiResponse = await _weatherApiService.GetWeatherInformation("Novosibirsk");
        if (weatherApiResponse != null) 
        {
            for (int i = 0; i < 5; i++) 
            {
                WeatherList.Add(new UserWeater($"{Math.Round(System.Convert.ToDouble(weatherApiResponse.List[i].main.temp))}°C",
                    $"{weatherApiResponse.List[i].main.humidity}%",
                    $"{Math.Round(System.Convert.ToDouble(weatherApiResponse.List[i].wind.speed), 1)} m/s",
                    $"{weatherApiResponse.List[i].main.pressure} mm",
                    $"{Math.Round(System.Convert.ToDouble(weatherApiResponse.List[i].main.feels_like))}°C",
                    "18:00"));
            }
        }
    }
}
