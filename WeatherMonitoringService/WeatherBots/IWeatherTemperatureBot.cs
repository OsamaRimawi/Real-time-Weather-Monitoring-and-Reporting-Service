namespace WeatherMonitoringService.WeatherBots;

public interface IWeatherTemperatureBot : IWeatherBot
{
    decimal TemperatureThreshold { get; set; }
}