using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Models
{
    public class MainInfo
    {
        public double Temp { get; set; }

        public int Pressure { get; set; }

        public int Humidity { get; set; }

        public string Temp_min { get; set; }

        public string Temp_max { get; set; }
    }
}