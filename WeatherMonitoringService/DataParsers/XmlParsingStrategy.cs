using System.Xml.Linq;
using WeatherMonitoringService.WeatherDataModels;

namespace WeatherMonitoringService.DataParsers;

public class XmlParsingStrategy : IDataParsingStrategy
{
    public WeatherData Parse(string data)
    {
        var doc = XDocument.Parse(data);
        var location = doc.Element("WeatherData")!.Element("Location")!.Value;
        var temperature = decimal.Parse(doc.Element("WeatherData")!.Element("Temperature")!.Value);
        var humidity = decimal.Parse(doc.Element("WeatherData")!.Element("Humidity")!.Value);
        return new WeatherData { Location = location, Temperature = temperature, Humidity = humidity };
    }
}