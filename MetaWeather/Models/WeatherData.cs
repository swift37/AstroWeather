using System.Text.Json.Serialization;

namespace MetaWeather.Models
{

    public class WeatherData
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("coord")]
        public Coords? Coords { get; set; }

        [JsonPropertyName("weather")]
        public Weather[]? Weather { get; set; }

        [JsonPropertyName("base")]
        public string? Base { get; set; }

        [JsonPropertyName("main")]
        public Details? Details { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind? Wind { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds? Clouds { get; set; }

        [JsonPropertyName("rain")]
        public Rain? Rain { get; set; }

        [JsonPropertyName("snow")]
        public Snow? Snow { get; set; }

        [JsonPropertyName("dt")]
        public int DateTimeUnix { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("sys")]
        public Systemic? Systemic { get; set; }

        [JsonPropertyName("cod")]
        public int ResponseCode { get; set; }
    }

    public class Details
    {
        [JsonPropertyName("temp")]
        public float Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public float TemperatureFeels { get; set; }

        [JsonPropertyName("temp_min")]
        public float MinTemperature { get; set; }

        [JsonPropertyName("temp_max")]
        public float MaxTemperature { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public int SeaLevel { get; set; }

        [JsonPropertyName("grnd_level")]
        public int GroundLevel { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string? State { get; set; }

        [JsonPropertyName("description")]
        public string? DetailedState { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public double Direction { get; set; }

        [JsonPropertyName("gust")]
        public double Gust { get; set; }
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public int Cloudiness { get; set; }
    }

    public class Rain
    {
        [JsonPropertyName("1h")]
        public int VolumeFor1Hour { get; set; }

        [JsonPropertyName("3h")]
        public int VolumeFor3Hours { get; set; }
    }

    public class Snow
    {
        [JsonPropertyName("1h")]
        public int VolumeFor1Hour { get; set; }

        [JsonPropertyName("3h")]
        public int VolumeFor3Hours { get; set; }
    }

    public class Systemic
    {
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
    }

}
