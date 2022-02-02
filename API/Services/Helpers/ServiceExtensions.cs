using System.Linq; 
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Services
{
    //
    public interface IBirthLocation { 
        public string BirthLocation { get; set; } 
    }
    //
    public interface IDeathLocation {
        public string DeathLocation { get; set; } 
    }
    //
    public interface IFatherChristianName { 
        public string FatherChristianName { get; set; } 
    }
    //
    public interface IFatherSurname { 
        public string FatherSurname { get; set; } 
    }
    //
    public interface IMotherChristianName { 
        public string MotherChristianName { get; set; } 
    }
    //
    public interface IMotherSurname { 
        public string MotherSurname { get; set; } 
    }
    //
    public interface ISource { 
        public string Source { get; set; } 
    }
    //
    public interface IDeathCounty { 
        public string DeathCounty { get; set; } 
    }
    //
    public interface IBirthCounty { 
        public string BirthCounty { get; set; }
    }
    //
    public interface IOccupation { 
        public string Occupation { get; set; } 
    }
    //
    public interface ISpouseName {
        public string SpouseName { get; set; }
    }
    //
    public interface ISpouseSurname { 
        public string SpouseSurname { get; set; } 
    }
    //
    public interface IFatherOccupation {
        public string FatherOccupation { get; set; }
    }

 

    public interface IPersonYears
    {
        public int BirthInt { get; set; }
        public int BapInt { get; set; }
        public int DeathInt { get; set; }

        public int EstBirthYearInt { get; set; }
    }

    public interface ICounty {
        public string County { get; set; }
    }

    public interface IParishName
    {
        public string Name { get; set; }

    }

    public interface IShardCMs
    {
        public double SharedCentimorgans { get; set; }
    }

    public interface IFirstName
    {
        public string ChristianName { get; set; }
    }
    public interface IName
    {
        public string Surname { get; set; }
    }

    public interface IOrigin
    {
        public string Origin { get; set; }
    }

    public interface IGroupNumber
    {
        public int GroupNumber { get; set; }
    }

    public interface ITesterName
    {
        public string Name { get; set; }
    }

    public interface Ilocation
    {
        public string Location { get; set; }
    }

    public interface IPreciseLocation : Ilocation {
        public double BirthLat { get; set; }
        public double BirthLong { get; set; }

    }

    public interface ISingleYear
    {
        public int Year { get; set; }
    }

    public interface IYearRange
    {
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
    }

    public interface IMarriageParticipants
    {
        public string MaleCname { get; set; }
        public string MaleSname { get; set; }
        public string FemaleCname { get; set; }
        public string FemaleSname { get; set; }
    }

    //public string SourceRef { get; set; }
   

    public interface ISourceRef
    {
        public string SourceRef { get; set; }
    }


 


    public static class ServiceExtensions
    {
        #region sources
        public static IQueryable<T> WhereIfSourceRef<T>(
            this IQueryable<T> source, string location) where T : ISourceRef
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.SourceRef.ToLower().Contains(location));
            }
            else
            {

                return source;
            }
        }
        #endregion


        #region persons
        public static IQueryable<T> WhereIfBirthLocation<T>(
            this IQueryable<T> source, string location) where T : IBirthLocation
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w=>w.BirthLocation.ToLower().Contains(location));
            }
            else
            {
              
                return source;
            }
        }

        public static IQueryable<T> WhereIfDeathLocation<T>(
            this IQueryable<T> source, string location) where T : IDeathLocation
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w=>w.DeathLocation.ToLower().Contains(location));
            }
            else
            {

                return source;
            }
        }

        public static IQueryable<T> WhereIfFatherChristianName<T>(
            this IQueryable<T> source, string location) where T : IFatherChristianName
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.FatherChristianName.ToLower().Contains(location));
            }
            else
            {

                return source;
            }
        }

        public static IQueryable<T> WhereIfFatherSurname<T>(
            this IQueryable<T> source, string location) where T : IFatherSurname
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.FatherSurname.ToLower().Contains(location));                
            }
            else
            {
                return source;
            }
        }
        public static IQueryable<T> WhereIfMotherChristianName<T>(
            this IQueryable<T> source, string location) where T : IMotherChristianName
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.MotherChristianName.ToLower().Contains(location));
            }
            else
            {

                return source;
            }
        }

        public static IQueryable<T> WhereIfMotheSurname<T>(
            this IQueryable<T> source, string location) where T : IMotherSurname
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.MotherSurname.ToLower().Contains(location));
            }
            else
            {

                return source;
            }
        }

        public static IQueryable<T> WhereIfSource<T>(
            this IQueryable<T> source, string location) where T : ISource
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.Source.ToLower().Contains(location));
            }
            else
            {

                return source;
            }
        }

        public static IQueryable<T> WhereIfDeathCounty<T>(
            this IQueryable<T> source, string location) where T : IDeathCounty
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.DeathCounty.ToLower().Contains(location));
            }
            else
            {

                return source;
            }
        }

        public static IQueryable<T> WhereIfBirthCounty<T>(
            this IQueryable<T> source, string location) where T : IBirthCounty
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.BirthCounty.ToLower().Contains(location));
            }
            else
            {

                return source;
            }
        }

        public static IQueryable<T> WhereIfOccupation<T>(
            this IQueryable<T> source, string location) where T : IOccupation
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.Occupation.ToLower().Contains(location));
            }
            else
            {

                return source;
            }
        }

        public static IQueryable<T> WhereIfSpouseName<T>(
            this IQueryable<T> source, string location) where T : ISpouseName
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.SpouseName.ToLower().Contains(location));
            }
            else
            {

                return source;
            }
        }

        public static IQueryable<T> WhereIfSpouseSurname<T>(
            this IQueryable<T> source, string location) where T : ISpouseSurname
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.SpouseSurname.ToLower().Contains(location));
            }
            else
            {

                return source;
            }
        }

        public static IQueryable<T> WhereIfFatherOccupation<T>(
            this IQueryable<T> source, string location) where T : IFatherOccupation
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.FatherOccupation.ToLower().Contains(location));
            }
            else
            {

                return source;
            }
        }

        public static IQueryable<T> WhereIfPersonWithinYears<T>(
          this IQueryable<T> source, int yearFrom, int yearTo) where T : IPersonYears
        {            
            if (yearFrom!= 0 && yearTo!=0)
            {
                return source.Where(w => (w.EstBirthYearInt <= yearTo && w.EstBirthYearInt >= yearFrom) || w.DeathInt <= yearTo && w.DeathInt >= yearFrom);
            }
            else
            {

                return source;
            }
        }

        #endregion

        #region marriages

        //IMarriageParticipants
        public static IQueryable<T> WhereIfMatchParticipants<T>(
                    this IQueryable<T> source,
                    string maleSName, string femaleSName) where T : IMarriageParticipants
        {

            if (!string.IsNullOrEmpty(maleSName) && string.IsNullOrEmpty(femaleSName))
            {
                return source.Where(w=>w.FemaleSname.ToLower().Contains(femaleSName)
                                                && w.MaleCname.ToLower().Contains(maleSName));
            }
            else
            {
                if (!string.IsNullOrEmpty(maleSName))
                {
                    return source.Where(w =>  w.MaleCname.ToLower().Contains(maleSName));
                }

                if (!string.IsNullOrEmpty(femaleSName))
                {
                    return source.Where(w => w.FemaleSname.ToLower().Contains(femaleSName));
                }

                return source;
            }
        }


        #endregion

        #region parish 

        public static IQueryable<T> WhereIfMatchParishName<T>(
                    this IQueryable<T> source,
                    string name) where T : IParishName
        {

            if (!string.IsNullOrEmpty(name))
            {
                return source.Where(w => w.Name.ToLower().Contains(name));
            }
            else
            {               
                return source;
            }
        }


        public static IQueryable<T> WhereIfMatchParishCounty<T>(
            this IQueryable<T> source,
            string name) where T : ICounty
        {

            if (!string.IsNullOrEmpty(name))
            {
                return source.Where(w => w.County.ToLower().Contains(name));
            }
            else
            {
                return source;
            }
        }


        #endregion



        #region ancestry matches

        public static IQueryable<T> WhereIfMinCM<T>(
                    this IQueryable<T> source,
                    double minCM) where T : IShardCMs
        {
            if (minCM >0)
                return source.Where(w => w.SharedCentimorgans > minCM);
            else
                return source;
        }

      
        public static IQueryable<T> WhereIfTesterName<T>(
                    this IQueryable<T> source,
                    string testerNames) where T : ITesterName
        {


            if (testerNames.Length > 0)
            {
                var names = testerNames.ToUpper().Split(' ');

                return source.Where(w => names.Contains(w.Name));
            }
            else
            {
                return source;
            }
        }

        public static IQueryable<T> WhereIfOrigin<T>(
            this IQueryable<T> source,
            string origin) where T : IOrigin
        {
            if (string.IsNullOrEmpty(origin))
                return source;

            if (origin.Contains(' '))
            {
                var locations = origin.Split(' ');

                return source.Where(w => locations.Contains(w.Origin));
            }
            else
            {
                return source.Where(w => w.Origin.ToLower().Contains(origin));
            }
            
        }

        public static IQueryable<T> WhereIfGroupId<T>(
           this IQueryable<T> source,
           int groupId) where T : IGroupNumber
        {
            if (groupId==-1)
                return source;

         
            return source.Where(w => w.GroupNumber == groupId);
            
        }

        #endregion

        public static IQueryable<TSource> WhereIf<TSource>(
                    this IQueryable<TSource> source,
                    bool condition,
                    Expression<Func<TSource, bool>> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }



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

                return source.Where(w=> AzureDBContext.east_or_west(lat, lng,w.BirthLat,w.BirthLong, rad));
                  
            }

            if (!string.IsNullOrEmpty(location))
                return source.Where(w => w.Location.ToLower().Contains(location));
            else
                return source;
        }


        static bool GetDistance(double lat1, double lon1, double lat2, double lon2, int distance )
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

        static double ToRadians(double deg)
        {
            return deg * (Math.PI / 180);
        }

        public static IQueryable<T> WhereIfLocation<T>(
            this IQueryable<T> source,
            string location) where T : Ilocation
        {
            
            if (!string.IsNullOrEmpty(location))
                return source.Where(w => w.Location.ToLower().Contains(location));
            else
                return source;
        }

        public static IQueryable<T> WhereIfSurname<T>(
                            this IQueryable<T> source,
                            string surname) where T : IName
        {
            if (!string.IsNullOrEmpty(surname))
                //return source.Where(w=>w.Surname.ToLower().Contains(surname));
                return source.Where(w => EF.Functions.Like(w.Surname, surname));
            else
                return source;
        }

        public static IQueryable<T> WhereIfSurnameBegins<T>(
                    this IQueryable<T> source,
                    string surname) where T : IName
        {
            if (!string.IsNullOrEmpty(surname))
                return source.Where(w => w.Surname.ToLower().StartsWith(surname));
            else
                return source;
        }

        public static IQueryable<T> WhereIfFirstName<T>(
                    this IQueryable<T> source,
                    string surname) where T : IFirstName
        {
            if (!string.IsNullOrEmpty(surname))
                return source.Where(w => w.ChristianName.ToLower().Contains(surname));
            else
                return source;
        }

        public static IQueryable<T> WhereIfYearsBetween<T>(
                                  this IQueryable<T> source,
                                
                                  int yearFrom,
                                  int yearTo) where T : IYearRange
        {


            Func<int, int, bool> validDates = (start, end) =>
            {
                if (start <= 0 && end <= 0) return false;
                if (start > end) return false;

                return true;
            };


            if (validDates(yearFrom,yearTo))
                return source.Where(a => a.YearFrom < yearTo && yearFrom < a.YearTo);
            else
                return source;
        }


        public static IQueryable<T> WhereIfYearBetween<T>(
                                 this IQueryable<T> source,
                                 int yearFrom,
                                  int yearTo) where T : ISingleYear
        {
            Func<int, int, bool> validDates = (start, end) =>
            {
                if (start <= 0 && end <= 0) return false;
                if (start > end) return false;

                return true;
            };

            if (validDates(yearFrom, yearTo))
                return source.Where(w => w.Year >= yearFrom && w.Year < yearTo);
            else
                return source;
        }
    }
}