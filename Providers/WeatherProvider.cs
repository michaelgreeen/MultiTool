using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Pr.Models;
using System.Net.Http;
using System.Text.Json;

namespace Pr.Providers
{
    public interface IWeatherProvider
    {
        public Task<string> GetWeatherForCity(string city);
    }

    public class WeatherProvider : IWeatherProvider
    {
        private readonly WeatherClientConfig _config;
        private readonly IHttpClientFactory _httpClientFactory;
        public WeatherProvider(IOptions<WeatherClientConfig> config, IHttpClientFactory clientFactory)
        {
            _config = config.Value;
            _httpClientFactory = clientFactory;
        }

        public async Task<string> GetWeatherForCity(string city)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    requestUri: $"{_config.EndpointUrl}?q={city}&appid={_config.ApplicationId}&units={_config.Units}");
            
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                var x =  await JsonSerializer.DeserializeAsync<object>(contentStream);
                string s = x.ToString();
                return s;
            }
            return null;
        }
    }
}
