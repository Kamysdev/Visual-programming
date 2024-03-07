using System.Threading;
using System.Text.Json;

namespace Weater_Application.ViewModels;

public class MainViewModel : BaseViewModel
{
    public string CurrentDay
    {
        get => _CurrentDay;
        set { _CurrentDay = value; OnPropertyChanged(nameof(CurrentDay)); }
    }

    public string _CurrentDay { get; set; }

    public string CurrentTemp { get; set; }


    public MainViewModel()
    {
        SetCurrentTime();
        CurrentTemp = "-27";
    }

    private void SetCurrentTime()
    {
        CurrentDay = System.DateTime.Now.DayOfWeek.ToString() + ", " + System.DateTime.Now.Day.ToString();
    }

    public void CreateAPICall()
    {

    }
}
