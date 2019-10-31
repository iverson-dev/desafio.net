using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestWebApi2
{
    public class TestWebApi2
    {
        public string ApiBaseUrl { get; set; } = "http://localhost:5100";


        public TestWebApi2()
        {
            string apiBaseUrl = Environment.GetEnvironmentVariable("ApiBaseUrl");
            if (!String.IsNullOrEmpty(apiBaseUrl))
            {
                ApiBaseUrl = apiBaseUrl;
            }
        }

        [Fact]
        public async Task VerificaArredontamento1()
        {
            
            var apiClient = new HttpClient();

            var apiResponse = await apiClient.GetAsync($"{ApiBaseUrl}/calculajuros?valorinicial=100&meses=5");

            Assert.True(apiResponse.IsSuccessStatusCode);

            var stringResponse = await apiResponse.Content.ReadAsStringAsync();

            Assert.Equal("105.10", stringResponse.Replace(",", "."));
        }


        [Fact]
        public async Task VerificaArredontamento2()
        {

            var apiClient = new HttpClient();

            var apiResponse = await apiClient.GetAsync($"{ApiBaseUrl}/calculajuros?valorinicial=100&meses=9");

            Assert.True(apiResponse.IsSuccessStatusCode);

            var stringResponse = await apiResponse.Content.ReadAsStringAsync();

            Assert.Equal("109.36", stringResponse.Replace(",", "."));
        }

        [Fact]
        public async Task VerificaArredontamento3()
        {

            var apiClient = new HttpClient();

            var apiResponse = await apiClient.GetAsync($"{ApiBaseUrl}/calculajuros?valorinicial=100&meses=60");

            Assert.True(apiResponse.IsSuccessStatusCode);

            var stringResponse = await apiResponse.Content.ReadAsStringAsync();

            Assert.Equal("181.66", stringResponse.Replace(",", "."));
        }

        [Fact]
        public async Task VerificaLinkRepositorio()
        {

            var apiClient = new HttpClient();

            var apiResponse = await apiClient.GetAsync($"{ApiBaseUrl}/showmethecode");

            Assert.True(apiResponse.IsSuccessStatusCode);

            var stringResponse = await apiResponse.Content.ReadAsStringAsync();

            Assert.Equal("https://github.com/iverson-dev/desafio.net", stringResponse.Trim());
        }

        
    }
}
