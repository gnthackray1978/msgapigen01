using FTMContextNet.Domain.Entities.Persistent.Cache;
using MSGSharedData.Domain.Entities.Persistent.DNA;

namespace MSGSharedData.Data.Services.Helpers
{
    public static class DNAAnalyseLinqExtensions
    {

        public static IEnumerable<DupeEntry> DupeSortIf
        (this IQueryable<DupeEntry> source,
            string columnName,
            string columnOrder)
        {
            if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(columnOrder))
            {
                columnName = columnName.ToLower();

                if (columnName == "surname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Surname) : source.OrderByDescending(z => z.Surname);

                if (columnName == "ident")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Ident) : source.OrderByDescending(z => z.Ident);

                if (columnName == "origin")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Origin) : source.OrderByDescending(z => z.Origin);

                if (columnName == "yearstart")
                    return columnOrder == "asc" ? source.OrderBy(z => z.YearStart) : source.OrderByDescending(z => z.YearStart);

                if (columnName == "yearend")
                    return columnOrder == "asc" ? source.OrderBy(z => z.YearEnd) : source.OrderByDescending(z => z.YearEnd);

                if (columnName == "location")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Location) : source.OrderByDescending(z => z.Location);

                if (columnName == "firstname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.FirstName) : source.OrderByDescending(z => z.FirstName);
            }

            return source.OrderBy(o => o.Id);
        }

        public static IEnumerable<FTMPersonView> FTMViewSortIf
        (this IQueryable<FTMPersonView> source,
            string columnName,
            string columnOrder)
        {
            if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(columnOrder))
            {
                columnName = columnName.ToLower();

                if (columnName == "firstname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.FirstName) : source.OrderByDescending(z => z.FirstName);

                if (columnName == "surname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Surname) : source.OrderByDescending(z => z.Surname);

                if (columnName == "origin")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Origin) : source.OrderByDescending(z => z.Origin);

                if (columnName == "location")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Location) : source.OrderByDescending(z => z.Location);



                if (columnName == "altlat")
                    return columnOrder == "asc" ? source.OrderBy(z => z.AltLat) : source.OrderByDescending(z => z.AltLat);

                if (columnName == "altlong")
                    return columnOrder == "asc" ? source.OrderBy(z => z.AltLong) : source.OrderByDescending(z => z.AltLong);

                if (columnName == "altlocation")
                    return columnOrder == "asc" ? source.OrderBy(z => z.AltLocation) : source.OrderByDescending(z => z.AltLocation);

                if (columnName == "altlocationdesc")
                    return columnOrder == "asc" ? source.OrderBy(z => z.AltLocationDesc) : source.OrderByDescending(z => z.AltLocationDesc);



                if (columnName == "yearstart")
                    return columnOrder == "asc" ? source.OrderBy(z => z.YearStart) : source.OrderByDescending(z => z.YearStart);

                if (columnName == "yearend")
                    return columnOrder == "asc" ? source.OrderBy(z => z.YearEnd) : source.OrderByDescending(z => z.YearEnd);



                if (columnName == "lng")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Lng) : source.OrderByDescending(z => z.Lng);

                if (columnName == "lat")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Lat) : source.OrderByDescending(z => z.Lat);

            }


            return source.OrderBy(o => o.Id);
        }


        public static IEnumerable<PersonsOfInterest> PersonOfInterestSortIf
        (this IQueryable<PersonsOfInterest> source,
            string columnName,
            string columnOrder)
        {
            if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(columnOrder))
            {
                columnName = columnName.ToLower();

                if (columnName == "surname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Surname) : source.OrderByDescending(z => z.Surname);

                if (columnName == "location")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Location) : source.OrderByDescending(z => z.Location);

                if (columnName == "memory")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Memory) : source.OrderByDescending(z => z.Memory);

                if (columnName == "name")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Name) : source.OrderByDescending(z => z.Name);

                if (columnName == "rootsentry")
                    return columnOrder == "asc" ? source.OrderBy(z => z.RootsEntry) : source.OrderByDescending(z => z.RootsEntry);

                if (columnName == "sharedcentimorgans")
                    return columnOrder == "asc" ? source.OrderBy(z => z.SharedCentimorgans) : source.OrderByDescending(z => z.SharedCentimorgans);

                if (columnName == "testadmindisplayname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.TestAdminDisplayName) : source.OrderByDescending(z => z.TestAdminDisplayName);

                if (columnName == "testdisplayname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.TestDisplayName) : source.OrderByDescending(z => z.TestDisplayName);

                if (columnName == "treeurl")
                    return columnOrder == "asc" ? source.OrderBy(z => z.TreeUrl) : source.OrderByDescending(z => z.TreeUrl);

                if (columnName == "year")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Year) : source.OrderByDescending(z => z.Year);


            }


            return source.OrderBy(o => o.Surname);
        }


        public static IEnumerable<TreeRecord> TreeRecSortIf
        (this IQueryable<TreeRecord> source,
            string columnName,
            string columnOrder)
        {
            if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(columnOrder))
            {
                columnName = columnName.ToLower();

                if (columnName == "cm")
                    return columnOrder == "asc" ? source.OrderBy(z => z.CM) : source.OrderByDescending(z => z.CM);

                if (columnName == "located")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Located) : source.OrderByDescending(z => z.Located);

                if (columnName == "name")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Name) : source.OrderByDescending(z => z.Name);

                if (columnName == "origin")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Origin) : source.OrderByDescending(z => z.Origin);



            }


            return source.OrderByDescending(o => o.CM);
        }
    }
}