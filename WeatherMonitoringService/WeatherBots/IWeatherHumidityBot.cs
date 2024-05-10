namespace WeatherMonitoringService.WeatherBots;

public interface IWeatherHumidityBot : IWeatherBot
{
    decimal HumidityThreshold { get; set; }
}