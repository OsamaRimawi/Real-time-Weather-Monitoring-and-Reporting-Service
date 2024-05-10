namespace WeatherMonitoringService.WeatherBots;

public interface IWeatherBot
{
    bool Enabled { get; set; }
    string Message { get; set; }
}