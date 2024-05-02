using Newtonsoft.Json;
using WeatherMonitoringService.WeatherBots;

namespace WeatherMonitoringService.Configuration;

public class ConfigurationService
{
    public static List<IWeatherBot> GetBotsFromFile()
    {
        var json = ReadFileFromUserInput();
        var weatherBotsConfigs = JsonConvert.DeserializeObject<Dictionary<string, BotConfigs>>(json);

        if (weatherBotsConfigs == null) return null!;

        return weatherBotsConfigs.Select(singleBotConfigData =>
            CreateBotInstance(singleBotConfigData.Key, singleBotConfigData.Value)).ToList();
    }


    private static string ReadFileFromUserInput()
    {
        Console.WriteLine("Enter the Bots Configuration file path:");
        var filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The specified file does not exist.");
        }

        return File.ReadAllText(filePath);
    }

    private static IWeatherBot CreateBotInstance(string botType, BotConfigs config)
    {
        switch (botType)
        {
            case "RainBot":
                return new RainBot()
                {
                    Enabled = config.Enabled,
                    HumidityThreshold = config.HumidityThreshold,
                    Message = config.Message
                };
            case "SunBot":
                return new SunBot()
                {
                    Enabled = config.Enabled,
                    TemperatureThreshold = config.TemperatureThreshold,
                    Message = config.Message
                };
            case "SnowBot":
                return new SnowBot()
                {
                    Enabled = config.Enabled,
                    TemperatureThreshold = config.TemperatureThreshold,
                    Message = config.Message
                };
            default:
                Console.WriteLine($"Unknown bot type: {botType}");
                return null!;
        }
    }
}