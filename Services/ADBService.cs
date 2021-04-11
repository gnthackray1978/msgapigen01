using System;
using GqlMovies.Api.Models;
using System.Threading.Tasks;
using Api.Services.interfaces;
using Api.Types;
using Api.Types.ADB;
using Api.Models;
using System.Collections.Generic;
using System.Linq;
using AzureContext.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using ConfigHelper;

namespace GqlMovies.Api.Services
{
    public class ADBService : IADBService
    {
        private readonly IMSGConfigHelper _imsConfigHelper;
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public ADBService(HttpClient client, IConfiguration config, IMSGConfigHelper imsConfigHelper)
        {
            _client = client;
            _imsConfigHelper = imsConfigHelper;

        }


        public async Task<Results<ADBMarriage>> MarriageList(ADBMarriageParamObj searchParams)
        {
            var marriageList = new List<ADBMarriage>();

            var results = new Results<ADBMarriage>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var unpaged = a.Marriages.WhereIfMatchParticipants(searchParams.MaleSurname, searchParams.FemaleSurname)
                    .WhereIfLocation(searchParams.Location)
                    .WhereIfYearBetween(searchParams.YearStart, searchParams.YearEnd)
                    .MarriageSortIf(searchParams.SortColumn, searchParams.SortOrder);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    marriageList.Add(new ADBMarriage()
                    {
                        Id = app.Id,
                        Date = app.Date,
                        DateAdded = app.DateAdded,
                        DateLastEdit = app.DateLastEdit,
                        EventPriority = app.EventPriority,
                        FemaleBirthYear = app.FemaleBirthYear,
                        FemaleCname = app.FemaleCname,
                        FemaleInfo = app.FemaleInfo,
                        FemaleIsKnownWidow = app.FemaleIsKnownWidow,
                        FemaleLocation = app.FemaleLocation,
                        FemaleOccupation = app.FemaleOccupation,
                        FemaleSname = app.FemaleSname,
                        IsBanns = app.IsBanns,
                        IsLicence = app.IsLicence,
                        MaleBirthYear = app.MaleBirthYear,
                        MaleCname = app.MaleCname,
                        MaleInfo = app.MaleInfo,
                        MaleIsKnownWidower = app.MaleIsKnownWidower,
                        MaleLocation = app.MaleLocation,
                        MaleOccupation = app.MaleOccupation,
                        MaleSname = app.MaleSname,
                        MarriageCounty = app.MarriageCounty,
                        MarriageLocation = app.Location,
                        Source = app.Source,
                        TotalEvents = app.TotalEvents,
                        UniqueRef = app.UniqueRef,
                        Witness1 = app.Witness1,
                        Witness2 = app.Witness2,
                        Witness3 = app.Witness3,
                        Witness4 = app.Witness4
                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.results = marriageList;
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs / searchParams.Limit;
            results.total_results = totalRecs;

            return results;
        }

        public async Task<Results<ADBParish>> ParishList(ADBParishParamObj searchParams)
        {
            //column sort not needed

            var parishList = new List<ADBParish>();

            var results = new Results<ADBParish>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var unpaged = a.Parishs
                    .WhereIfMatchParishCounty(searchParams.County)
                    .WhereIfMatchParishName(searchParams.ParishName)
                    .OrderBy(o => o.Name);
                   
                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    parishList.Add(new ADBParish()
                    {
                        Id = app.Id,
                        ParentParish = app.ParentParish,
                        ParishCounty = app.County,
                        ParishEndYear = app.ParishEndYear,
                        ParishName = app.Name,
                        ParishNotes = app.ParishNotes,
                        ParishRegistersDeposited = app.ParishRegistersDeposited,
                        ParishStartYear = app.ParishStartYear,
                        ParishX = app.ParishX,
                        ParishY = app.ParishY


                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.results = parishList;
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs / searchParams.Limit;
            results.total_results = totalRecs;

            return results;
        }

        public async Task<Results<ADBPerson>> PersonList(ADBPersonParamObj searchParams)
        {
            //column sort not needed

            var parishList = new List<ADBPerson>();

            var results = new Results<ADBPerson>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var unpaged = a.Persons.WhereIfBirthCounty(searchParams.BirthCounty)
                    .WhereIfBirthLocation(searchParams.BirthLocation)
                    .WhereIfDeathCounty(searchParams.DeathCounty)
                    .WhereIfDeathLocation(searchParams.DeathLocation)
                    .WhereIfFatherChristianName(searchParams.FatherChristianName)
                    .WhereIfFatherOccupation(searchParams.FatherOccupation)
                    .WhereIfFatherSurname(searchParams.FatherSurname)
                    .WhereIfMotherChristianName(searchParams.MotherChristianName)
                    .WhereIfMotheSurname(searchParams.MotherSurname)
                    .WhereIfOccupation(searchParams.Occupation)
                    .WhereIfPersonWithinYears(searchParams.YearStart,searchParams.YearEnd)
                    .WhereIfSource(searchParams.Source)
                    .WhereIfSpouseName(searchParams.SpouseName)
                    .WhereIfSpouseSurname(searchParams.SpouseSurname)
                    .WhereIfSurname(searchParams.Surname)
                    .WhereIfFirstName(searchParams.FirstName)
                    .PersonSortIf(searchParams.SortColumn, searchParams.SortOrder);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    parishList.Add(new ADBPerson()
                    {
                        Id = app.Id,
                        BapInt = app.BapInt,
                        BaptismDateStr = app.BaptismDateStr,
                        BirthCounty = app.BirthCounty,
                        BirthDateStr = app.BirthDateStr,
                        BirthInt = app.BirthInt,
                        BirthLocation = app.BirthLocation,
                        ChristianName = app.ChristianName,
                        DateAdded = app.DateAdded,
                        DateLastEdit = app.DateLastEdit,
                        DeathCounty = app.DeathCounty,
                        DeathDateStr = app.DeathDateStr,
                        DeathInt = app.DeathInt,
                        DeathLocation = app.DeathLocation,
                        EstBirthYearInt = app.EstBirthYearInt,
                        EstDeathYearInt = app.EstDeathYearInt,
                        EventPriority = app.EventPriority,
                        FatherChristianName = app.FatherChristianName,
                        //FatherId = app.FatherId,
                        FatherOccupation = app.FatherOccupation,
                        FatherSurname = app.FatherSurname,
                        IsDeleted = app.IsDeleted,
                        IsEstBirth = app.IsEstBirth,
                        IsEstDeath = app.IsEstDeath,
                        IsMale = app.IsMale,
                        MotherChristianName = app.MotherChristianName,
                       // MotherId = app.MotherId,
                        MotherSurname = app.MotherSurname,
                        Notes = app.Notes,
                        Occupation = app.Occupation,
                        OrigFatherSurname = app.OrigFatherSurname,
                        OrigMotherSurname = app.OrigMotherSurname,
                        OrigSurname = app.OrigSurname,
                        ReferenceDateInt = app.ReferenceDateInt,
                        ReferenceDateStr = app.ReferenceDateStr,
                        ReferenceLocation = app.ReferenceLocation,
                        Source = app.Source,
                        SpouseName = app.SpouseName,
                        SpouseSurname = app.SpouseSurname,
                        Surname = app.Surname,
                        TotalEvents = app.TotalEvents,
                        UniqueRef   = app.UniqueRef

                    }); 
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.results = parishList;
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs / searchParams.Limit;
            results.total_results = totalRecs;

            return results;
        }

        public async Task<Results<ADBSource>> SourceList(ADBSourceParamObj searchParams)
        {
            var parishList = new List<ADBSource>();

            var results = new Results<ADBSource>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var unpaged = a.Sources.WhereIfLocation(searchParams.Location)
                    .WhereIfSourceRef(searchParams.SourceRef)
                    .WhereIfYearsBetween(searchParams.YearStart, searchParams.YearEnd)
                    .OrderBy(o => o.SourceRef);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    parishList.Add(new ADBSource()
                    {
                        Id = app.Id,
                        DateAdded = app.DateAdded,
                        IsCopyHeld = app.IsCopyHeld,
                        IsThackrayFound = app.IsThackrayFound,
                        IsViewed = app.IsViewed,
                        OriginalLocation = app.Location,
                        SourceDate = app.YearFrom,
                        SourceDateTo = app.YearTo,
                        SourceDateStr = app.SourceDateStr,
                        SourceDateStrTo = app.SourceDateStrTo,
                        SourceDescription = app.SourceDescription,
                        SourceFileCount = app.SourceFileCount,
                        SourceNotes = app.SourceNotes,
                        SourceRef = app.SourceRef,
                        UserId  = app.UserId


                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.results = parishList;
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs / searchParams.Limit;
            results.total_results = totalRecs;

            return results;
        }


        public async Task<Results<ADBInternalSourceType>> SourceTypeList(ADBSourceParamObj searchParams)
        {
            var parishList = new List<ADBInternalSourceType>();

            var results = new Results<ADBInternalSourceType>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var unpaged = a.SourceTypes.OrderBy(o => o.Id);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    parishList.Add(new ADBInternalSourceType()
                    {
                        Id = app.Id,
                        SourceDateAdded = app.SourceDateAdded,
                        SourceTypeDesc  = app.SourceTypeDesc


                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.results = parishList;
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs / searchParams.Limit;
            results.total_results = totalRecs;

            return results;
        }




        public async Task<Results<ADBParishData>> ParishDataList(int parishId)
        {
            var parishList = new List<ADBParishData>();

            var results = new Results<ADBParishData>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var unpaged = a.ParishTranscriptionDetails.Where(w=>w.ParishId == parishId);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged)
                {
                    parishList.Add(new ADBParishData()
                    {
                        Id = app.Id,
                        ParishDataString = app.ParishDataString,
                        ParishId = app.ParishId
                    });
                }
            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.results = parishList;
            results.Page = 0;
            results.total_pages = 1;
            results.total_results = totalRecs;

            return results;
        }
        public async Task<Results<ADBParishRec>> ParishRecList(int parishId)
        {
            var parishList = new List<ADBParishRec>();

            var results = new Results<ADBParishRec>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var unpaged = a.ParishRecords.Where(w => w.ParishId == parishId);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged)
                {
                    parishList.Add(new ADBParishRec()
                    {
                        Id = app.Id,
                        ParishId = app.ParishId,
                        DataTypeId = app.DataTypeId,
                        OriginalRegister = app.OriginalRegister,
                        RecordType = app.RecordType,
                        Year = app.Year,
                        YearEnd = app.YearEnd
                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.results = parishList;
            results.Page = 0;
            results.total_pages = 1;
            results.total_results = totalRecs;

            return results;
        }

        public Task<Results<ADBParishMap>> ParishSourceMappingsList(ADBParishParamObj aDBParishParamObj)
        {
            throw new NotImplementedException();
        }

        public Task<Results<ADBRecSource>> RecSourceList(ADBSourceParamObj aDBSourceParamObj)
        {
            throw new NotImplementedException();
        }



        public Task<Results<ADBSourceMap>> SourceMapList(ADBSourceParamObj aDBSourceParamObj)
        {
            throw new NotImplementedException();
        }


    }
}