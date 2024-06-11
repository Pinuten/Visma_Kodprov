using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace VismaSpcs.Recruitment.Rest
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<T>> GetObjects<T>(string parameter)
        {
            string url = "https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/18.0649/lat/59.3326/data.json";
            try
            {
                var response = await _httpClient.GetStringAsync(url);
                var data = JsonSerializer.Deserialize<ApiResponse>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var filteredData = data.TimeSeries
                    .Where(d => d.Parameters.Any(p => p.Name == parameter))
                    .Take(10)
                    .Cast<T>()
                    .ToList();

                return filteredData;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return new List<T>();
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Deserialization error: {e.Message}");
                return new List<T>();
            }
        }
    }

    public class ApiResponse
    {
        public List<WeatherData> TimeSeries { get; set; }
    }

    public class WeatherData
    {
        public string ValidTime { get; set; }
        public List<Parameter> Parameters { get; set; }
    }

    public class Parameter
    {
        public string Name { get; set; }
        public List<double> Values { get; set; }
    }
}
