using System.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;
using Api.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Api.Models;
using Api.Services.interfaces;
using Api.Types;
using AzureContext.Models;
using ConfigHelper;

namespace Api.Services
{
    public static class WillsLinqExtensions {
 
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
           
            return source.OrderBy(o=>o.Year);
            
        }
    }
        //
    public class WillListService : IWillListService
    {

        private readonly IMSGConfigHelper _imsConfigHelper;
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public WillListService(HttpClient client, IConfiguration config, IMSGConfigHelper imsConfigHelper)
        {
            _client = client;
            _imsConfigHelper = imsConfigHelper;
        }

        public async Task<Will> GetAsync(int id)
        {
            var will = new Will();

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var app = a.LincsWills.FirstOrDefault(fi => fi.Id == id);

                will = new Will()
                {
                    Id = app.Id,
                    Aliases = app.Aliases,
                    Collection = app.Collection,
                    DateString = app.DateString,
                    Description = app.Description,
                    FirstName = app.FirstName,
                    Occupation = app.Occupation,
                    Place = app.Place,
                    Reference = app.Reference,
                    Surname = app.Surname,
                    Typ = app.Typ.GetValueOrDefault(),
                    Url = app.Url,
                    Year = app.Year
                };

            }
            catch (Exception e)
            {
                will.Error = e.Message;
            }
            return will;
        }
 

        public async Task<Results<Will>> LincolnshireWillsList(WillSearchParamObj searchParams)
        {
            var _wills = new List<Will>();

            var results = new Results<Will>();

            int totalRecs = 0;

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                //searchParams.First

                Func< int, int, bool> validDates = (start, end) => {
                    if (start <= 0 && end <= 0) return false;
                    if (start > end) return false;

                    return true;
                    };

                var unpaged = a.LincsWills
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Surname), w => w.Surname.ToLower().Contains(searchParams.Surname))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Desc), w => w.Description.ToLower().Contains(searchParams.Desc))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.RefArg), w => w.Reference.ToLower().Contains(searchParams.RefArg))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Place), w => w.Place.ToLower().Contains(searchParams.Place))
                    .WhereIf(validDates(searchParams.YearStart, searchParams.YearEnd),
                            w => w.Year >= searchParams.YearStart && w.Year <= searchParams.YearEnd)
                    .SortIf(searchParams.SortColumn, searchParams.SortOrder);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {                 
                    _wills.Add(new Will()
                    {
                       Id = app.Id,
                       Aliases = app.Aliases ?? "",
                        Collection = app.Collection ?? "",
                        DateString = app.DateString ?? "",
                        Description = app.Description ?? "",
                        FirstName = app.FirstName ?? "",
                        Occupation = app.Occupation ?? "",
                       Place = app.Place ?? "",
                        Reference = app.Reference ?? "",
                        Surname = app.Surname ?? "",
                        Typ = app.Typ.GetValueOrDefault(),
                       Url = app.Url ?? "",
                        Year = app.Year
                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }


            results.LoginInfo = searchParams.Meta.LoginInfo;
            results.Error += Environment.NewLine + searchParams.Meta.Error;
            results.results = _wills;
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs/ searchParams.Limit;
            results.total_results = totalRecs;

            return results;
        }



        public async Task<Results<Will>> NorfolkWillsList(WillSearchParamObj searchParams)
        {
            var _wills = new List<Will>();

            var results = new Results<Will>();

            int totalRecs = 0;

            results.Error = "";

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                //searchParams.First

                Func<int, int, bool> validDates = (start, end) => {
                    if (start <= 0 && end <= 0) return false;
                    if (start > end) return false;

                    return true;
                };

                var unpaged = a.NorfolkWills
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Surname), w => w.Surname.ToLower().Contains(searchParams.Surname))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Desc), w => w.Description.ToLower().Contains(searchParams.Desc))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.RefArg), w => w.Reference.ToLower().Contains(searchParams.RefArg))
                    .WhereIf(!string.IsNullOrEmpty(searchParams.Place), w => w.Place.ToLower().Contains(searchParams.Place))
                    .WhereIf(validDates(searchParams.YearStart, searchParams.YearEnd),
                            w => w.Year >= searchParams.YearStart && w.Year <= searchParams.YearEnd)
                    .SortIf(searchParams.SortColumn, searchParams.SortOrder);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged.Skip(searchParams.Offset).Take(searchParams.Limit))
                {
                    _wills.Add(new Will()
                    {
                        Id = app.Id,
                        Aliases = app.Aliases ?? "",
                        Collection = app.Collection ?? "",
                        DateString = app.DateString ?? "",
                        Description = app.Description ?? "",
                        FirstName = app.FirstName ?? "",
                        Occupation = app.Occupation ?? "",
                        Place = app.Place ?? "",
                        Reference = app.Reference ?? "",
                        Surname = app.Surname ?? "",
                        Typ = app.Typ.GetValueOrDefault(),
                        Url = app.Url ?? "",
                        Year = app.Year
                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }

            

            results.results = _wills;
            results.LoginInfo = searchParams.Meta.LoginInfo;
            results.Error += Environment.NewLine + searchParams.Meta.Error;
            results.Page = searchParams.Offset == 0 ? 0 : searchParams.Offset / searchParams.Limit;
            results.total_pages = totalRecs / searchParams.Limit;
            results.total_results = totalRecs;

            return results;
        }


    }
}