using System.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;
using GqlMovies.Api.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.WebUtilities;
using GqlMovies.Api.Types;
using System.Security.Claims;
using Api.Models;
using ConfigHelper;

namespace GqlMovies.Api.Services
{

    public class SiteListService  : ISiteListService
    {

        private readonly IMSGConfigHelper _imsConfigHelper;
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public SiteListService(HttpClient client, IConfiguration config, IMSGConfigHelper imsConfigHelper)
        {
            _client = client;
            _imsConfigHelper = imsConfigHelper;
        }

        public async Task<Site> GetAsync(int id)
        {
            var site = new Site();

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var pageList = a.MsgPages.ToList();

                var app = a.Msgapplications.FirstOrDefault(fi => fi.Id == id);

                var page = pageList.FirstOrDefault(p => p.Id == app.DefaultPage);

                site = new Site()
                {
                    Id = app.Id,
                    Name = app.ApplicationName,
                    Description = app.Description,
                    DefaultPageName = page.Name,
                    DefaultPageTitle = page.Title

                };

            }
            catch (Exception e)
            {
                site.Error = e.Message;                
            }



            return site;

        }
 
        public async Task<Results<Site>> ListAsync(Dictionary<string, string> query,
            ClaimsPrincipal user)
        {
            List<Site> _sites = new List<Site>();

            var results = new Results<Site>();

            try
            {
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);
                var pageList = a.MsgPages.ToList();

                foreach (var app in a.Msgapplications)
                {
                    var page = pageList.FirstOrDefault(p => p.Id == app.DefaultPage);

                    _sites.Add(new Site()
                    {
                        Id = app.Id,
                        Name = app.ApplicationName,
                        Description = app.Description,
                        DefaultPageName = page.Name,
                        DefaultPageTitle = page.Title
                    });
                }


            }
            catch (Exception e) {

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