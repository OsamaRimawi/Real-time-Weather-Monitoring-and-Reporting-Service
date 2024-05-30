using WeatherMonitoringService.DataParsers;

namespace WeatherMonitoringServiceTests.DataParsersTests;

public class XmlParsingStrategyTests
{
    [Fact]
    public void Parse_ValidXmlData_ReturnsWeatherData()
    {
        // Arrange
        var xmlData = "<WeatherData><Location>City Name</Location><Temperature>-20</Temperature><Humidity>30</Humidity></WeatherData>";
        var strategy = new XmlParsingStrategy();

        // Act
        var result = strategy.Parse(xmlData);

        // Assert
        Assert.Equal("City Name", result.Location);
        Assert.Equal(-20, result.Temperature);
        Assert.Equal(30, result.Humidity);
    }
}