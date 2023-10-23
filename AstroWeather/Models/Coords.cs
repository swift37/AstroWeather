using System.Text.Json.Serialization;

namespace MetaWeather.Models
{
    public class Coords
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        public override string ToString()
        {
            return $"{Latitude}, {Longitude}";
        }
    }
}
