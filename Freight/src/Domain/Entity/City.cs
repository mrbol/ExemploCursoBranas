using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class City
    {
        public Coordinate Coordinate { get; set; }
        public int IdCity { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public City( int idCity, string name, double latitude, double longitude) {
            IdCity = idCity;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            Coordinate = new Coordinate(latitude, longitude);
        }
    }
}
