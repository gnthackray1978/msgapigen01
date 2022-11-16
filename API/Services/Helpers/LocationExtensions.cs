using System;
using System.Linq;
using Api.DB;
using Api.Services.interfaces.domain;
using Api.Types.RequestQueries;

namespace Api.Services
{
    public static class LocationExtensions
    {
        public static IQueryable<T> WhereIfLocationPrecise<T>(
            this IQueryable<T> source,
            string location) where T : IPreciseLocation
        {
            //string location = @"54.5_45.55_10";

            if (location.Any(c => char.IsDigit(c)))
            {

                var locationParts = location.Split('_');
                double lat = 0;
                double lng = 0;
                double rad = 5;

                if (locationParts.Length == 0 || locationParts.Length == 1)
                {
                    return source;
                }

                double.TryParse(locationParts[0], out lat);

                double.TryParse(locationParts[1], out lng);

                if (locationParts.Length == 3)
                    double.TryParse(locationParts[2], out rad);

                return source.Where(w=> DNAContext.east_or_west(lat, lng,w.BirthLat,w.BirthLong, rad));
                  
            }

            if (!string.IsNullOrEmpty(location))
                return source.Where(w => w.Location.ToLower().Contains(location));
            
            return source;
        }

        private static bool GetDistance(double lat1, double lon1, double lat2, double lon2, int distance )
        {
       
            var R = 6371; // Radius of the earth in km
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);
            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c; // Distance in km
            return d < distance;
        }

        private static double ToRadians(double deg)
        {
            return deg * (Math.PI / 180);
        }

        public static IQueryable<T> WhereIfLocation<T>(
            this IQueryable<T> source,
            Ilocation location) where T : Ilocation
        {
            if (!string.IsNullOrEmpty(location.Location))
                return source.Where(w => w.Location.ToLower().Contains(location.Location));
            
            return source;
        }
    }
}