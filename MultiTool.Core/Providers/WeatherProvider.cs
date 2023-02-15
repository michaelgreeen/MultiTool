using Microsoft.Extensions.Options;
using MultiTool.Models;
using MultiTool.Core.Config;
using System.Text.Json;

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
        private readonly ILogger<WeatherProvider> _log;

        public WeatherProvider(IOptions<WeatherClientConfig> config, 
                               IHttpClientFactory clientFactory,
                               ILogger<WeatherProvider> log)
        {
            _config = config.Value;
            _httpClientFactory = clientFactory;
            _log = log;
        }

        public async Task<WeatherData> GetWeatherForCity(string city)
        {
            _log.LogInformation($"Started getting weather for {city}");
            var httpClient = _httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    requestUri: $"{_config.EndpointUrl}?q={city}&appid={_config.ApplicationId}&units={_config.Units}");
            try
            {
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    _log.LogInformation("Deserializing weather response");
                    var result = await JsonSerializer.DeserializeAsync<WeatherInfo>(contentStream);
                    _log.LogInformation($"Successfully deserialized weather for {city}");

                    return GetWeatherData(result);
                }

                return new WeatherData();
            }
            catch(JsonException e)
            {
                //TODO add some handling
                _log.LogError($"Deserialization error", e);
                return await Task.FromException<WeatherData>(e);
            }
            catch(Exception e)
            {
                //TODO add some handling
                _log.LogError($"Failure when sending the request", e);
                return await Task.FromException<WeatherData>(e);
            }
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
