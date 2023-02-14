using Microsoft.Extensions.Options;
using MultiTool.Models;
using MultiTool.Core.Config;
using System.Text.Json;
using AutoMapper;
using System.Net;

namespace MultiTool.Core.Providers
{
    public interface IWeatherProvider
    {
        public Task<WeatherData> GetWeatherForCity(string city);
    }

    public class WeatherProvider : IWeatherProvider
    {
        private readonly WeatherClientConfig _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherProvider(IOptions<WeatherClientConfig> config, 
                               IHttpClientFactory clientFactory,
                               IMapper mapper)
        {
            _config = config.Value;
            _httpClientFactory = clientFactory;
        }

        public async Task<WeatherData> GetWeatherForCity(string city)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    requestUri: $"{_config.EndpointUrl}?q={city}&appid={_config.ApplicationId}&units={_config.Units}");
            
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                var result =  await JsonSerializer.DeserializeAsync<WeatherInfo>(contentStream);
                return GetWeatherData(result);
            }
            return new WeatherData() ;
        }

        private WeatherData GetWeatherData(WeatherInfo? weatherInfo)
        {
            if(!weatherInfo.List.Any())
            {
                return null;
            }
            return weatherInfo.List.FirstOrDefault();
        }
    }
}
