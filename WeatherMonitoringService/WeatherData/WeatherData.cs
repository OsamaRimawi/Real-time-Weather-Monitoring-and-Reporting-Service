namespace WeatherMonitoringService.WeatherData;

public class WeatherData : IWeatherData
{
    public string Location { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
}