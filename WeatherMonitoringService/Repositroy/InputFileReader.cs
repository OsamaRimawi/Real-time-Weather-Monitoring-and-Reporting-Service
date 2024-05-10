namespace WeatherMonitoringService.Repositroy;

public class InputFileReader
{
    public static string ReadInputFile()
    {
        Console.WriteLine("Enter the file path:");
        var filePath = Console.ReadLine();
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The specified file does not exist.");
        }

        var data = File.ReadAllText(filePath);
        return data;
    }
}