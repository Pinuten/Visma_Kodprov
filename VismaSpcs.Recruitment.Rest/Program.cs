using System;
using System.Net.Http;
using System.Threading.Tasks;
using VismaSpcs.Recruitment.Rest;

public class Program
{
    public static async Task Main(string[] args)
    {
        using (var httpClient = new HttpClient())
        {
            var apiClient = new ApiClient(httpClient);
            var prettyPrinter = new PrettyPrinter();

            Console.WriteLine("Enter the parameter to filter by (e.g., 't' for temperature, 'ws' for wind speed):");
            string parameter = Console.ReadLine();

            var data = await apiClient.GetObjects<WeatherData>(parameter);
            prettyPrinter.Print(data);
        }
    }
}
