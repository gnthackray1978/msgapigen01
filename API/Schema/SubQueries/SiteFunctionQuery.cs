using System.Security.Claims;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using MSGSharedData.Data.Services.interfaces.services;
using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.SiteMetaData;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class SiteFunctionQuery 
    {
        //public Task<SiteFunction> single([Service] IFunctionListRepositoryrepository, int id)
        //{
        //    return repository.GetAsync(id);
        //}

        public Task<Results<SiteFunction>> searchSiteFunction( [Service] IFunctionListRepository repository,
             ClaimsPrincipal currentUser, int? appId)
        {
            if (appId == null || appId == 0)
            {
                return repository.ListAsync(currentUser);
            }
            else
            {
                return repository.ListAsync(appId.Value, currentUser);
            }
        }
         
    }
}