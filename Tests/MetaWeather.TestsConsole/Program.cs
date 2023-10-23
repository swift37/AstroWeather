using MetaWeather;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    private static IHost? _Hosting;

    public static IHost Hosting => _Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

    public static IServiceProvider Services => Hosting.Services;

    public static IHostBuilder CreateHostBuilder(string[] args) => Host
        .CreateDefaultBuilder()
        .ConfigureServices(ConfigureServices);

    private static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
        .AddHttpClient<MetaWeatherClient>(client => 
        client.BaseAddress = new Uri(host.Configuration["BaseUri"] 
            ?? throw new InvalidDataException("Base URI not exist.")));

       
    public static async Task Main(string[] args)
    {
        using var host = Hosting;
        await host.StartAsync();

        var client = Services.GetRequiredService<MetaWeatherClient>();

        var geoData = await client.GetGeoData("Warsaw");
        var airPollutionData = await client.GetAirPollutionData(geoData[0]);
        var weatherData = await client.GetWeatherData(geoData[0]);

        await host.StopAsync();
    }
}