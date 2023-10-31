using MetaWeather.Models;
using System.Net.Http.Json;

namespace MetaWeather
{
    public class AstroWeatherClient
    {
        private readonly HttpClient _client;

        public AstroWeatherClient(HttpClient client) => _client = client;

        public async Task<GeoData[]?> GetGeoData(string? cityName, int limit = 1, CancellationToken cancellation = default)
        {
            if (cityName is null) throw new ArgumentNullException("A city name is required.");

            return await _client
                .GetFromJsonAsync<GeoData[]>($"/geo/1.0/direct?q={cityName}&limit={limit}&appid=d2c347f9dafa3c3b80573318acdeab99")
                .ConfigureAwait(false);
        }

        public async Task<AirPollutionData?> GetAirPollutionData(double latitude, double longitude, CancellationToken cancellation = default)
        {
            return await _client
                .GetFromJsonAsync<AirPollutionData>($"/data/2.5/air_pollution?lat={latitude}&lon={longitude}&appid=d2c347f9dafa3c3b80573318acdeab99")
                .ConfigureAwait(false);
        }

        public async Task<AirPollutionData?> GetAirPollutionData(GeoData? geoData, CancellationToken cancellation = default)
        {
            if (geoData is null) throw new ArgumentNullException("Geo data is required.");

            return await GetAirPollutionData(geoData.Latitude, geoData.Longitude, cancellation);
        }

        public async Task<WeatherData?> GetCurrentWeatherData(double latitude, double longitude, CancellationToken cancellation = default)
        {
            return await _client
                .GetFromJsonAsync<WeatherData>($"/data/2.5/weather?lat={latitude}&lon={longitude}&appid=d2c347f9dafa3c3b80573318acdeab99")
                .ConfigureAwait(false);
        }

        public async Task<WeatherData?> GetCurrentWeatherData(GeoData? geoData, CancellationToken cancellation = default)
        {
            if (geoData is null) throw new ArgumentNullException("Geo data is required.");

            return await GetCurrentWeatherData(geoData.Latitude, geoData.Longitude, cancellation);
        }
        
    }
}
