using Api.Services.interfaces;
using Api.Types;
using Api.Types.DNAAnalyse;
using GqlMovies.Api.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Api.Models;
using AzureContext.Models;

namespace GqlMovies.Api.Services
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
                if (columnName == "Surname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Surname) : source.OrderByDescending(z => z.Surname);

                if (columnName == "Ident")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Ident) : source.OrderByDescending(z => z.Ident);

                if (columnName == "Origin")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Origin) : source.OrderByDescending(z => z.Origin);

                if (columnName == "BirthYearFrom")
                    return columnOrder == "asc" ? source.OrderBy(z => z.YearFrom) : source.OrderByDescending(z => z.YearFrom);

                if (columnName == "BirthYearTo")
                    return columnOrder == "asc" ? source.OrderBy(z => z.YearTo) : source.OrderByDescending(z => z.YearTo);

                if (columnName == "Location")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Location) : source.OrderByDescending(z => z.Location);

                if (columnName == "FirstName")
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
                if (columnName == "FirstName")
                    return columnOrder == "asc" ? source.OrderBy(z => z.FirstName) : source.OrderByDescending(z => z.FirstName);

                if (columnName == "Surname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Surname) : source.OrderByDescending(z => z.Surname);
              
                if (columnName == "Origin")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Origin) : source.OrderByDescending(z => z.Origin);

                if (columnName == "Location")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Location) : source.OrderByDescending(z => z.Location);



                if (columnName == "AltLat")
                    return columnOrder == "asc" ? source.OrderBy(z => z.AltLat) : source.OrderByDescending(z => z.AltLat);
              
                if (columnName == "AltLong")
                    return columnOrder == "asc" ? source.OrderBy(z => z.AltLong) : source.OrderByDescending(z => z.AltLong);

                if (columnName == "AltLocation")
                    return columnOrder == "asc" ? source.OrderBy(z => z.AltLocation) : source.OrderByDescending(z => z.AltLocation);

                if (columnName == "AltLocationDesc")
                    return columnOrder == "asc" ? source.OrderBy(z => z.AltLocationDesc) : source.OrderByDescending(z => z.AltLocationDesc);


            
                if (columnName == "YearFrom")
                    return columnOrder == "asc" ? source.OrderBy(z => z.YearFrom) : source.OrderByDescending(z => z.YearFrom);

                if (columnName == "YearTo")
                    return columnOrder == "asc" ? source.OrderBy(z => z.YearTo) : source.OrderByDescending(z => z.YearTo);


              
                if (columnName == "BirthLong")
                    return columnOrder == "asc" ? source.OrderBy(z => z.BirthLong) : source.OrderByDescending(z => z.BirthLong);

                if (columnName == "BirthLat")
                    return columnOrder == "asc" ? source.OrderBy(z => z.BirthLat) : source.OrderByDescending(z => z.BirthLat);

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
                if (columnName == "Surname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Surname) : source.OrderByDescending(z => z.Surname);

                if (columnName == "Location")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Location) : source.OrderByDescending(z => z.Location);

                if (columnName == "Memory")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Memory) : source.OrderByDescending(z => z.Memory);

                if (columnName == "Name")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Name) : source.OrderByDescending(z => z.Name);

                if (columnName == "RootsEntry")
                    return columnOrder == "asc" ? source.OrderBy(z => z.RootsEntry) : source.OrderByDescending(z => z.RootsEntry);

                if (columnName == "SharedCentimorgans")
                    return columnOrder == "asc" ? source.OrderBy(z => z.SharedCentimorgans) : source.OrderByDescending(z => z.SharedCentimorgans);

                if (columnName == "TestAdminDisplayName")
                    return columnOrder == "asc" ? source.OrderBy(z => z.TestAdminDisplayName) : source.OrderByDescending(z => z.TestAdminDisplayName);

                if (columnName == "TestDisplayName")
                    return columnOrder == "asc" ? source.OrderBy(z => z.TestDisplayName) : source.OrderByDescending(z => z.TestDisplayName);

                if (columnName == "TreeUrl")
                    return columnOrder == "asc" ? source.OrderBy(z => z.TreeUrl) : source.OrderByDescending(z => z.TreeUrl);

                if (columnName == "Year")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Year) : source.OrderByDescending(z => z.Year);

                
            }


            return source.OrderBy(o => o.Id);
        }


        public static IEnumerable<TreeRecord> TreeRecSortIf
         (this IQueryable<TreeRecord> source,
         string columnName,
         string columnOrder)
        {
            if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(columnOrder))
            {
                if (columnName == "CM")
                    return columnOrder == "asc" ? source.OrderBy(z => z.CM) : source.OrderByDescending(z => z.CM);

                if (columnName == "Located")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Located) : source.OrderByDescending(z => z.Located);

                if (columnName == "Name")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Name) : source.OrderByDescending(z => z.Name);

                if (columnName == "Origin")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Origin) : source.OrderByDescending(z => z.Origin);

              

            }


            return source.OrderBy(o => o.ID);
        }
    }


    public class DNAAnalyseService : IDNAAnalyseListService
    {

        private readonly HttpClient _client;
        private readonly string _apiKey;

        public DNAAnalyseService(HttpClient client, IConfiguration config)
        {
            _client = client;

        }


        public async Task<Results<Dupe>> DupeList(DNASearchParamObj searchParams)
        {
            var dupeList = new List<Dupe>();

            var results = new Results<Dupe>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext();
                 

                var unpaged = a.DupeEntries
                    .WhereIfSurname(searchParams.Surname)                    
                      .DupeSortIf(searchParams.SortColumn, searchParams.SortOrder);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    dupeList.Add(new Dupe()
                    {
                        Id = app.Id,                      
                        FirstName = app.FirstName ?? "",                       
                        Surname = app.Surname ?? "",
                        YearFrom = app.YearFrom,
                        YearTo = app.YearTo,
                        Ident = app.Ident ?? "",
                        Location = app.Location ?? "",
                        Origin = app.Origin ?? "",
                        PersonId = app.PersonId   

                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.results = dupeList;
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs / searchParams.Limit;
            results.total_results = totalRecs;

            return results;
        }

        public async Task<Results<FTMView>> FTMViewList(DNASearchParamObj searchParams)
        {
            var dupeList = new List<FTMView>();

            var results = new Results<FTMView>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext();



                var unpaged = a.FTMPersonView
                    .WhereIfSurname(searchParams.Surname)
                    .WhereIfLocation(searchParams.Location)
                    .WhereIfYearsBetween(searchParams.YearStart,searchParams.YearEnd)
                      .FTMViewSortIf(searchParams.SortColumn, searchParams.SortOrder);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    dupeList.Add(new FTMView()
                    {
                        Id = app.Id,
                        FirstName = app.FirstName ?? "",
                        Surname = app.Surname ?? "",
                        AltLocation = app.AltLocation,
                        AltLat = app.AltLat.GetValueOrDefault(),
                        AltLocationDesc = app.AltLocationDesc,
                        AltLong = app.AltLong.GetValueOrDefault(),
                        BirthFrom = app.YearFrom,
                        BirthTo = app.YearTo,
                        BirthLat = app.BirthLat.GetValueOrDefault(),
                        BirthLocation = app.Location,
                        BirthLong =app.BirthLong.GetValueOrDefault(),
                        Origin = app.Origin,
                        PersonId = app.PersonId
                       

                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.results = dupeList;
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs / searchParams.Limit;
            results.total_results = totalRecs;

            return results;
        }

        public async Task<Results<PersonOfInterestSubset>> PersonOfInterestList(DNASearchParamObj searchParams)
        {
            var dupeList = new List<PersonOfInterestSubset>();
            var results = new Results<PersonOfInterestSubset>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext();

                var unpaged = a.PersonsOfInterest
                    .WhereIfSurname(searchParams.Surname)
                    .WhereIfLocation(searchParams.Location)
                    .WhereIfMinCM(searchParams.MinCM)
                    .WhereIfYearBetween(searchParams.YearStart, searchParams.YearEnd)
                      .PersonOfInterestSortIf(searchParams.SortColumn, searchParams.SortOrder);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    dupeList.Add(new PersonOfInterestSubset()
                    {
                        Id = app.Id,
                        BirthCountry = app.BirthCountry ?? "",
                        BirthCounty = app.BirthCounty ?? "",
                        BirthPlace = app.Location ?? "",
                        BirthYear = app.Year,
                        ChristianName = app.ChristianName ?? "",
                        Confidence = app.Confidence,
                        CreatedDate = app.CreatedDate,
                        KitId = app.KitId,
                        Memory = app.Memory ?? "",
                        Name = app.Name ?? "",
                        RootsEntry = app.RootsEntry,
                        SharedCentimorgans = app.SharedCentimorgans,
                        TestAdminDisplayName = app.TestAdminDisplayName ?? "",
                        TestDisplayName = app.TestDisplayName ?? "",
                        TestGuid = app.TestGuid,
                        TreeUrl = app.TreeUrl ?? "",
                        Surname = app.Surname ?? "",
                     
                        PersonId = app.PersonId


                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.results = dupeList;
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs / searchParams.Limit;
            results.total_results = totalRecs;

            return results;
        }

        public async Task<Results<TreeRec>> TreeList(DNASearchParamObj searchParams)
        {
            var dupeList = new List<TreeRec>();
            var results = new Results<TreeRec>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext();

                var unpaged = a.TreeRecord.TreeRecSortIf(searchParams.SortColumn,searchParams.SortOrder);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    dupeList.Add(new TreeRec()
                    {
                        Id = app.ID,
                        CM = app.CM,
                        Located = app.Located,
                        Origin = app.Origin ?? "",
                        PersonCount = app.PersonCount,
                        Name = app.Name
                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.results = dupeList;
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs / searchParams.Limit;
            results.total_results = totalRecs;

            return results;
        }

    }
}