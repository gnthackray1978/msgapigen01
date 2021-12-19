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
using ConfigHelper;

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
                columnName = columnName.ToLower();

                if (columnName == "surname")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Surname) : source.OrderByDescending(z => z.Surname);

                if (columnName == "ident")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Ident) : source.OrderByDescending(z => z.Ident);

                if (columnName == "origin")
                    return columnOrder == "asc" ? source.OrderBy(z => z.Origin) : source.OrderByDescending(z => z.Origin);

                if (columnName == "birthyearfrom")
                    return columnOrder == "asc" ? source.OrderBy(z => z.YearFrom) : source.OrderByDescending(z => z.YearFrom);

                if (columnName == "birthyearto")
                    return columnOrder == "asc" ? source.OrderBy(z => z.YearTo) : source.OrderByDescending(z => z.YearTo);

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


            
                if (columnName == "yearfrom")
                    return columnOrder == "asc" ? source.OrderBy(z => z.YearFrom) : source.OrderByDescending(z => z.YearFrom);

                if (columnName == "yeato")
                    return columnOrder == "asc" ? source.OrderBy(z => z.YearTo) : source.OrderByDescending(z => z.YearTo);


              
                if (columnName == "birthlong")
                    return columnOrder == "asc" ? source.OrderBy(z => z.BirthLong) : source.OrderByDescending(z => z.BirthLong);

                if (columnName == "birthlat")
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


    public class DNAAnalyseService : IDNAAnalyseListService
    {
        private readonly IMSGConfigHelper _imsConfigHelper;
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public DNAAnalyseService(HttpClient client, IConfiguration config, IMSGConfigHelper imsConfigHelper)
        {
            _client = client;
            _imsConfigHelper = imsConfigHelper;
        }

        public async Task<Results<FTMLatLng>> FTMLatLngList(DNASearchParamObj searchParams) {

            var dupeList = new List<FTMLatLng>();

            var results = new Results<FTMLatLng>();

            int totalRecs = 0;

            results.Error = "none";

            try
            {
                dupeList = AzureDBContext.ListLatLongs(_imsConfigHelper.MSGGenDB01, searchParams.YearStart, searchParams.YearEnd);
                 
            }
            catch (Exception e)
            {
                results.Error = e.Message;
            }

            results.LoginInfo = _imsConfigHelper.Check();
            results.results = dupeList;
            results.Page = 0;
            results.total_pages = totalRecs;
            results.total_results = dupeList.Count();

            return results;
        }

        public async Task<Results<Dupe>> DupeList(DNASearchParamObj searchParams)
        {
            var dupeList = new List<Dupe>();

            var results = new Results<Dupe>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);


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

        public async Task<Results<FTMPersonLocation>> FTMLocSearch(DNASearchParamObj searchParams)
        {
            var dupeList = new List<FTMPersonLocation>();

            var results = new Results<FTMPersonLocation>();

            Func<double?, double?, string> mergeDoublesToString = ( m,  a) => {
                
                if (a.Value == 0 && m.Value != 0)
                    return m.ToString();
                
                return a.ToString();
            };

            Func<double?, double?, double> mergeDoubles = (m, a) => {

                if (a.Value == 0 && m.Value != 0)
                    return m.Value;

                return a.Value;
            };

            Func<string, string, string> mergeLocations = (m, a) => {

                if (!string.IsNullOrEmpty(m) && string.IsNullOrEmpty(a))
                    return m.ToString();

                return a ?? "";
            };

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);



                var unpaged = a.FTMPersonView.Where(w => w.Surname != "")
                    .WhereIfOrigin(searchParams.Origin)
                    .WhereIfSurname(searchParams.Surname)
                    .WhereIfLocation(searchParams.Location)
                    .WhereIfYearsBetween(searchParams.YearStart, searchParams.YearEnd).Select(s =>
                    new
                    {
                        s.AltLat,
                        s.AltLong,
                        s.BirthLat,
                        s.BirthLong,
                        blongStr = mergeDoublesToString(s.BirthLong,s.AltLong),
                        blatStr = mergeDoublesToString(s.BirthLat, s.AltLat),
                        s.FirstName,
                        s.Id,
                        locat = mergeLocations(s.Location,s.AltLocation),
                        s.Origin,
                        s.PersonId,
                        s.Surname,
                        s.YearFrom,
                        s.YearTo
                    }).ToList();

                totalRecs = unpaged.Count();
                int id = 0;

                foreach (var app in unpaged.GroupBy(x => new { x.blongStr, x.blatStr }))
                {
                    var personList = new List<FTMPersonSummary>();
                    double blat = 0;
                    double blong = 0;
                    string location = "xx";

                    foreach(var person in app)
                    {
                        personList.Add(new FTMPersonSummary()
                        {
                            FirstName = person.FirstName,
                            Surname = person.Surname,
                            TreeName = person.Origin,
                            Id = person.Id,
                            YearFrom = person.YearFrom,
                            YearTo = person.YearTo
                        });

                        blat = mergeDoubles(person.BirthLat, person.AltLat);
                        blong = mergeDoubles(person.BirthLong, person.AltLong);
                        location = person.locat;
                    }


                    dupeList.Add(new FTMPersonLocation()
                    {
                        BirthLat = blat,
                        BirthLong = blong,
                        LocationName = location.Replace("England", "").Replace('/',' ').Trim(),
                        FTMPersonSummary = personList.OrderBy(o => o.TreeName).ToList(),
                        Id = id

                    }); ;

                    id++;
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.results = dupeList;
            results.Page = 0;
            results.total_pages = 1;
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
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);



                var unpaged = a.FTMPersonView.Where(w=>w.Surname!="")
                    .WhereIfOrigin(searchParams.Origin)
                    .WhereIfSurname(searchParams.Surname)
                    
                    .WhereIfYearsBetween(searchParams.YearStart,searchParams.YearEnd)
                    .WhereIfLocationPrecise(searchParams.Location)
                      .FTMViewSortIf(searchParams.SortColumn, searchParams.SortOrder)
                      ;

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    dupeList.Add(new FTMView()
                    {
                        Id = app.Id,
                        FirstName = app.FirstName ?? "",
                        Surname = app.Surname ?? "",
                        AltLocation = app.AltLocation ?? "",
                        AltLat = app.AltLat,
                        AltLocationDesc = app.AltLocationDesc ?? "",
                        AltLong = app.AltLong,
                        YearFrom = app.YearFrom,
                        YearTo = app.YearTo,
                        BirthLat = app.BirthLat,
                        Location = app.Location ?? "",
                        BirthLong =app.BirthLong,
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

        public async Task<Results<FTMView>> FTMViewPlaces(DNASearchParamObj searchParams)
        {
            var dupeList = new List<FTMView>();

            var results = new Results<FTMView>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);



                var unpaged = a.FTMPersonView.WhereIfOrigin(searchParams.Origin)
                    .WhereIfYearsBetween(searchParams.YearStart, searchParams.YearEnd);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    dupeList.Add(new FTMView()
                    {
                        Id = app.Id,
                        FirstName = app.FirstName ?? "",
                        Surname = app.Surname ?? "",
                        AltLocation = app.AltLocation ?? "",
                        AltLat = app.AltLat,
                        AltLocationDesc = app.AltLocationDesc ?? "",
                        AltLong = app.AltLong,
                        YearFrom = app.YearFrom,
                        YearTo = app.YearTo,
                        BirthLat = app.BirthLat,
                        Location = app.Location ?? "",
                        BirthLong = app.BirthLong,
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

        public async Task<Results<PersonOfInterestSubset>> PersonOfInterestList(DNASearchParamObj searchParams)
        {
            var dupeList = new List<PersonOfInterestSubset>();
            var results = new Results<PersonOfInterestSubset>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var unpaged = a.PersonsOfInterest
                    .WhereIfTesterName(searchParams.Name)
                    .WhereIfSurnameBegins(searchParams.Surname)
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
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var unpaged = a.TreeRecord.WhereIfOrigin(searchParams.Origin)
                    .WhereIfGroupId(searchParams.GroupNumber)
                    .TreeRecSortIf(searchParams.SortColumn,searchParams.SortOrder);

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
                        GroupNumber = app.GroupNumber,
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