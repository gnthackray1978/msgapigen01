﻿using System.Security.Claims;
using ConfigHelper;
using MSGSharedData.Data.Services.interfaces.services;
using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.SiteMetaData;

namespace MSGSharedData.Data.Services
{
    public class SiteFunctionRepository: IFunctionListRepository
    {
        private List<SiteFunction> _sites = new List<SiteFunction>();
        private readonly IMSGConfigHelper _imsConfigHelper;
        private readonly string _apiKey;

        public SiteFunctionRepository(IMSGConfigHelper imsConfigHelper)
        {
            _imsConfigHelper = imsConfigHelper;
        }

        public async Task<SiteFunction> GetAsync(int id)
        {
            var siteFunction = new SiteFunction();

            try
            {
                var a = new MSGCoreContext(_imsConfigHelper.MSGGenDB01);
                var pageList = a.MsgPages.ToList();
                var f = a.Msgfunctions.FirstOrDefault(fi => fi.Id == id);
                var page = pageList.FirstOrDefault(p => p.Id == f.Page);

                siteFunction = new SiteFunction()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description,
                    PageName = page.Name,
                    PageTitle = page.Title,
                    ApplicationId = f.ApplicationId.GetValueOrDefault()
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
                var a = new MSGCoreContext(_imsConfigHelper.MSGGenDB01);
                var pageList = a.MsgPages.ToList();
                var app = a.Msgfunctions.Where(fi => fi.ApplicationId == applicationId);


                foreach (var f in app)
                {
                    var page = pageList.FirstOrDefault(p => p.Id == f.Page);

                    var siteFunction = new SiteFunction()
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Description = f.Description,
                        PageName = page.Name,
                        PageTitle = page.Title,
                        ApplicationId = applicationId
                    };

                    _sites.Add(siteFunction);
                }

            }
            catch (Exception e)
            {
                results.Error = e.Message;
            }



            results.rows = _sites;
            results.Page = 0;
            results.total_pages = 1;
            results.total_rows = results.rows.Count();

            return results;
        }

        public async Task<Results<SiteFunction>> ListAsync(ClaimsPrincipal user)
        {
            var results = new Results<SiteFunction>();
            _sites = new List<SiteFunction>();
            try
            {
                var a = new MSGCoreContext(_imsConfigHelper.MSGGenDB01);
                var pageList = a.MsgPages.ToList();
                var app = a.Msgfunctions;

                foreach (var f in app)
                {
                    var page = pageList.FirstOrDefault(p => p.Id == f.Page);

                    var siteFunction = new SiteFunction()
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Description = f.Description,
                        PageName = page.Name,
                        PageTitle = page.Title,
                        ApplicationId = f.ApplicationId.GetValueOrDefault()
                    };

                    _sites.Add(siteFunction);
                }

            }
            catch (Exception e)
            {
                results.Error = e.Message;
            }



            results.rows = _sites;
            results.Page = 0;
            results.total_pages = 1;
            results.total_rows = results.rows.Count();

            return results;
        }

    }
}