using WeatherMonitoringService.WeatherData;

namespace WeatherMonitoringService.WeatherBots;

public class RainBot : IWeatherHumidityBot
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public decimal HumidityThreshold { get; set; }
    
    public void ProcessWeatherData(IWeatherData weatherData)
    {
        throw new NotImplementedException();
    }
}