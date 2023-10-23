using System.Text.Json.Serialization;

namespace MetaWeather.Models
{
    public class WeatherCoords
    {
        [JsonPropertyName("name")]
        public string? City { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }
    }
}
