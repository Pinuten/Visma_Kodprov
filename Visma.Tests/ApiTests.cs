using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RichardSzalay.MockHttp;
using VismaSpcs.Recruitment.Rest;
using Xunit;

namespace VismaSpcs.Recruitment.Rest.Tests
{
    public class ApiClientTests
    {
        [Fact]
        public async Task GetObjects_ShouldReturnFilteredData_WhenParameterExists()
        {
            // Arrange
            var mockHttp = new MockHttpMessageHandler();
            string apiResponse = @"{
                ""timeSeries"": [
                    {
                        ""validTime"": ""2023-06-10T12:00:00Z"",
                        ""parameters"": [
                            { ""name"": ""t"", ""values"": [15.9] },
                            { ""name"": ""ws"", ""values"": [2.6] }
                        ]
                    },
                    {
                        ""validTime"": ""2023-06-10T13:00:00Z"",
                        ""parameters"": [
                            { ""name"": ""t"", ""values"": [17.2] },
                            { ""name"": ""ws"", ""values"": [2.8] }
                        ]
                    }
                ]
            }";
            mockHttp.When("https://opendata-download-metfcst.smhi.se/*")
                    .Respond("application/json", apiResponse);

            var httpClient = new HttpClient(mockHttp);
            var apiClient = new ApiClient(httpClient);

            // Act
            var result = await apiClient.GetObjects<WeatherData>("t");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.All(result, item => Assert.Contains(item.Parameters, p => p.Name == "t"));
        }

        [Fact]
        public async Task GetObjects_ShouldReturnEmptyList_WhenParameterDoesNotExist()
        {
            // Arrange
            var mockHttp = new MockHttpMessageHandler();
            string apiResponse = @"{
                ""timeSeries"": []
            }";
            mockHttp.When("https://opendata-download-metfcst.smhi.se/*")
                    .Respond("application/json", apiResponse);

            var httpClient = new HttpClient(mockHttp);
            var apiClient = new ApiClient(httpClient);

            // Act
            var result = await apiClient.GetObjects<WeatherData>("invalid");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
