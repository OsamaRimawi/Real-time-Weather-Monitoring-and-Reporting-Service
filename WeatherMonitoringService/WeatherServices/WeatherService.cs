using WeatherMonitoringService.Configuration;
using WeatherMonitoringService.DataParsers;
using WeatherMonitoringService.Repositroy;
using WeatherMonitoringService.WeatherDataModels;
using WeatherMonitoringService.WeatherObserver;

namespace WeatherMonitoringService.WeatherServices;

public class WeatherService
{
    private static WeatherPublisher _weatherPublisher;

    private static readonly Dictionary<ParsingStrategy, IDataParsingStrategy> ParsingStrategies =
        new()
        {
            { ParsingStrategy.Json, new JsonParsingStrategy() },
            { ParsingStrategy.Xml, new XmlParsingStrategy() }
        };

    private static WeatherData _weatherData;

    public static void LoadWeatherData()
    {
        Console.WriteLine("********************");
        Console.WriteLine("Loading Weather Data ");
        Console.WriteLine("********************");
        Console.WriteLine("Enter the type of file you want to read:");
        Console.WriteLine("1. JSON");
        Console.WriteLine("2. XML");
        Console.WriteLine("0. Exit");
        var input = Console.ReadLine()?.Trim();

        ParsingStrategy choice;
        switch (input)
        {
            case "1":
                choice = ParsingStrategy.Json;
                break;
            case "2":
                choice = ParsingStrategy.Xml;
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid file type.");
                return;
        }

        var parsingStrategy = ParsingStrategies[choice];
        var userInputFile = InputFileReader.ReadInputFile();
        var dataParser = new DataParser(parsingStrategy);
        _weatherData = dataParser.Parse(userInputFile);
        Console.WriteLine("Weather Data has been loaded Successfully");
        _weatherPublisher.NotifyObservers(_weatherData);
    }

    public static void LoadBotsConfiguration()
    {
        Console.WriteLine("********************");
        Console.WriteLine("Loading Bots Configuration ");
        Console.WriteLine("********************");
        var weatherBots = ConfigurationService.GetBotsFromFile();
        _weatherPublisher = new WeatherPublisher();
        _weatherPublisher.SubscribeBots(weatherBots);
        Console.WriteLine("Bots Configuration has been loaded Successfully");
    }
}