using MetaWeather.Models;
using System.Text.Json.Serialization;

public class AirPollutionData
{
    [JsonPropertyName("coord")]
    public Coords? Coords { get; set; }

    [JsonPropertyName("list")]
    public Data[]? Data { get; set; }
}

public class Data
{
    [JsonPropertyName("main")]
    public Details? Details { get; set; }

    [JsonPropertyName("components")]
    public Components? Components { get; set; }

    [JsonPropertyName("dt")]
    public int DateTimeUnix { get; set; }
}

public class Details
{
    [JsonPropertyName("aqi")]
    public int AirQualityIndex { get; set; }
}

public class Components
{
    [JsonPropertyName("co")]
    public double CO { get; set; }

    [JsonPropertyName("no")]
    public double NO { get; set; }

    [JsonPropertyName("no2")]
    public double NO2 { get; set; }

    [JsonPropertyName("o3")]
    public double O3 { get; set; }

    [JsonPropertyName("so2")]
    public double SO2 { get; set; }

    [JsonPropertyName("pm2_5")]
    public double PM2_5 { get; set; }

    [JsonPropertyName("pm10")]
    public double PM10 { get; set; }

    [JsonPropertyName("nh3")]
    public double NH3 { get; set; }
}
