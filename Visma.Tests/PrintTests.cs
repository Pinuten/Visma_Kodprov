using System;
using System.Collections.Generic;
using System.IO;
using VismaSpcs.Recruitment.Rest;
using Xunit;

namespace VismaSpcs.Recruitment.Rest.Tests
{
    public class PrettyPrinterTests
    {
        [Fact]
        public void Print_ShouldPrintFormattedOutput_WhenDataIsValid()
        {
            var weatherData = new List<WeatherData>
            {
                new WeatherData
                {
                    ValidTime = "2023-06-10T12:00:00Z",
                    Parameters = new List<Parameter>
                    {
                        new Parameter { Name = "t", Values = new List<double> { 15.9 } },
                        new Parameter { Name = "ws", Values = new List<double> { 2.6 } }
                    }
                }
            };
            var prettyPrinter = new PrettyPrinter();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                prettyPrinter.Print(weatherData);

                var result = sw.ToString().Trim();
                Assert.Contains("Time: 2023-06-10T12:00:00Z, Temperature: 15.9°C, Wind Speed: 2.6 m/s", result);
            }
        }

        [Fact]
        public void Print_ShouldHandleEmptyList()
        {
            var weatherData = new List<WeatherData>();
            var prettyPrinter = new PrettyPrinter();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                prettyPrinter.Print(weatherData);

                var result = sw.ToString().Trim();
                Assert.Equal("No data available.", result);
            }
        }

        [Fact]
        public void Print_ShouldHandleNullData()
        {
            List<WeatherData> weatherData = null;
            var prettyPrinter = new PrettyPrinter();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                prettyPrinter.Print(weatherData);

                var result = sw.ToString().Trim();
                Assert.Equal("No data available.", result);
            }
        }

        [Fact]
        public void Print_ShouldSkipInvalidParameters()
        {
            var weatherData = new List<WeatherData>
            {
                new WeatherData
                {
                    ValidTime = "2023-06-10T12:00:00Z",
                    Parameters = new List<Parameter>
                    {
                        new Parameter { Name = "invalid", Values = new List<double> { 0.0 } }
                    }
                }
            };
            var prettyPrinter = new PrettyPrinter();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                prettyPrinter.Print(weatherData);

                var result = sw.ToString().Trim();
                Assert.Equal("", result);
            }
        }
    }
}
