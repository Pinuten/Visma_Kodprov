using System;
using System.Collections.Generic;
using System.Linq;

namespace VismaSpcs.Recruitment.Rest
{
    public class PrettyPrinter
    {
        public void Print(List<WeatherData> weatherData)
        {
            if (weatherData == null || !weatherData.Any())
            {
                Console.WriteLine("No data available.");
                return;
            }

            foreach (var data in weatherData)
            {
                if (data?.Parameters == null) continue;

                var tempParam = data.Parameters.FirstOrDefault(p => p.Name == "t");
                var windParam = data.Parameters.FirstOrDefault(p => p.Name == "ws");

                if (tempParam != null && windParam != null)
                {
                    double temp = tempParam.Values.FirstOrDefault();
                    double windSpeed = windParam.Values.FirstOrDefault();
                    Console.WriteLine($"Time: {data.ValidTime}, Temperature: {temp}°C, Wind Speed: {windSpeed} m/s");
                }
            }
        }
    }
}
