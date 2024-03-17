using System.Threading.Tasks;
using System;
using UsersTables.ViewModels.Services;

namespace UsersTables.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly UserApiService _userApiService;

    public MainViewModel()
    {
        _userApiService = new UserApiService();

        FetchUserInformation();
    }

    private async Task FetchUserInformation()
    {
        var weatherApiResponse = await _userApiService.GetUserInformation();
        if (weatherApiResponse != null)
        {
            for (int i = 0; i < 40; i++)
            {

            }
        }
    }
}
