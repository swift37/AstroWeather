using System.Text.Json.Serialization;

namespace MetaWeather.Models
{
    public class GeoData : Coords
    {
        [JsonPropertyName("name")]
        public string? City { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        public override string ToString()
        {
            return $"[{Country}] {City}: {Latitude}, {Longitude}";
        }
    }
}
