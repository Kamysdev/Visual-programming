using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace lab7.Models.UserModels
{
    internal class UserApiResponse
    {
        [JsonPropertyName("property1")]
        public UserApiResponseClass1[] Property1 { get; set; }
    }
}

public class UserApiResponseClass1
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("address")]
    public UserApiResponseAddress Address { get; set; }
    [JsonPropertyName("phone")]
    public string Phone { get; set; }
    [JsonPropertyName("website")]
    public string Website { get; set; }
    [JsonPropertyName("company")]
    public UserApiResponseCompany Company { get; set; }
}

public class UserApiResponseAddress
{
    [JsonPropertyName("street")]
    public string Street { get; set; }
    [JsonPropertyName("suite")]
    public string Suite { get; set; }
    [JsonPropertyName("city")]
    public string City { get; set; }
    [JsonPropertyName("zipcode")]
    public string Zipcode { get; set; }
    [JsonPropertyName("geo")]
    public UserApiResponseGeo Geo { get; set; }
}

public class UserApiResponseGeo
{
    [JsonPropertyName("lat")]
    public string Lat { get; set; }
    [JsonPropertyName("lng")]
    public string Lng { get; set; }
}

public class UserApiResponseCompany
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("catchPhrase")]
    public string CatchPhrase { get; set; }
    [JsonPropertyName("bs")]
    public string Bs { get; set; }
}
