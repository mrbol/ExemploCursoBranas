using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public static class DistanceCalculator
    {
        public static double Calculate(Coordinate from, Coordinate to)
        {
            if (from.Latitude == to.Latitude && from.Longitude == to.Longitude) return 0;
            var radlat1 = (Math.PI * from.Latitude) / 180;
            var radlat2 = (Math.PI * to.Latitude) / 180;
            var theta = from.Longitude - to.Longitude;
            var radtheta = (Math.PI * theta) / 180;
            var dist = Math.Sin(radlat1) * Math.Sin(radlat2) + Math.Cos(radlat1) * Math.Cos(radlat2) * Math.Cos(radtheta);
            if (dist > 1) dist = 1;
            dist = Math.Acos(dist);
            dist = (dist * 180) / Math.PI;
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344; //convert miles to km
            return dist;
        }
    }
}
