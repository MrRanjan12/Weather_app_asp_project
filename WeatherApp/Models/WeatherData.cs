using System.Collections.Generic; // Required for List<T>

namespace WeatherApp.Models
{
    public class WeatherData
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; } // Weather is an array, so we use List
        public Main Main { get; set; }
        public string Name { get; set; } // This corresponds to the city name
    }

    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
    }
}
