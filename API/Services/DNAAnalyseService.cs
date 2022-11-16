using Api.Types.DNAAnalyse;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using ConfigHelper;
using Api.DB;
using Api.Schema;
using Api.Types.RequestQueries;
using Api.Services.interfaces.services;
using Api.Services.Helpers;

namespace Api.Services
{
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
                var a = new DNAContext(_imsConfigHelper.MSGGenDB01);


                var treeDictionary = a.TreeRecord.ToDictionary(p => p.ID, p => p.Name);

                treeDictionary.Add(0, "Unknown");

                searchParams.Groupings = a.TreeRecordMapGroup.ToList();

                dupeList = DNAContext.ListLatLongs(_imsConfigHelper.MSGGenDB01, searchParams);
                 
            }
            catch (Exception e)
            {
                results.Error = e.Message;
            }

            results.LoginInfo = "";
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
                var a = new DNAContext(_imsConfigHelper.MSGGenDB01);


                var unpaged = a.DupeEntries
                    .WhereIfSurname(searchParams)                    
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
                var a = new DNAContext(_imsConfigHelper.MSGGenDB01);


                var treeDictionary = a.TreeRecord.ToDictionary(p => p.ID, p => p.Name);

                treeDictionary.Add(0, "Unknown");

                searchParams.Groupings = a.TreeRecordMapGroup.ToList();

                 var unpaged = a.FTMPersonView.Where(w => w.Surname != "")
                    .WhereIfOrigin(searchParams)
                    .WhereIfSurname(searchParams)
                    .WhereIfLocation(searchParams)
                    .WhereIfYearsBetween(searchParams).Select(s =>
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
                            TreeName = treeDictionary[person.Origin],
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
                var a = new DNAContext(_imsConfigHelper.MSGGenDB01);

                searchParams.Groupings = a.TreeRecordMapGroup.ToList();

                var treeDictionary = a.TreeRecord.ToDictionary(p => p.ID, p => p.Name);
                
                treeDictionary.Add(0,"Unknown");

                var unpaged = a.FTMPersonView.Where(w=>w.Surname!="")
                    .WhereIfOrigin(searchParams)
                    .WhereIfSurname(searchParams)
                    .WhereIfYearsBetween(searchParams)
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
                        Origin = treeDictionary[app.Origin],
                        PersonId = app.PersonId.GetValueOrDefault(),
                        DirectAncestor = app.DirectAncestor

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
                var a = new DNAContext(_imsConfigHelper.MSGGenDB01);

                var treeDictionary = a.TreeRecord.ToDictionary(p => p.ID, p => p.Name);

                treeDictionary.Add(0, "Unknown");

                var unpaged = a.FTMPersonView.WhereIfOrigin(searchParams)
                    .WhereIfYearsBetween(searchParams);

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
                        Origin = treeDictionary[app.Origin],
                        PersonId = app.PersonId.GetValueOrDefault(),
                        DirectAncestor = app.DirectAncestor

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
                var a = new DNAContext(_imsConfigHelper.MSGGenDB01);

                var unpaged = a.PersonsOfInterest
                    .WhereIfTesterName(searchParams)
                    .WhereIfSurnameBegins(searchParams)
                    .WhereIfLocation(searchParams)
                    .WhereIfMinCM(searchParams)
                    .WhereIfYearBetween(searchParams)
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
                var a = new DNAContext(_imsConfigHelper.MSGGenDB01);

                var unpaged = a.TreeRecord.WhereIfName(searchParams.Name)
                  
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