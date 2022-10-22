using System.Linq;
using Api.Services.interfaces.domain;
using Api.Types.RequestQueries;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public static class NameExtensions
    {
        public static IQueryable<T> WhereIfFatherChristianName<T>(
            this IQueryable<T> source, string location) where T : IFatherChristianName
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.FatherChristianName.ToLower().Contains(location));
            }
            
            return source;
        }

        public static IQueryable<T> WhereIfFatherSurname<T>(
            this IQueryable<T> source, string location) where T : IFatherSurname
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.FatherSurname.ToLower().Contains(location));                
            }
            
            return source;
        }

        public static IQueryable<T> WhereIfMotherChristianName<T>(
            this IQueryable<T> source, string location) where T : IMotherChristianName
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.MotherChristianName.ToLower().Contains(location));
            }
            
            return source;
            
        }

        public static IQueryable<T> WhereIfMotheSurname<T>(
            this IQueryable<T> source, string location) where T : IMotherSurname
        {

            if (!string.IsNullOrEmpty(location))
            {
                return source.Where(w => w.MotherSurname.ToLower().Contains(location));
            }
            
            return source;
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

        public static IQueryable<T> WhereIfTesterName<T>(
            this IQueryable<T> source,
            DNASearchParamObj testerNames) where T : ITesterName
        {
            if (testerNames.Name.Length > 0)
            {
                var names = testerNames.Name.ToUpper().Split(' ');

                return source.Where(w => names.Contains(w.Name));
            }
            
            return source;
        }

        public static IQueryable<T> WhereIfName<T>(
            this IQueryable<T> source,
            string name) where T : ITreeName
        {
            if (name.Length > 0)
            {
                var names = name.ToLower();

                return source.Where(w => w.Name.ToLower().Contains(names));
            }

            return source;
        }

        public static IQueryable<T> WhereIfSurname<T>(
            this IQueryable<T> source,
            ISurname surname) where T : IName
        {
            if (!string.IsNullOrEmpty(surname.Surname))
                return source.Where(w => EF.Functions.Like(w.Surname, surname.Surname));
            
            return source;
        }

        public static IQueryable<T> WhereIfSurnameBegins<T>(
            this IQueryable<T> source,
            ISurname surname) where T : IName
        {
            if (!string.IsNullOrEmpty(surname.Surname))
                return source.Where(w => w.Surname.ToLower().StartsWith(surname.Surname));
            
            return source;
        }

        public static IQueryable<T> WhereIfFirstName<T>(
            this IQueryable<T> source,
            ADBPersonParamObj surname) where T : IFirstName
        {
            if (!string.IsNullOrEmpty(surname.FirstName))
                return source.Where(w => w.ChristianName.ToLower().Contains(surname.FirstName));
            
            return source;
        }
    }
}