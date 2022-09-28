using Api.Models;
using Api.Schema;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IClaimService 
    {
        Task<MSGClaim> GetClaim(int id);

        int GetUserGroupId(ClaimsPrincipal user, int defaultGroupId);

        bool UserValid(ClaimsPrincipal user, MSGApplications mSGApplications);

        string GetClaimDebugString(ClaimsPrincipal user);

        Task<Results<MSGClaim>> ListUserClaims(Dictionary<string, string> input, ClaimsPrincipal user);
    }


}