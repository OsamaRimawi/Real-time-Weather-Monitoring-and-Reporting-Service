using Newtonsoft.Json;
using WeatherMonitoringService.WeatherDataModels;

namespace WeatherMonitoringService.DataParsers;

public class JsonParsingStrategy : IDataParsingStrategy
{
    public WeatherData Parse(string data)
    {
        return JsonConvert.DeserializeObject<WeatherData>(data);
    }
}