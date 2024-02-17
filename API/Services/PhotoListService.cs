using System.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;
using Api.Models;
using System.Threading.Tasks;
using Api.DB;
using Microsoft.Extensions.Configuration;
using ConfigHelper;
using Api.Types.Images;
using Api.Schema;
using Api.Services.interfaces.services;

namespace Api.Services
{
    public class PhotoListService : IPhotoListService
    {
        private readonly IMSGConfigHelper _imsConfigHelper;
        private readonly string _apiKey;

        public PhotoListService(IMSGConfigHelper imsConfigHelper)
        {
             _imsConfigHelper = imsConfigHelper;
        }
         
        public async Task<Results<ApiImage>> ImagesList(string user, string page)
        {
            var _apiImages = new List<ApiImage>();

            var results = new Results<ApiImage>();

            int totalRecs = 0;

            try
            {
                var a = new TDBContext(_imsConfigHelper.MSGGenDB01);


                var parents = a.ImageParents.Where(w => w.Page == page).Select(s=>s.Id).ToList();

                var unpaged = a.Images.Where(x=>parents.Contains(x.ParentImageId));

                totalRecs = unpaged.Count();

                foreach (var app in unpaged)
                {
                    _apiImages.Add(new ApiImage()
                    {
                        Id = app.Id,                      
                        Path = app.Path,
                        Title = app.Title,
                        Info = app.Info,
                        ParentImageId = app.ParentImageId,
                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }

            results.rows = _apiImages;
            results.Page = 0;
            results.total_pages = 1;
            results.total_rows = totalRecs;

            return results;
        }
        
        public async Task<Results<ApiParentImages>> ParentImagesList(string user, string page)
        {
            var _wills = new List<ApiParentImages>();

            var results = new Results<ApiParentImages>();

            int totalRecs = 0;

            results.Error = "";

            try
            {
                var a = new TDBContext(_imsConfigHelper.MSGGenDB01);


                var unpaged = a.ImageParents.Where(w=>w.Page == page);

                totalRecs = unpaged.Count();

                foreach (var app in unpaged)
                {
                    _wills.Add(new ApiParentImages()
                    {
                        Id = app.Id, 
                        Title = app.Title,
                        Info = app.Info, 
                        From = app.From,
                        Page = app.Page,
                        To = app.To

                    });
                }


            }
            catch (Exception e)
            {

                results.Error = e.Message;
            }



            results.rows = _wills; 
            results.Error += results.Error;
            results.Page = 0;
            results.total_pages = 1;
            results.total_rows = totalRecs;

            return results;
        }
    }
}