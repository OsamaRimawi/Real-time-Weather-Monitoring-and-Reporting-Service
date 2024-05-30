using WeatherMonitoringService.DataParsers;

namespace WeatherMonitoringServiceTests.DataParsersTests;

public class JsonParsingStrategyTests
{
    [Fact]
    public void Parse_ValidJsonData_ReturnsWeatherData()
    {
        // Arrange
        var jsonData = "{\"Location\":\"City Name\",\"Temperature\":60.0,\"Humidity\":20.0}";
        var strategy = new JsonParsingStrategy();

        // Act
        var result = strategy.Parse(jsonData);

        // Assert
        Assert.Equal("City Name", result.Location);
        Assert.Equal(60, result.Temperature);
        Assert.Equal(20, result.Humidity);
    }
}