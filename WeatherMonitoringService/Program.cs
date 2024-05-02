using WeatherMonitoringService.WeatherServices;

Console.WriteLine("************     Weather Monitoring Service      ************");
WeatherService.LoadBotsConfiguration();

while (true)
{
    Console.WriteLine("********************");
    Console.WriteLine("* Select an action *");
    Console.WriteLine("********************");
    Console.WriteLine("1. Load weather data");
    Console.WriteLine("2. Reload bots configuration");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your choice: ");
    var userSelection = Console.ReadLine();

    switch (userSelection)
    {
        case "1":
            WeatherService.LoadWeatherData();
            break;
        case "2":
            WeatherService.LoadBotsConfiguration();
            break;
        case "0":
            Console.WriteLine("Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}