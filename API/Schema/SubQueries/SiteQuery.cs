using System.Security.Claims;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using MSGSharedData.Data.Services.interfaces.services;
using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;
using MSGSharedData.Domain.Entities.NonPersistent.SiteMetaData;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class SiteQuery 
    {
        //public Task<Site> single([Service] ISiteListRepositoryrepository, int id)
        //{
        //    return repository.GetSite(id);
        //}

        public Task<Results<Site>> searchSite([Service] ISiteListRepository repository,
            ClaimsPrincipal currentUser, int? appId)
        {
            var siteParamObj = new SiteParamObj
            {
                GroupId = 1 // todo fix this.
            };

            return repository.ListSites(siteParamObj);
        }

        //public SiteQuery(ISiteListRepositoryservice, IClaimRepositoryclaimService)
        //{
        //    Name = "Site";
            
            

        //    Field<SiteResultType<SiteType, Site>, Results<Site>>("search")
        //        .Arguments(new QueryArguments(
        //            new QueryArgument<StringGraphType> { Name = "query" },
        //            new QueryArgument<StringGraphType> { Name = "page" }
        //        ))
        //        .ResolveAsync(context =>
        //        {
        //            var u = context.GetUser(claimService);
                    
        //            var siteParamObj = new SiteParamObj
        //            {
        //                GroupId = u.GroupId
        //            };

        //            var tp = service.ListSites(siteParamObj);

        //            tp.Result.Error += u.UpdateError(tp.Result.Error);

        //            return tp;
        //        });

        //}
    }
}