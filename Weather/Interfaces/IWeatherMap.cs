using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Interfaces
{
    interface IWeatherMap
    {
        Coordinates Coord { get; set; }

        List<WeatherInfo> Weather { get; set; }

        string @base { get; set; }

        MainInfo Main { get; set; }

        int Visibility { get; set; }

        Wind Wind { get; set; }

        Clouds Clouds { get; set; }

        int Dt { get; set; }

        Sys Sys { get; set; }

        int Id { get; set; }

        string Name { get; set; }

        int Cod { get; set; }

    }
}
