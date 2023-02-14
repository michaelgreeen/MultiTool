using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiTool.Core.Providers;
using MultiTool.Models;

namespace MultiTool.Core.Controllers
{
    [Route("[controller]/[action]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherProvider _weatherProvider;
        private readonly IMapper _mapper;
        public WeatherController(IWeatherProvider weatherProvider, IMapper mapper)
        {
            _weatherProvider = weatherProvider;
            _mapper = mapper;
        }

        [HttpGet("{city}")]
        public async Task<ActionResult<WeatherDto>> GetWeatherFrom(string city)
        {
            var result = await _weatherProvider.GetWeatherForCity(city);
            return Ok(_mapper.Map<WeatherDto>(result));
        }
    }
}
