using WeatherMonitoringService.WeatherDataModels;
using WeatherMonitoringService.WeatherObserver;

namespace WeatherMonitoringService.WeatherBots;

public class SunBot : IWeatherTemperatureBot, IWeatherObserver
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public decimal TemperatureThreshold { get; set; }

    public void ProcessWeatherData(IWeatherData weatherData)
    {
        if (weatherData.Temperature <= TemperatureThreshold) return;
        Console.WriteLine("SunBot activated!");
        Console.WriteLine("SunBot: " + Message);
    }
}