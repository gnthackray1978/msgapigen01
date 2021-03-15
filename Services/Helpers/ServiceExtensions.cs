using System.Linq;
using System;
using System.Linq.Expressions;

namespace GqlMovies.Api.Services
{
    public interface IShardCMs
    {
        public double SharedCentimorgans { get; set; }
    }

    public interface IName
    {
        public string Surname { get; set; }
    }

    public interface ITesterName
    {
        public string Name { get; set; }
    }

    public interface Ilocation
    {
        public string Location { get; set; }
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

 


    public static class ServiceExtensions
    {
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

        public static IQueryable<T> WhereIfLocation<T>(
                    this IQueryable<T> source,
                    string location) where T : Ilocation
        {
            if (!string.IsNullOrEmpty(location))
                return source.Where(w => w.Location.ToLower().Contains(location));
            else
                return source;
        }

        //IShardCMs
        public static IQueryable<T> WhereIfMinCM<T>(
                    this IQueryable<T> source,
                    double minCM) where T : IShardCMs
        {
            if (minCM >0)
                return source.Where(w => w.SharedCentimorgans > minCM);
            else
                return source;
        }

        //IShardCMs
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


        public static IQueryable<T> WhereIfSurname<T>(
                            this IQueryable<T> source,
                            string surname) where T : IName
        {
            if (!string.IsNullOrEmpty(surname))
                return source.Where(w=>w.Surname.ToLower().Contains(surname));
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