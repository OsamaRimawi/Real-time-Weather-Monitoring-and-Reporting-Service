using Moq;
using WeatherMonitoringService.WeatherBots;
using WeatherMonitoringService.WeatherDataModels;

namespace WeatherMonitoringServiceTests.WeatherBotsTests;

[Collection("SequentialConsoleTests")]
public class SnowBotTests(ConsoleOutputFixture fixture)
{
    private readonly SnowBot _snowBot = new()
    {
        Enabled = true,
        Message = "Brrr, it's getting chilly!",
        TemperatureThreshold = 0
    };

    private readonly Mock<IWeatherData> _weatherDataMock = new();

    [Fact]
    public void ProcessWeatherData_TemperatureAboveThreshold_DoesNotActivate()
    {
        // Arrange
        _weatherDataMock.Setup(w => w.Temperature).Returns(5);
        fixture.ClearOutput();

        // Act
        _snowBot.ProcessWeatherData(_weatherDataMock.Object);

        // Assert
        var expected = string.Empty;
        Assert.Equal(expected, fixture.GetOutput());
    }

    [Fact]
    public void ProcessWeatherData_TemperatureBelowThreshold_ActivatesSnowBot()
    {
        // Arrange
        _weatherDataMock.Setup(w => w.Temperature).Returns(-5);
        fixture.ClearOutput();

        // Act
        _snowBot.ProcessWeatherData(_weatherDataMock.Object);

        // Assert
        var expectedOutput = "SnowBot activated!\r\nSnowBot: Brrr, it's getting chilly!";
        Assert.Equal(expectedOutput, fixture.GetOutput());
    }
}