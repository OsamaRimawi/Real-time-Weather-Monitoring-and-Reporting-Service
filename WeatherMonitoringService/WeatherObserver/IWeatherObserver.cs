using WeatherMonitoringService.WeatherDataModels;

namespace WeatherMonitoringService.WeatherObserver;

public interface IWeatherObserver
{
    void ProcessWeatherData(IWeatherData weatherData);
}