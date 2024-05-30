using Moq;
using WeatherMonitoringService.WeatherBots;
using WeatherMonitoringService.WeatherDataModels;
using WeatherMonitoringService.WeatherObserver;

namespace WeatherMonitoringServiceTests.WeatherObserverTests;

public class WeatherPublisherTests
{
    [Fact]
    public void SubscribeBots_AddsOnlyEnabledBotsAsObservers()
    {
        // Arrange
        var publisher = new WeatherPublisher();

        var enabledBot = new RainBot() { Enabled = true };

        var disabledBot = new SunBot() { Enabled = false };

        var bots = new List<IWeatherBot> { enabledBot, disabledBot };

        // Act
        publisher.SubscribeBots(bots);

        var observersField = typeof(WeatherPublisher)
            .GetField("_observers", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var observers = observersField?.GetValue(publisher) as List<IWeatherObserver>;

        // Assert
        Assert.Single(observers!);
        Assert.Contains(enabledBot, observers!);
        Assert.DoesNotContain(disabledBot, observers!);
    }

    [Fact]
    public void NotifyObservers_NotifiesAllSubscribedObservers()
    {
        // Arrange
        var publisher = new WeatherPublisher();
        var weatherData = new WeatherData { Temperature = 25, Humidity = 50 };

        var observerMock1 = new Mock<IWeatherObserver>();
        var observerMock2 = new Mock<IWeatherObserver>();

        var observersField = typeof(WeatherPublisher).GetField("_observers",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var observers = observersField!.GetValue(publisher) as List<IWeatherObserver>;

        observers!.Add(observerMock1.Object);
        observers.Add(observerMock2.Object);

        // Act
        publisher.NotifyObservers(weatherData);

        // Assert
        observerMock1.Verify(o => o.ProcessWeatherData(weatherData), Times.Once);
        observerMock2.Verify(o => o.ProcessWeatherData(weatherData), Times.Once);
    }
}