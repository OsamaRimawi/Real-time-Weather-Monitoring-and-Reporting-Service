using Moq;
using WeatherMonitoringService.WeatherBots;
using WeatherMonitoringService.WeatherDataModels;

namespace WeatherMonitoringServiceTests.WeatherBotsTests;

[Collection("SequentialConsoleTests")]
public class SunBotTests(ConsoleOutputFixture fixture)
{
    private readonly SunBot _sunBot = new()
    {
        Enabled = true,
        Message = "Wow, it's a scorcher out there!",
        TemperatureThreshold = 30
    };

    private readonly Mock<IWeatherData> _weatherDataMock = new();

    [Fact]
    public void ProcessWeatherData_TemperatureBelowThreshold_DoesNotActivate()
    {
        // Arrange
        _weatherDataMock.Setup(w => w.Temperature).Returns(20);
        fixture.ClearOutput();

        // Act
        _sunBot.ProcessWeatherData(_weatherDataMock.Object);

        // Assert
        var expected = string.Empty;
        Assert.Equal(expected, fixture.GetOutput());
    }

    [Fact]
    public void ProcessWeatherData_TemperatureAboveThreshold_ActivatesSunBot()
    {
        // Arrange
        _weatherDataMock.Setup(w => w.Temperature).Returns(35);
        fixture.ClearOutput();

        // Act
        _sunBot.ProcessWeatherData(_weatherDataMock.Object);

        // Assert
        var expectedOutput = "SunBot activated!\r\nSunBot: Wow, it's a scorcher out there!";
        Assert.Equal(expectedOutput, fixture.GetOutput());
    }
}