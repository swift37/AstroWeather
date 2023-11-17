using AstroWeather;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;

class Program
{
    private static IHost? _Hosting;

    public static IHost Hosting => _Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

    public static IServiceProvider Services => Hosting.Services;

    public static IHostBuilder CreateHostBuilder(string[] args) => Host
        .CreateDefaultBuilder()
        .ConfigureServices(ConfigureServices);

    private static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
        .AddHttpClient<AstroWeatherClient>(client => 
        client.BaseAddress = new Uri(host.Configuration["BaseUri"] 
            ?? throw new InvalidDataException("Base URI not exist.")))
        .SetHandlerLifetime(TimeSpan.FromMinutes(5))
        .AddPolicyHandler(GetRetryPolicy());

    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        var jitter = new Random();
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(10, retryAttempt => 
                TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) + 
                TimeSpan.FromMilliseconds(jitter.Next(0, 1000)));
    }
       
    public static async Task Main(string[] args)
    {
        using var host = Hosting;
        await host.StartAsync();

        var client = Services.GetRequiredService<AstroWeatherClient>();

        var geoData = await client.GetGeoData("Warsaw");
        if (geoData is null) throw new NullReferenceException(nameof(geoData));

        var airPollutionData = await client.GetAirPollutionData(geoData[0]);
        var weatherData = await client.GetCurrentWeatherData(geoData[0]);

        await host.StopAsync();
    }
}