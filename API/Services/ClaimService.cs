using System.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;
using Api.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using ConfigHelper;
using Api.Models;

namespace Api.Services
{
    public enum MSGApplications
    {
        FrontPage = 1,
        Diagrams=2,
        ThackrayDB=4,
        MapOverview= 6,
        FamilyTreeAnalizer=7,
        FamilyHistoryPhotos=8,
        Wills =9
    }

    public class ClaimService : IClaimService
    {
        private List<MSGClaim> _sites = new List<MSGClaim>();
        private readonly IMSGConfigHelper _imsConfigHelper;
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public ClaimService(HttpClient client, 
            IConfiguration config, IMSGConfigHelper imsConfigHelper)
        {
            _imsConfigHelper = imsConfigHelper;
            _client = client;        
        }

        public async Task<MSGClaim> GetClaim(int id)
        {

            return _sites.First(w => w.Id == id);

        }

        public bool UserValid(ClaimsPrincipal user, MSGApplications mSGApplications) {

            int groupId = 2;// if we dont have a user default to this group.

            //1   Front Page  0
            //2   Diagrams    0   Diagram creation
            //4   Thackray DB 0   Thackray surname DB
            //6   Map Overview    0   Info plotted on google maps
            //7   Family Tree Analizer    0   FTM data
            //8   Family History Photos   0   Old pictures
            //9   Wills   0   Wills DB

            //for testing purposes!!!
            if (mSGApplications == MSGApplications.Diagrams)
                return true;


            int value = (int)mSGApplications;

            try
            {
             



                int idx = 0;
                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                if (user != null)
                {
                    string userId = "";

                    foreach (var n in user.Claims)
                    {
                        if (n.Type.Contains("email"))
                        {
                            userId = n.Value;
                        }
                    }
                    var group = a.MsggroupMapUser.FirstOrDefault(fd => fd.UserId == userId);

                    if (group != null)
                    {
                        groupId = group.GroupId.GetValueOrDefault();
                    }
                }


                //applications in group
                var appList = a.MsgapplicationMapGroup.Where(w => w.GroupId == groupId)
                    .Select(s=>s.ApplicationId).ToList();

                if (appList.Contains(value))
                    return true;
            }
            catch (Exception e)
            {
                throw e;
            }





            return false;
        }

        public int GetUserGroupId(ClaimsPrincipal user, int defaultGroupId) 
        {
            int groupId = defaultGroupId;  

            try
            {
                int idx = 0;
                string userId = "";

                foreach (var n in user.Claims)
                {
                    if (n.Type.Contains("email")) {
                        userId = n.Value;
                    }                    
                }

                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var group = a.MsggroupMapUser.FirstOrDefault(fd => fd.UserId == userId);

                if (group != null) {
                    groupId = group.GroupId.GetValueOrDefault();
                }

            }
            catch (Exception e)
            {
                throw e;
            }

       
            return groupId;
        }
        public string GetClaimDebugString(ClaimsPrincipal user) {

            string nameList = "No User";

            if (user != null)
            {
                foreach (var n in user.Identities)
                {
                    nameList += n.Name + Environment.NewLine;
                }

                foreach (var n in user.Claims)
                {
                    nameList += n.Type + " " + n.Value + Environment.NewLine;
                }

            }

            return nameList;
        }


        public async Task<Results<MSGClaim>> ListUserClaims(Dictionary<string, string> query,
            ClaimsPrincipal user)
        {
            var results = new Results<MSGClaim>();
             
            try
            {
                int idx = 0;

                foreach (var c in user.Claims)
                {
                    _sites.Add(new MSGClaim() { 
                        Id = idx,
                        Type = c.Type,
                        Name = c.Issuer,
                        Subject = c.Subject?.Name,
                        Value = c.Value
                    });
                     
                }
            }
            catch (Exception e)
            {
                throw e;
            }
              
            results.results = _sites;
            results.Page = 0;
            results.total_pages = 1;
            results.total_results = results.results.Count();

            return results;
        }
    }
}