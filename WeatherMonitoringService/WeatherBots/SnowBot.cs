using WeatherMonitoringService.WeatherDataModels;
using WeatherMonitoringService.WeatherObserver;

namespace WeatherMonitoringService.WeatherBots;

public class SnowBot : IWeatherTemperatureBot, IWeatherObserver
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public decimal TemperatureThreshold { get; set; }

    public void ProcessWeatherData(IWeatherData weatherData)
    {
        if (weatherData.Temperature >= TemperatureThreshold) return;
        Console.WriteLine("SnowBot activated!");
        Console.WriteLine("SnowBot: " + Message);
    }
}