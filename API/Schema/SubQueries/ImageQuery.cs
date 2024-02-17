using Api.Models;
using System.Security.Claims;
using System.Security;
using System.Threading.Tasks;
using Api.Services;
using Api.Types.Images;
using Api.Services.interfaces.services;
using HotChocolate;
using HotChocolate.Types;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class ImageQuery  
    {
        public Task<Results<ApiImage>> imagesearch(string page, [Service] IPhotoListService repository,
            [Service] IClaimService claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.FamilyHistoryPhotos))
            {
                return ErrorHandler.Error<ApiImage>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.ImagesList("",page);
        }

        public Task<Results<ApiParentImages>> imageparentsearch(string page, [Service] IPhotoListService repository,
            [Service] IClaimService claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.FamilyHistoryPhotos))
            {
                return ErrorHandler.Error<ApiParentImages>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.ParentImagesList("", page);
        }
        
    }
}