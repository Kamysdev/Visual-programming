using System.Net.Http;
using System;
using System.Threading.Tasks;
using Weather_Android.ViewModels.ApiModels;
using DynamicData.Kernel;
using System.Net.Http.Json;

namespace Weather_Android.ViewModels;
internal class WeatherApiService
{
    private readonly HttpClient _httpClient;

    public WeatherApiService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(Constants.API_BASE_URL)
        };
    }

    public async Task<WeatherApiResponse> GetWeatherInformation(string city)
    {
        return await _httpClient.GetFromJsonAsync<WeatherApiResponse>($"forecast?q={city}&units=metric&appid={Constants.API_KEY}");
    }
}
