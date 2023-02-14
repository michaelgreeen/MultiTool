namespace MultiTool.Models
{
    public class WeatherDto
    {
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public MainData Main { get; set; }
        public Wind Wind { get; set; }
        public Sys Sys { get; set; }
        public object Rain { get; set; }
        public object Snow { get; set; }
        public Clouds Clouds { get; set; }
    }
}
