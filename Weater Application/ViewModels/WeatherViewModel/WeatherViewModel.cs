namespace Weater_Application.ViewModels;

public partial class MainViewModel
{
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
}
