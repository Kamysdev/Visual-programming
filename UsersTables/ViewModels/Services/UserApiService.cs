using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UsersTables.ViewModels.ApiModels;

namespace UsersTables.ViewModels.Services;

internal class UserApiService
{
    private readonly HttpClient _httpClient;

    public UserApiService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://jsonplaceholder.typicode.com/")
        };
    }

    public async Task<UserApiResponse> GetUserInformation()
    {
        return await _httpClient.GetFromJsonAsync<UserApiResponse>("users");
    }
}
