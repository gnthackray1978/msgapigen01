using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using GqlMovies.Api.Models;
using System.Security.Claims;

namespace GqlMovies.Api.Services
{

    public interface IClaimsListService
    {
        Task<MSGClaim> GetAsync(int id);

        Task<Results<MSGClaim>> ListAsync(Dictionary<string, string> input, ClaimsPrincipal user);
    }

    public interface ISiteListService
    {
        Task<Site> GetAsync(int id);

        Task<Results<Site>> ListAsync(Dictionary<string, string> input, ClaimsPrincipal user);
    }


}