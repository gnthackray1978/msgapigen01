using System.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;
using GqlMovies.Api.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace GqlMovies.Api.Services
{
    public class ClaimListService : IClaimsListService
    {
        private List<MSGClaim> _sites = new List<MSGClaim>();

        private readonly HttpClient _client;
        private readonly string _apiKey;

        public ClaimListService(HttpClient client, 
            IConfiguration config)
        {
            _client = client;        
        }

        public async Task<MSGClaim> GetAsync(int id)
        {

            return _sites.First(w => w.Id == id);

        }

        public async Task<Results<MSGClaim>> ListAsync(Dictionary<string, string> query,
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