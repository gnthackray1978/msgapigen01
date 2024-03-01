using System.Security.Claims;
using System.Security;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using MSGSharedData.Data.Services.interfaces.services;
using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.Images;
using MSGSharedData.Domain.Enumerations;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class ImageQuery  
    {
        public Task<Results<ApiImage>> imagesearch(string page, [Service] IPhotoListRepository repository,
            [Service] IClaimRepository claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.FamilyHistoryPhotos))
            {
                return ErrorHandler.Error<ApiImage>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.ImagesList("",page);
        }

        public Task<Results<ApiParentImages>> imageparentsearch(string page, [Service] IPhotoListRepository repository,
            [Service] IClaimRepository claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.FamilyHistoryPhotos))
            {
                return ErrorHandler.Error<ApiParentImages>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.ParentImagesList("", page);
        }
        
    }
}