using Moq;
using WeatherMonitoringService.WeatherBots;
using WeatherMonitoringService.WeatherDataModels;

namespace WeatherMonitoringServiceTests.WeatherBotsTests;

[Collection("SequentialConsoleTests")]
public class RainBotTests(ConsoleOutputFixture fixture)
{
    private readonly RainBot _rainBot = new()
    {
        Enabled = true,
        Message = "It looks like it's about to pour down!",
        HumidityThreshold = 70
    };

    private readonly Mock<IWeatherData> _weatherDataMock = new();

    [Fact]
    public void ProcessWeatherData_HumidityBelowThreshold_DoesNotActivate()
    {
        // Arrange
        _weatherDataMock.Setup(w => w.Humidity).Returns(60);
        fixture.ClearOutput();

        // Act
        _rainBot.ProcessWeatherData(_weatherDataMock.Object);

        // Assert
        var expected = string.Empty;
        Assert.Equal(expected, fixture.GetOutput());
    }

    [Fact]
    public void ProcessWeatherData_HumidityAboveThreshold_ActivatesRainBot()
    {
        // Arrange
        _weatherDataMock.Setup(w => w.Humidity).Returns(90);
        fixture.ClearOutput();

        // Act
        _rainBot.ProcessWeatherData(_weatherDataMock.Object);

        // Assert
        var expectedOutput = "RainBot activated!\r\nRainBot: It looks like it's about to pour down!";
        Assert.Equal(expectedOutput, fixture.GetOutput());
    }
}