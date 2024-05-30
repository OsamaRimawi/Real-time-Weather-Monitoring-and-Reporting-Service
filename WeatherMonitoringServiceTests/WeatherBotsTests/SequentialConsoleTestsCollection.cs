namespace WeatherMonitoringServiceTests.WeatherBotsTests;

[CollectionDefinition("SequentialConsoleTests", DisableParallelization = true)]
public class SequentialConsoleTestsCollection : ICollectionFixture<ConsoleOutputFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}