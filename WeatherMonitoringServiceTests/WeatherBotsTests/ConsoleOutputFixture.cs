// This class used to run tests sequentially to ensure isolation from the console which is a shared resource

namespace WeatherMonitoringServiceTests.WeatherBotsTests;

public abstract class ConsoleOutputFixture : IDisposable
{
    private readonly StringWriter _stringWriter;
    private readonly TextWriter _originalOutput;

    protected ConsoleOutputFixture()
    {
        _stringWriter = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_stringWriter);
    }

    public string GetOutput() => _stringWriter.ToString().Trim();

    public void ClearOutput() => _stringWriter.GetStringBuilder().Clear();

    public void Dispose()
    {
        Console.SetOut(_originalOutput);
        _stringWriter.Dispose();
    }
}