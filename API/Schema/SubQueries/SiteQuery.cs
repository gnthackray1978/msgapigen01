using Api.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Services.interfaces.services;
using Api.Types.RequestQueries;
using HotChocolate;
using HotChocolate.Types;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class SiteQuery 
    {
        //public Task<Site> single([Service] ISiteListService repository, int id)
        //{
        //    return repository.GetSite(id);
        //}

        public Task<Results<Site>> searchSite([Service] ISiteListService repository,
            ClaimsPrincipal currentUser, int? appId)
        {
            var siteParamObj = new SiteParamObj
            {
                GroupId = 1 // todo fix this.
            };

            return repository.ListSites(siteParamObj);
        }

        //public SiteQuery(ISiteListService service, IClaimService claimService)
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