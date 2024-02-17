
using System.Security.Claims;
using System.Security;
using Api.Types.DNAAnalyse;
using Api.Services;
using Api.Services.interfaces.services;
using Api.Types.RequestQueries;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class DNAQuery 
    {
        public Task<Results<Dupe>> dupesearch(DNASearchParamObj pobj, [Service] IDNAAnalyseListService repository,
            [Service] IClaimService claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.FamilyTreeAnalizer))
            {
                return ErrorHandler.Error<Dupe>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.DupeList(pobj);
        }

        public Task<Results<FTMPersonLocation>> ftmlocsearch(DNASearchParamObj pobj, [Service] IDNAAnalyseListService repository,
            [Service] IClaimService claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.FamilyTreeAnalizer))
            {
                return ErrorHandler.Error<FTMPersonLocation>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.FTMLocSearch(pobj);
        }

        public Task<Results<FTMLatLng>> ftmlatlngsearch(DNASearchParamObj pobj, [Service] IDNAAnalyseListService repository,
            [Service] IClaimService claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.FamilyTreeAnalizer))
            {
                return ErrorHandler.Error<FTMLatLng>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.FTMLatLngList(pobj);
        }

        public Task<Results<FTMView>> ftmviewsearch(DNASearchParamObj pobj, [Service] IDNAAnalyseListService repository,
            [Service] IClaimService claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.FamilyTreeAnalizer))
            {
                return ErrorHandler.Error<FTMView>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.FTMViewList(pobj);
        }

        public Task<Results<PersonOfInterestSubset>> poisearch(DNASearchParamObj pobj, [Service] IDNAAnalyseListService repository,
            [Service] IClaimService claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.FamilyTreeAnalizer))
            {
                return ErrorHandler.Error<PersonOfInterestSubset>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.PersonOfInterestList(pobj);
        }

        public Task<Results<TreeRec>> treerecsearch(DNASearchParamObj pobj, [Service] IDNAAnalyseListService repository,
            [Service] IClaimService claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.FamilyTreeAnalizer))
            {
                return ErrorHandler.Error<TreeRec>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.TreeList(pobj);
        }
         
    }
}
