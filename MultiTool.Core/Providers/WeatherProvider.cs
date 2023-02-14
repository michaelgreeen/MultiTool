using Microsoft.Extensions.Options;
using MultiTool.Models;
using MultiTool.Core.Config;
using System.Text.Json;

namespace MultiTool.Core.Providers
{
    public interface IWeatherProvider
    {
        public Task<WeatherInfo> GetWeatherForCity(string city);
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

        public async Task<WeatherInfo> GetWeatherForCity(string city)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    requestUri: $"{_config.EndpointUrl}?q={city}&appid={_config.ApplicationId}&units={_config.Units}");
            
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<WeatherInfo>(contentStream);
            }
            return null;
        }
    }
}
