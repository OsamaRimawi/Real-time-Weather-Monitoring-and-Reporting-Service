namespace WeatherMonitoringService.Configuration;

public class BotConfigs
{
    public bool Enabled { get; set; }
    public decimal HumidityThreshold { get; set; }
    public decimal TemperatureThreshold { get; set; }
    public string Message { get; set; }
}