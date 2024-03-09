namespace Weater_Application.ViewModels;

public partial class MainViewModel
{
    public class UserWeater(string? temperature, string? humidity, string? wind, string? airPressure, string? uV, string? time) : WeatherViewModel(temperature, humidity, wind, airPressure, uV)
    {
        public string? Time { get; set; } = time;
    }
}
