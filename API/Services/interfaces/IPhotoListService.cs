using Api.Types.Images;
using Api.Models;
using System.Threading.Tasks;

namespace Api.Services.interfaces
{
    public interface IPhotoListService
    {


        Task<Results<ApiImage>> ImagesList(string user, string page);

        Task<Results<ApiParentImages>> ParentImagesList(string user, string page);

    }

}
