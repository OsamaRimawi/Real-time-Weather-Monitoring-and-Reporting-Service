using WeatherMonitoringService.WeatherDataModels;
using WeatherMonitoringService.WeatherObserver;

namespace WeatherMonitoringService.WeatherBots;

public class RainBot : IWeatherHumidityBot, IWeatherObserver
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public decimal HumidityThreshold { get; set; }

    public void ProcessWeatherData(IWeatherData weatherData)
    {
        if (weatherData.Humidity <= HumidityThreshold) return;
        Console.WriteLine("RainBot activated!");
        Console.WriteLine("RainBot: " + Message);
    }
}