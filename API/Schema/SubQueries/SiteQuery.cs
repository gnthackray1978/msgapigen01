using Api.Models;
using Api.Types;
using GraphQL.Types;
using System.Collections.Generic;
using System.Reflection;
using GraphQL;
using System.Security.Claims;
using System;
using Api.Helpers;
using Api.Schema;
using Api.Services.interfaces.services;
using Api.Types.RequestQueries;

namespace Api.Schema.SubQueries
{
    public class SiteQuery : ObjectGraphType
    {
        public SiteQuery(ISiteListService service, IClaimService claimService)
        {
            Name = "Site";
            
            Field<SiteType, Site>("single")
                .Arguments(new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }
                ))
                .ResolveAsync(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return service.GetSite(id);
                });

            Field<SiteResultType<SiteType, Site>, Results<Site>>("search")
                .Arguments(new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "query" },
                    new QueryArgument<StringGraphType> { Name = "page" }
                ))
                .ResolveAsync(context =>
                {
                    var u = context.GetUser(claimService);
                    
                    var siteParamObj = new SiteParamObj
                    {
                        GroupId = u.GroupId
                    };

                    var tp = service.ListSites(siteParamObj);

                    tp.Result.Error += u.UpdateError(tp.Result.Error);

                    return tp;
                });

        }
    }
}