using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.Images;

namespace MSGSharedData.Data.Services.interfaces.services
{
    public interface IPhotoListRepository
    {


        Task<Results<ApiImage>> ImagesList(string user, string page);

        Task<Results<ApiParentImages>> ParentImagesList(string user, string page);

    }

}
