using WeatherMonitoringService.WeatherData;

namespace WeatherMonitoringService.WeatherBots;

public class SnowBot : IWeatherTemperatureBot
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public decimal TemperatureThreshold { get; set; }
    
    public void ProcessWeatherData(IWeatherData weatherData)
    {
        throw new NotImplementedException();
    }
}