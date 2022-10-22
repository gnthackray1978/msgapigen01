using System.Threading.Tasks;
using Api.Models;
using System.Security.Claims;
using Api.Schema;

namespace Api.Services.interfaces.services
{
    public interface IFunctionListService
    {
        Task<SiteFunction> GetAsync(int id);

        Task<Results<SiteFunction>> ListAsync(int applicationId, ClaimsPrincipal user);

        Task<Results<SiteFunction>> ListAsync(ClaimsPrincipal user);
    }

}
