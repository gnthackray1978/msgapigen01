using System.Security.Claims;
using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.SiteMetaData;

namespace MSGSharedData.Data.Services.interfaces.services
{
    public interface IFunctionListRepository
    {
        Task<SiteFunction> GetAsync(int id);

        Task<Results<SiteFunction>> ListAsync(int applicationId, ClaimsPrincipal user);

        Task<Results<SiteFunction>> ListAsync(ClaimsPrincipal user);
    }

}
