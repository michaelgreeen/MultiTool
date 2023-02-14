/*
namespace Pr.Models
{
    public interface ICoord
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public interface IMain
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

    public interface IWind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }

    public interface ISys
    {
        public string Country { get; set; }
    }

    public interface IClouds
    {
        public int All { get; set; }
    }

    public interface IWeather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public interface ICity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICoord Coord { get; set; }
        public IMain Main { get; set; }
        public int Dt { get; set; }
        public IWind Wind { get; set; }
        public ISys Sys { get; set; }
        public IClouds Clouds { get; set; }
        public IWeather[] Weather { get; set; }
    }

    public interface IWeatherData
    {
        public string? Message { get; set; }
        public string? Cod { get; set; }
        public int? Count { get; set; }
        public ICity[]? List { get; set; }
    }
}
*/