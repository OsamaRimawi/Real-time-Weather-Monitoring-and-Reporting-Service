using Moq;
using WeatherMonitoringService.WeatherDataModels;
using WeatherMonitoringService.DataParsers;

namespace WeatherMonitoringServiceTests.DataParsersTests;

public class DataParserTests
{
    [Fact]
    public void Parse_JsonData_ReturnsWeatherData()
    {
        // Arrange
        var jsonData = "{\"Location\":\"City Name\",\"Temperature\":60.0,\"Humidity\":20.0}";
        var mockJsonStrategy = new Mock<IDataParsingStrategy>();
        mockJsonStrategy.Setup(s => s.Parse(jsonData)).Returns(new WeatherData
        {
            Location = "City Name",
            Temperature = 60,
            Humidity = 20
        });
        var parser = new DataParser(mockJsonStrategy.Object);

        // Act
        var result = parser.Parse(jsonData);

        // Assert
        Assert.Equal("City Name", result.Location);
        Assert.Equal(60, result.Temperature);
        Assert.Equal(20, result.Humidity);
    }

    [Fact]
    public void Parse_XmlData_ReturnsWeatherData()
    {
        // Arrange
        var xmlData = "<WeatherData><Location>City Name</Location><Temperature>-20</Temperature><Humidity>30</Humidity></WeatherData>";
        var mockXmlStrategy = new Mock<IDataParsingStrategy>();
        mockXmlStrategy.Setup(s => s.Parse(xmlData)).Returns(new WeatherData
        {
            Location = "City Name",
            Temperature = -20,
            Humidity = 30
        });
        var parser = new DataParser(mockXmlStrategy.Object);

        // Act
        var result = parser.Parse(xmlData);

        // Assert
        Assert.Equal("City Name", result.Location);
        Assert.Equal(-20, result.Temperature);
        Assert.Equal(30, result.Humidity);
    }
}