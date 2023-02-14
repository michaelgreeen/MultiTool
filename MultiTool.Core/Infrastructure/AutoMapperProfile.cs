using AutoMapper;
using MultiTool.Models;

namespace MultiTool.Core.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<WeatherData, WeatherDto>();
        }
    }
}
