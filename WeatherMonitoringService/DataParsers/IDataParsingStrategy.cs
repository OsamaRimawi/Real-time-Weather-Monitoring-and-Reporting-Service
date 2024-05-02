using WeatherMonitoringService.WeatherDataModels;

namespace WeatherMonitoringService.DataParsers;

public interface IDataParsingStrategy
{
    WeatherData Parse(string data);
}