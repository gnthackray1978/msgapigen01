using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.Auth;
using MSGSharedData.Domain.Enumerations;
using System.Security.Claims;

namespace MSGSharedData.Data.Services.interfaces.services
{
    public interface IClaimRepository
    {
        Task<MSGClaim> GetClaim(int id);

        int GetUserGroupId(ClaimsPrincipal user, int defaultGroupId);

        bool UserValid(ClaimsPrincipal user, MSGApplications mSGApplications);

        string GetClaimDebugString(ClaimsPrincipal user);

        Task<Results<MSGClaim>> ListUserClaims(Dictionary<string, string> input, ClaimsPrincipal user);
    }


}