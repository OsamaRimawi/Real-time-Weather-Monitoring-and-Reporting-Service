using WeatherMonitoringService.WeatherDataModels;

namespace WeatherMonitoringService.WeatherBots;

public class RainBot : IWeatherHumidityBot
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public decimal HumidityThreshold { get; set; }
    
    public void ProcessWeatherData(IWeatherData weatherData)
    {
        if (weatherData.Temperature > HumidityThreshold)
        {
            Console.WriteLine("RainBot activated!");
            Console.WriteLine("RainBot: " + Message);
        }    
    }
}