using GqlMovies.Api.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GqlMovies.Api.Services
{ 
    public interface IClaimService 
    {
        Task<MSGClaim> GetClaim(int id);

        int GetUserGroupId(ClaimsPrincipal user);

        bool UserValid(ClaimsPrincipal user, MSGApplications mSGApplications);

        string GetClaimDebugString(ClaimsPrincipal user);

        Task<Results<MSGClaim>> ListUserClaims(Dictionary<string, string> input, ClaimsPrincipal user);
    }


}