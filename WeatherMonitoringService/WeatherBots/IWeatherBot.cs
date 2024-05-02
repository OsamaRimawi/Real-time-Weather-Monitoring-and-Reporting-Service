using WeatherMonitoringService.WeatherData;

namespace WeatherMonitoringService.WeatherBots;

public interface IWeatherBot
{
    bool Enabled { get; set; }
    string Message { get; set; }
    void ProcessWeatherData(IWeatherData weatherData);
}