﻿using MetaWeather.Models;
using System.Net.Http.Json;

namespace MetaWeather
{
    public class MetaWeatherClient
    {
        private readonly HttpClient _client;

        public MetaWeatherClient(HttpClient client) => _client = client;

        public async Task<WeatherCoords[]?> GetCoordsByName(string? name, int limit = 1, CancellationToken cancellation = default)
        {
            if (name is null) throw new ArgumentNullException("A city name is required.");

            return await _client
                .GetFromJsonAsync<WeatherCoords[]>($"/geo/1.0/direct?q={name}&limit={limit}&appid=d2c347f9dafa3c3b80573318acdeab99")
                .ConfigureAwait(false);
        }
    }
}