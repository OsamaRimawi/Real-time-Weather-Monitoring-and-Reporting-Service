using Newtonsoft.Json;
using WeatherMonitoringService.Configuration;
using WeatherMonitoringService.WeatherBots;

namespace WeatherMonitoringServiceTests.ConfigurationTests;

public class ConfigurationServiceTests
{
    [Fact]
    public void ConvertStringToBots_ValidJsonString_ReturnsListOfWeatherBots()
    {
        // Arrange
        var jsonString = "{\"RainBot\": {\"Enabled\": true,\"HumidityThreshold\": 70,\"Message\":" +
                         " \"It looks like it's about to pour down!\"},\"SunBot\": {\"Enabled\":" +
                         " true,\"TemperatureThreshold\": 30,\"Message\": \"Wow, it's a scorcher out there!\"}}";

        var expectedRainBot = new RainBot
        {
            Enabled = true,
            HumidityThreshold = 70,
            Message = "It looks like it's about to pour down!"
        };

        var expectedSunBot = new SunBot
        {
            Enabled = true,
            TemperatureThreshold = 30,
            Message = "Wow, it's a scorcher out there!"
        };

        // Act
        var result = ConfigurationService.ConvertStringToBots(jsonString);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        // Assert RainBot
        var rainBot = result.Find(bot => bot.GetType() == typeof(RainBot));
        Assert.NotNull(rainBot);
        Assert.Equal(expectedRainBot.Enabled, ((RainBot)rainBot).Enabled);
        Assert.Equal(expectedRainBot.HumidityThreshold, ((RainBot)rainBot).HumidityThreshold);
        Assert.Equal(expectedRainBot.Message, ((RainBot)rainBot).Message);

        // Assert SunBot
        var sunBot = result.Find(bot => bot.GetType() == typeof(SunBot));
        Assert.NotNull(sunBot);
        Assert.Equal(expectedSunBot.Enabled, ((SunBot)sunBot).Enabled);
        Assert.Equal(expectedSunBot.TemperatureThreshold, ((SunBot)sunBot).TemperatureThreshold);
        Assert.Equal(expectedSunBot.Message, ((SunBot)sunBot).Message);
    }

    [Fact]
    public void ConvertStringToBots_InvalidJsonString_ThrowsJsonException()
    {
        // Arrange
        var invalidJsonString = "Invalid JSON string";

        // Act & Assert
        Assert.Throws<JsonReaderException>(() => ConfigurationService.ConvertStringToBots(invalidJsonString));
    }

    [Fact]
    public void ConvertStringToBots_NullInput_ThrowsArgumentNullException()
    {
        // Arrange
        string nullString = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => ConfigurationService.ConvertStringToBots(nullString));
    }
}