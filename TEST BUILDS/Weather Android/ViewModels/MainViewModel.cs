using Avalonia.Media.Imaging;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System;

namespace Weather_Android.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly WeatherApiService _weatherApiService;

    public ObservableCollection<UserWeather> WeatherList { get; set; } = [];

    public ObservableCollection<WeeklyUserWeather> WeeklyWeatherList { get; set; } = [];

    public WeeklyUserWeather? SelectedWeeklyWeather
    {
        get => _SelectedWeeklyWeather;
        set { _SelectedWeeklyWeather = value; OnPropertyChanged(nameof(SelectedWeeklyWeather)); }
    }
    public WeeklyUserWeather? _SelectedWeeklyWeather { get; set; }

    public WeatherViewModel? SelectedWeather
    {
        get => _SelectedWeather;
        set { _SelectedWeather = value; OnPropertyChanged(nameof(SelectedWeather)); }
    }
    private WeatherViewModel? _SelectedWeather { get; set; }

    public string? CurrentDay
    {
        get => _CurrentDay;
        set { _CurrentDay = value; OnPropertyChanged(nameof(CurrentDay)); }
    }
    private string? _CurrentDay { get; set; }

    public string CurrentTemp
    {
        get => _CurrentTemp;
        set { _CurrentTemp = value; OnPropertyChanged(nameof(CurrentTemp)); }
    }
    private string _CurrentTemp { get; set; }

    public Bitmap CurrentIco
    {
        get => _CurrentIco;
        set { _CurrentIco = value; OnPropertyChanged(nameof(CurrentIco)); }
    }
    private Bitmap _CurrentIco { get; set; }

    public string CurrentCity
    {
        get => _CurrentCity;
        set { _CurrentCity = value; OnPropertyChanged(nameof(CurrentCity)); }
    }
    public string _CurrentCity { get; set; }

    public ICommand GetWeatherFromCollection { get; }

    public MainViewModel()
    {
        _weatherApiService = new WeatherApiService();

        CurrentCity = "Novosibirsk";

        SetTheme();
        SetCurrentTime();
        FetchWeatherInformation();
        WeatherList.Add(new UserWeather("+22", "85%", "2 m/s", "720mm", "15", 600, "22:00"));
    }

    private void SetCurrentTime()
    {
        CurrentDay = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.Day.ToString();
    }

    public void MakeTask(object param)
    {
        FetchWeatherInformation();
    }

    private async Task FetchWeatherInformation()
    {
        var weatherApiResponse = await _weatherApiService.GetWeatherInformation(CurrentCity);
        if (weatherApiResponse != null)
        {
            WeatherList.Clear();
            for (int i = 0; i < 40; i++)
            {
                WeatherList.Add(new UserWeather($"{Math.Round(Convert.ToDouble(weatherApiResponse.List[i].main.temp))}°C",
                    $"{weatherApiResponse.List[i].main.humidity}%",
                    $"{Math.Round(Convert.ToDouble(weatherApiResponse.List[i].wind.speed), 1)} m/s",
                    $"{weatherApiResponse.List[i].main.pressure} mm",
                    $"{Math.Round(Convert.ToDouble(weatherApiResponse.List[i].main.feels_like))}°C",
                    weatherApiResponse.List[i].weather[0].id, GetTime(weatherApiResponse.List[i].dt_txt)));
            }
            CurrentTemp = WeatherList[0].Temperature;
            CurrentIco = new WeatherToIcoConverter().Loader(WeatherList[0].Time, WeatherList[0].WeatherID);
            WeeklyWeatherList.Clear();
            SetWeeklyWeather();
        }
    }

    private string GetTime(string date)
    {
        int tempTime = System.Convert.ToInt32(date.Substring(date.LastIndexOf(" ") + 1).Remove(2));
        if (tempTime <= 19)
        {
            tempTime += 4;
        }
        else
        {
            tempTime -= 20;
        }

        return tempTime.ToString() + ":00";
    }
}
