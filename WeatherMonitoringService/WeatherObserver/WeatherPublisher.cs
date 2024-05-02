using WeatherMonitoringService.WeatherBots;
using WeatherMonitoringService.WeatherDataModels;

namespace WeatherMonitoringService.WeatherObserver;

public class WeatherPublisher
{
    private readonly List<IWeatherObserver> _observers = [];

    private void AddObserver(IWeatherObserver observer)
    {
        _observers.Add(observer);
    }

    public void NotifyObservers(WeatherData data)
    {
        _observers.ForEach(observer => observer.ProcessWeatherData(data));
    }

    public void SubscribeBots(List<IWeatherBot> weatherBots)
    {
        foreach (var bot in weatherBots.Where(bot => bot.Enabled))
        {
            AddObserver((IWeatherObserver)bot);
        }
    }
}