using Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureContext.Models
{
    public static class DNAAnalyseLinqExtensions
    {
        public static IEnumerable<Marriages> MarriageSortIf
            (this IQueryable<Marriages> source,
            string columnName,
            string columnOrder)
        {
            if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(columnOrder))
            {
                columnName = columnName.ToLower();

                if (columnName == "malesname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.MaleSname) : source.OrderByDescending(z => z.MaleSname);

                if (columnName == "femalesname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.FemaleSname) : source.OrderByDescending(z => z.FemaleSname);
                
                if (columnName == "malecname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.MaleCname) : source.OrderByDescending(z => z.MaleCname);

                if (columnName == "femalecname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.FemaleCname) : source.OrderByDescending(z => z.FemaleCname);

                if (columnName == "year")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Year) : source.OrderByDescending(z => z.Year);
           
                if (columnName == "location")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Location) : source.OrderByDescending(z => z.Location);
                 
            }

            return source.OrderBy(o => o.Id);
        }


        public static IEnumerable<Persons> PersonSortIf
                  (this IQueryable<Persons> source,
                  string columnName,
                  string columnOrder)
        {
            if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(columnOrder))
            {
                columnName = columnName.ToLower();
                //estBirthYearInt
                if (columnName == "estBirthYearInt")
                    return columnOrder == "asc" ? source.OrderBy(z => z.EstBirthYearInt) : source.OrderByDescending(z => z.EstBirthYearInt);

                if (columnName == "birthint" || columnName == "bapint")
                    return columnOrder == "asc" ? source.OrderBy(z => z.EstBirthYearInt) : source.OrderByDescending(z => z.EstBirthYearInt);

                if (columnName == "deathint")
                    return columnOrder == "asc" ? source.OrderBy(z => z.EstDeathYearInt) : source.OrderByDescending(z => z.EstDeathYearInt);

                if (columnName == "birthcounty")
                    return columnOrder == "asc" ? source.OrderBy(z => z.BirthCounty) : source.OrderByDescending(z => z.BirthCounty);

                if (columnName == "birthlocation")
                    return columnOrder == "asc" ? source.OrderBy(z => z.BirthLocation) : source.OrderByDescending(z => z.BirthLocation);

                if (columnName == "christianname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.ChristianName) : source.OrderByDescending(z => z.ChristianName);

                if (columnName == "deathcounty")
                    return columnOrder == "asc" ? source.OrderBy(z => z.DeathCounty) : source.OrderByDescending(z => z.DeathCounty);

                if (columnName == "fatherchristianname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.FatherChristianName) : source.OrderByDescending(z => z.FatherChristianName);
               
                if (columnName == "fathersurname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.FatherSurname) : source.OrderByDescending(z => z.FatherSurname);

                if (columnName == "fatheroccupation")
                    return columnOrder == "asc" ? source.OrderBy(z => z.FatherOccupation) : source.OrderByDescending(z => z.FatherOccupation);

                if (columnName == "motherchristianname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.MotherChristianName) : source.OrderByDescending(z => z.MotherChristianName);

                if (columnName == "mothersurname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.MotherSurname) : source.OrderByDescending(z => z.MotherSurname);

                if (columnName == "occupation")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Occupation) : source.OrderByDescending(z => z.Occupation);

                if (columnName == "spousename")
                    return columnOrder == "asc" ? source.OrderBy(z => z.SpouseName) : source.OrderByDescending(z => z.SpouseName);

                if (columnName == "spousesurname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.SpouseSurname) : source.OrderByDescending(z => z.SpouseSurname);

                if (columnName == "surname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Surname) : source.OrderByDescending(z => z.Surname);

                
            }

            return source.OrderBy(o => o.Id);
        }



    }


    public partial class Marriages : Ilocation , ISingleYear, IMarriageParticipants
    {
        public int Id { get; set; }
         
        public string MaleCname { get; set; }
        public string MaleSname { get; set; }
        public string MaleLocation { get; set; }
        public string MaleInfo { get; set; }
        public string FemaleCname { get; set; }
        public string FemaleSname { get; set; }
        public string FemaleLocation { get; set; }
        public string FemaleInfo { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public int Year { get; set; }
        public string MarriageCounty { get; set; }
        public string Source { get; set; }
        public string Witness1 { get; set; }
        public string Witness2 { get; set; }
        public string Witness3 { get; set; }
        public string Witness4 { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateLastEdit { get; set; }
        public string OrigMaleSurname { get; set; }
        public string OrigFemaleSurname { get; set; }
        public string MaleOccupation { get; set; }
        public string FemaleOccupation { get; set; }
        public bool FemaleIsKnownWidow { get; set; }
        public bool MaleIsKnownWidower { get; set; }
        public bool IsBanns { get; set; }
        public bool IsLicence { get; set; }
        public int MaleBirthYear { get; set; }
        public int FemaleBirthYear { get; set; }
        public string UniqueRef { get; set; }
        public int TotalEvents { get; set; }
        public int EventPriority { get; set; }
        public bool IsDeleted { get; set; }
    }
}
