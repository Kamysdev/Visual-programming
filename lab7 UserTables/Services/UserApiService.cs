using lab7.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace lab7.Services
{
    internal class UserApiService
    {
        private readonly HttpClient _httpClient;

        public UserApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        public async Task<List<UserApiResponseClass1>> GetUserInformation()
        {
            return await _httpClient.GetFromJsonAsync<List<UserApiResponseClass1>>($"users");
        }
    }
}
