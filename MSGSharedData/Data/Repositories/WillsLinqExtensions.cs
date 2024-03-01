using MSGSharedData.Domain.Entities.Persistent.Wills;

namespace MSGSharedData.Data.Services;

public static class WillsLinqExtensions
{

    public static IEnumerable<IWill> SortIf
    (this IQueryable<IWill> source,
        string columnName,
        string columnOrder)
    {


        if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(columnOrder))
        {
            if (columnName == "Collection")
                return columnOrder == "asc" ? source.OrderBy(z => z.Collection) : source.OrderByDescending(z => z.Collection);

            if (columnName == "Aliases")
                return columnOrder == "asc" ? source.OrderBy(z => z.Aliases) : source.OrderByDescending(z => z.Aliases);

            if (columnName == "DateString")
                return columnOrder == "asc" ? source.OrderBy(z => z.DateString) : source.OrderByDescending(z => z.DateString);

            if (columnName == "Description")
                return columnOrder == "asc" ? source.OrderBy(z => z.Description) : source.OrderByDescending(z => z.Description);

            if (columnName == "FirstName")
                return columnOrder == "asc" ? source.OrderBy(z => z.FirstName) : source.OrderByDescending(z => z.FirstName);

            if (columnName == "Occupation")
                return columnOrder == "asc" ? source.OrderBy(z => z.Occupation) : source.OrderByDescending(z => z.Occupation);

            if (columnName == "Place")
                return columnOrder == "asc" ? source.OrderBy(z => z.Place) : source.OrderByDescending(z => z.Place);

            if (columnName == "Reference")
                return columnOrder == "asc" ? source.OrderBy(z => z.Reference) : source.OrderByDescending(z => z.Reference);

            if (columnName == "Surname")
                return columnOrder == "asc" ? source.OrderBy(z => z.Surname) : source.OrderByDescending(z => z.Surname);

            if (columnName == "Url")
                return columnOrder == "asc" ? source.OrderBy(z => z.Url) : source.OrderByDescending(z => z.Url);

            if (columnName == "Year")
                return columnOrder == "asc" ? source.OrderBy(z => z.Year) : source.OrderByDescending(z => z.Year);

        }

        return source.OrderBy(o => o.Year);

    }
}