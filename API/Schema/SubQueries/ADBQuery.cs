using System.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using MSGSharedData.Data.Services.interfaces.services;
using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.ADB;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;
using MSGSharedData.Domain.Enumerations;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class ADBQuery 
    { 
        public Task<Results<ADBMarriage>> marriagesearch(ADBMarriageParamObj pobj, 
            [Service] IADBRepository repository,
            [Service] IClaimRepository claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.ThackrayDB))
            {
                return ErrorHandler.Error<ADBMarriage>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.MarriageList(pobj);
        }

        public Task<Results<ADBPerson>> personsearch(ADBPersonParamObj pobj,
            [Service] IADBRepository repository,
            [Service] IClaimRepository claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.ThackrayDB))
            {
                return ErrorHandler.Error<ADBPerson>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.PersonList(pobj);
        }

        public Task<Results<ADBParish>> parishsearch(ADBParishParamObj pobj,
            [Service] IADBRepository repository,
            [Service] IClaimRepository claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.ThackrayDB))
            {
                return ErrorHandler.Error<ADBParish>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.ParishList(pobj);
        }

        public Task<Results<ADBSource>> sourcesearch(ADBSourceParamObj pobj,
            [Service] IADBRepository repository,
            [Service] IClaimRepository claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.ThackrayDB))
            {
                return ErrorHandler.Error<ADBSource>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.SourceList(pobj);
        }
         
    }
}
