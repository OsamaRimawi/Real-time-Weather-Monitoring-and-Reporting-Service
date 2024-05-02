using WeatherMonitoringService.WeatherDataModels;

namespace WeatherMonitoringService.WeatherBots;

public class SunBot : IWeatherTemperatureBot
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public decimal TemperatureThreshold { get; set; }
    
    public void ProcessWeatherData(IWeatherData weatherData)
    {
        if (weatherData.Temperature > TemperatureThreshold)
        {
            Console.WriteLine("SunBot activated!");
            Console.WriteLine("SunBot: " + Message);
        }
    }
}