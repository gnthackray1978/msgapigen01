using Api.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security;
using Api.Services.interfaces.services;
using System.Threading.Tasks;
using Api.Services;
using HotChocolate;
using HotChocolate.Types;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class ClaimQuery
    {
        //public Task<MSGClaim> single(int id, [Service] IClaimService repository,
        //    [Service] IClaimService claimService)
        //{
        //    return repository.GetClaim(id);
        //}

        public Task<Results<MSGClaim>> searchClaims([Service] IClaimService claimService, ClaimsPrincipal currentUser)
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