using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MVVMAvalonia.Models.Users
{
    public class Geo
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        [JsonPropertyName("lng")]
        public double Lng { get; set; }
    }
}
