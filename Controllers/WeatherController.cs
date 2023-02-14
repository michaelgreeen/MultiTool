using Microsoft.AspNetCore.Mvc;
using Pr.Providers;

namespace Pr.Controllers
{
    [Route("[controller]/[action]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherProvider _weatherProvider;
        public WeatherController(IWeatherProvider weatherProvider)
        {
            _weatherProvider = weatherProvider;
        }
        public async Task<IActionResult> GetWeatherFrom(string city)
        {
            return Ok(await _weatherProvider.GetWeatherForCity(city));
        }
    }
}
