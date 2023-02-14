using Microsoft.Extensions.Options;
using MultiTool.Core.Config.Weather;
using MultiTool.Models.Weather;
using System.Text.Json;

namespace MultiTool.Core.Providers
{
    public interface IWeatherProvider
    {
        public Task<List<WeatherData>> GetWeatherForCity(string city);
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

        public async Task<List<WeatherData>> GetWeatherForCity(string city)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    requestUri: $"{_config.EndpointUrl}?q={city}&appid={_config.ApplicationId}&units={_config.Units}");
            
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<WeatherData>>(contentStream);
            }
            return null;
        }
    }
}
