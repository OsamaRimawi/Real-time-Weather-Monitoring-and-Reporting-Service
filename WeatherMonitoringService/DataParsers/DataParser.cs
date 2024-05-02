
using WeatherMonitoringService.WeatherDataModels;

namespace WeatherMonitoringService.DataParsers;

public class DataParser
{
    private IDataParsingStrategy _strategy;
    
    public DataParser(IDataParsingStrategy strategy)
    {
        _strategy = strategy;
    }

    public WeatherData Parse(string data)
    {
        return _strategy.Parse(data);
    }

}