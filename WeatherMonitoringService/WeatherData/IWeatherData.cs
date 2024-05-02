namespace WeatherMonitoringService.WeatherData;

public interface IWeatherData
{
    string Location { get; set; }
    double Temperature { get; set; }
    double Humidity { get; set; }
}