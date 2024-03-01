using System.Collections.Generic;
using System.Security.Claims;
using System.Security;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using MSGSharedData.Data.Services.interfaces.services;
using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.Auth;
using MSGSharedData.Domain.Enumerations;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class ClaimQuery
    {
        //public Task<MSGClaim> single(int id, [Service] IClaimRepositoryrepository,
        //    [Service] IClaimRepository claimService)
        //{
        //    return repository.GetClaim(id);
        //}

        public Task<Results<MSGClaim>> searchClaims([Service] IClaimRepository claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.UserLookup))
            {
                return ErrorHandler.Error<MSGClaim>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            var obj = new Dictionary<string, string>();

            return claimService.ListUserClaims(obj, currentUser);
        }
         
    }
}