using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weater_Application.ViewModels.ApiModels;

internal class WeatherApiResponse
{
    [JsonPropertyName("cod")]
    public string Cod { get; set; }
    [JsonPropertyName("message")]
    public int Message { get; set; }
    [JsonPropertyName("cnt")]
    public int Cnt { get; set; }
    [JsonPropertyName("list")]
    public WeatherApiResponseList[] List { get; set; }
    [JsonPropertyName("city")]
    public WeatherApiResponseCity City { get; set; }
}

public class WeatherApiResponseCity
{
    public int id { get; set; }
    public string name { get; set; }
    public Coord coord { get; set; }
    public string country { get; set; }
    public int population { get; set; }
    public int timezone { get; set; }
    public int sunrise { get; set; }
    public int sunset { get; set; }
}

public class Coord
{
    public float lat { get; set; }
    public float lon { get; set; }
}

public class WeatherApiResponseList
{
    public int dt { get; set; }
    public Main main { get; set; }
    public Weather[] weather { get; set; }
    public Clouds clouds { get; set; }
    public Wind wind { get; set; }
    public int visibility { get; set; }
    public float pop { get; set; }
    public Snow snow { get; set; }
    public Sys sys { get; set; }
    public string dt_txt { get; set; }
    public Rain rain { get; set; }
}

public class Main
{
    public float temp { get; set; }
    public float feels_like { get; set; }
    public float temp_min { get; set; }
    public float temp_max { get; set; }
    public int pressure { get; set; }
    public int sea_level { get; set; }
    public int grnd_level { get; set; }
    public int humidity { get; set; }
    public float temp_kf { get; set; }
}

public class Clouds
{
    public int all { get; set; }
}

public class Wind
{
    public float speed { get; set; }
    public int deg { get; set; }
    public float gust { get; set; }
}

public class Snow
{
    public float _3h { get; set; }
}

public class Sys
{
    public string pod { get; set; }
}

public class Rain
{
    public float _3h { get; set; }
}

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
}
