using System.Threading;

namespace WeatherService;

public class WeatherService
{
    public string GetDataSync(bool isSleep)
    {
        if (isSleep)
        {
            Thread.Sleep(10000);
        }
        
        return "{\"coord\":{ \"lon\":10.99,\"lat\":44.34},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"base\":\"stations\",\"main\":{ \"temp\":280.82,\"feels_like\":278.88,\"temp_min\":279.64,\"temp_max\":282.08,\"pressure\":1016,\"humidity\":96,\"sea_level\":1016,\"grnd_level\":929},\"visibility\":2552,\"wind\":{ \"speed\":2.98,\"deg\":33,\"gust\":9.19},\"rain\":{ \"1h\":0.49},\"clouds\":{ \"all\":100},\"dt\":1709135773,\"sys\":{ \"type\":2,\"id\":2004688,\"country\":\"IT\",\"sunrise\":1709099789,\"sunset\":1709139677},\"timezone\":3600,\"id\":3163858,\"name\":\"Zocca\",\"cod\":200}";
    }
}