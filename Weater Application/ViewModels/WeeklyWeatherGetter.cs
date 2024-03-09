using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weater_Application.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private void SetWeeklyWeather()
        {
            for (int i = 0; i < 40; i++)
            {
                if (WeatherList[i].Time == "4:00")
                {
                    NightTemperature(i); break;
                }
                if (WeatherList[i].Time == "16:00")
                {
                    DayTemperature(i); break;
                }
            }
        }

        private void NightTemperature(int i)
        {
            WeeklyUserWeather tempWeather;
            DateTime date = DateTime.Now;

            for (; i < 40; i++)
            {
                tempWeather = new WeeklyUserWeather("", "", "", "", "", 500, "", "");
                tempWeather.SecondTemperature = WeatherList[i].Temperature;
                while (WeatherList[i].Time != "16:00" && i < 40)
                {
                    i++;
                }
                tempWeather.Temperature = WeatherList[i].Temperature;
                tempWeather.DayTime = date.DayOfWeek.ToString() + ", " + date.Day.ToString();
                tempWeather.Time = WeatherList[i].Time;

                date = date.AddDays(1);

                tempWeather.WeatherID = WeatherList[i].WeatherID;
                WeeklyWeatherList.Add(tempWeather);
            }
        }

        private void DayTemperature(int i)
        {
            WeeklyUserWeather tempWeather;
            DateTime date = DateTime.Now.AddDays(1);

            for (; i < 40; i++)
            {
                tempWeather = new WeeklyUserWeather("", "", "", "", "", 500, "", "");
                tempWeather.SecondTemperature = WeatherList[i].Temperature;
                tempWeather.Time = WeatherList[i].Time;
                while (WeatherList[i].Time != "16:00" && i < 40)
                {
                    i++;
                }
                tempWeather.Temperature = WeatherList[i].Temperature;
                tempWeather.DayTime = date.DayOfWeek.ToString() + ", " + date.Day.ToString();

                date = date.AddDays(1);

                tempWeather.WeatherID = WeatherList[i].WeatherID;
                WeeklyWeatherList.Add(tempWeather);
            }
        }
    }
}