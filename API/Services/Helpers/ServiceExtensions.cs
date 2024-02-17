using System.Linq;
using System;
using System.Linq.Expressions;
using Api.Types.RequestQueries;
using Api.Services.interfaces.domain;

namespace Api.Services
{
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
            
            return source;
            
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
            
            return source;
            
        }

        public static IQueryable<T> WhereIfDeathLocation<T>(
            this IQueryable<T> source, string location) where T : IDeathLocation
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.DeathLocation.ToLower().Contains(location));
            }

            return source;
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
          this IQueryable<T> source, IYearRange yearRange) where T : IPersonYears
        {            
            if (yearRange.YearFrom != 0 && yearRange.YearTo != 0)
            {
                return source.Where(w => (w.EstBirthYearInt <= yearRange.YearTo && w.EstBirthYearInt >= yearRange.YearFrom) || w.DeathInt <= yearRange.YearTo && w.DeathInt >= yearRange.YearFrom);
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
            
            return source;
        }


        public static IQueryable<T> WhereIfMatchParishCounty<T>(
            this IQueryable<T> source,
            string name) where T : ICounty
        {

            if (!string.IsNullOrEmpty(name))
            {
                return source.Where(w => w.County.ToLower().Contains(name));
            }

            return source;
            
        }


        #endregion



        #region ancestry matches

        public static IQueryable<T> WhereIfMinCM<T>(
                    this IQueryable<T> source,
                    DNASearchParamObj minCM) where T : IShardCMs
        {
            if (minCM.MinCM > 0)
                return source.Where(w => w.SharedCentimorgans > minCM.MinCM);
            
            return source;
        }


        public static IQueryable<T> WhereIfOrigin<T>(
            this IQueryable<T> source,
            GroupingsObj param) where T : IOrigin
        {
            //this origin might now be a group

            var origins = param.GetOrigins();

            if (origins.Count ==0)
                return source;

            return source.Where(w => origins.Contains(w.Origin));
        }


        #endregion

        public static IQueryable<TSource> WhereIf<TSource>(
                    this IQueryable<TSource> source,
                    bool condition,
                    Expression<Func<TSource, bool>> predicate)
        {
            if (condition)
                return source.Where(predicate);
            
            return source;
        }


        public static IQueryable<T> WhereIfYearsBetween<T>(
                                  this IQueryable<T> source,
                                  IYearRange yearRange) where T : IYearRange
        {


            Func<int, int, bool> validDates = (start, end) =>
            {
                if (start <= 0 && end <= 0) return false;
                if (start > end) return false;

                return true;
            };


            if (validDates(yearRange.YearFrom,yearRange.YearTo))
                return source.Where(a => a.YearFrom < yearRange.YearTo && yearRange.YearFrom < a.YearTo);
            
            return source;
        }


        public static IQueryable<T> WhereIfYearBetween<T>(
                                 this IQueryable<T> source,
                                 IYearRange yearRange) where T : ISingleYear
        {
            Func<int, int, bool> validDates = (start, end) =>
            {
                if (start <= 0 && end <= 0) return false;
                if (start > end) return false;

                return true;
            };

            if (validDates(yearRange.YearFrom, yearRange.YearTo))
                return source.Where(w => w.Year >= yearRange.YearFrom && w.Year < yearRange.YearTo);
            else
                return source;
        }
    }
}