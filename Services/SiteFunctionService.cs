using System.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;
using GqlMovies.Api.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Api.Models;

namespace GqlMovies.Api.Services
{
    public class SiteFunctionService : IFunctionListService
    {
        private List<SiteFunction> _sites = new List<SiteFunction>();

        private readonly HttpClient _client;
        private readonly string _apiKey;

        public SiteFunctionService(HttpClient client,
            IConfiguration config)
        {
            _client = client;
        }
  
        public async Task<SiteFunction> GetAsync(int id)
        {
            var siteFunction = new SiteFunction();

            try
            {
                var a = new AzureDBContext();

                var f = a.Msgfunctions.FirstOrDefault(fi => fi.Id == id);

                siteFunction = new SiteFunction()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description,
                    PageName = f.PageName
                }; 
            }
            catch (Exception e)
            {
                siteFunction.Error = e.Message;
            }

            return siteFunction;
        }

        public async Task<Results<SiteFunction>> ListAsync(int applicationId, ClaimsPrincipal user)
        {
            var results = new Results<SiteFunction>();
            _sites = new List<SiteFunction>();
            try
            {
                var a = new AzureDBContext();

                var app = a.Msgfunctions.Where(fi => fi.ApplicationId == applicationId);

                foreach (var f in app)
                {
                    var siteFunction = new SiteFunction()
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Description = f.Description,
                        PageName = f.PageName
                    };

                    _sites.Add(siteFunction);
                }

            }
            catch (Exception e)
            {
                results.Error = e.Message;
            }

             
            
            results.results = _sites;
            results.Page = 0;
            results.total_pages = 1;
            results.total_results = results.results.Count();

            return results;
        }

        public async Task<Results<SiteFunction>> ListAsync(ClaimsPrincipal user)
        {
            var results = new Results<SiteFunction>();
            _sites = new List<SiteFunction>();
            try
            {
                var a = new AzureDBContext();

                var app = a.Msgfunctions;

                foreach (var f in app)
                {
                    var siteFunction = new SiteFunction()
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Description = f.Description,
                        PageName = f.PageName
                    };

                    _sites.Add(siteFunction);
                }

            }
            catch (Exception e)
            {
                results.Error = e.Message;
            }



            results.results = _sites;
            results.Page = 0;
            results.total_pages = 1;
            results.total_results = results.results.Count();

            return results;
        }

    }
}