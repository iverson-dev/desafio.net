using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestWebApi1
{
    public class TestWebApi1
    {
        public string ApiBaseUrl { get; set; } = "http://localhost:5000";

        
        public TestWebApi1()
        {            
            string apiBaseUrl = Environment.GetEnvironmentVariable("ApiBaseUrl");
            if (!String.IsNullOrEmpty(apiBaseUrl))
            {
                ApiBaseUrl = apiBaseUrl;
            }
        }

        [Fact]
        public async Task GetTaxaJuros()
        {
            var apiClient = new HttpClient();

            var apiResponse = await apiClient.GetAsync($"{ApiBaseUrl}/taxaJuros");

            Assert.True(apiResponse.IsSuccessStatusCode);

            var stringResponse = await apiResponse.Content.ReadAsStringAsync();

            Assert.Equal("0.01", stringResponse.Replace(",","."));

        }
    }
}
