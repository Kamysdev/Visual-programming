using System.Net.Http;
using System;
using System.Threading.Tasks;
using Weater_Application.ViewModels.ApiModels;
using DynamicData.Kernel;
using System.Net.Http.Json;

namespace Weater_Application.ViewModels;

internal class WeatherApiService
{
    private readonly HttpClient _httpClient;

    public WeatherApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL);
    }

    public async Task<WeatherApiResponse> GetWeatherInformation(string city)
    {
        return await _httpClient.GetFromJsonAsync<WeatherApiResponse>($"forecast?q={city}&units=metric&appid={Constants.API_KEY}");
    }
}