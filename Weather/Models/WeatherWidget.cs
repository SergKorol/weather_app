using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weather.Interfaces;

namespace Weather.Models
{
    public class WeatherWidget : IWeatherMap
    {
        public Coordinates Coord { get; set; }

        public List<WeatherInfo> Weather { get; set; }

        public string @base { get; set; }

        public MainInfo Main { get; set; }

        public int Visibility { get; set; }

        public Wind Wind { get; set; }

        public Clouds Clouds { get; set; }

        public int Dt { get; set; }

        public Sys Sys { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Cod { get; set; }
    }
}