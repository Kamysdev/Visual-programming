using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weater_Application.ViewModels;

public partial class MainViewModel
{
    public string HeaderFontColor 
    {
        get => _HeaderFontColor;
        set { _HeaderFontColor = value; OnPropertyChanged(nameof(HeaderFontColor)); }
    }
    public string _HeaderFontColor { get; set; }

    public string MainBackground 
    {
        get => _MainBackground;
        set { _MainBackground = value; OnPropertyChanged(nameof(MainBackground)); }
    }
    public string _MainBackground { get; set; }

    public string SecondBackground 
    {
        get => _SecondBackground;
        set { _SecondBackground = value; OnPropertyChanged(nameof(SecondBackground)); }
    }
    public string _SecondBackground { get; set; }


    public void SetTheme()
    {
        HeaderFontColor = "White";
        MainBackground = "#3C3C3C";
        SecondBackground = "#1F1F1F";
        int tempString = DateTime.Now.ToString().Remove(0, 11).Remove(4).LastIndexOf(':');
        if (Convert.ToInt32(DateTime.Now.ToString().Remove(0, 11).Substring(0, tempString)) > 7 &&
            Convert.ToInt32(DateTime.Now.ToString().Remove(0, 11).Substring(0, tempString)) < 17)
        {
            HeaderFontColor = "#708DF4";
            MainBackground = "White";
            SecondBackground = "#708DF4";
        }
    }
}
