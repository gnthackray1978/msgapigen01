using System.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;
using Api.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;
using Api.DB;
using ConfigHelper;
using Api.Schema;
using Api.Types.RequestQueries;
using Api.Services.interfaces.services;

namespace Api.Services
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

        public async Task<Site> GetSite(int id)
        {
            var site = new Site();

            try
            {
                var a = new MSGCoreContext(_imsConfigHelper.MSGGenDB01);

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
 
        public async Task<Results<Site>> ListSites(SiteParamObj siteParamObj)
        {
            List<Site> _sites = new List<Site>();

            var results = new Results<Site>();

            try
            {
                var a = new MSGCoreContext(_imsConfigHelper.MSGGenDB01);
                var pageList = a.MsgPages.ToList();



                //filter application by group id
                var validAppList = a.MsgapplicationMapGroup.Where(w => w.GroupId == siteParamObj.GroupId).Select(s=>s.ApplicationId).ToList();



                foreach (var app in a.Msgapplications)
                {
                    if (validAppList.Contains(app.Id))
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