using Api.Models;
using Api.Types;
using GraphQL.Types;
using System.Collections.Generic;
using System.Reflection;
using GraphQL;
using System.Security.Claims;
using System;
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

            FieldAsync<SiteType, Site>(
                "single",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }
                ),
                resolve: context =>
                {
                    try
                    {
                        var currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];

                    }
                    catch (Exception e)
                    {

                    }


                    //
                    var id = context.GetArgument<int>("id");
                    return service.GetSite(id);
                }
            );

            FieldAsync<SiteResultType<SiteType, Site>, Results<Site>>(
                "search",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "query" },
                    new QueryArgument<StringGraphType> { Name = "page" }
                ),
                resolve: context =>
                {
                    ClaimsPrincipal currentUser = null;
                    int groupId = 2;
                    Exception claimException = null;
                    try
                    {
                        currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];
                    }
                    catch (Exception e)
                    {
                        claimException = e;
                    }



                    if (currentUser != null)
                        groupId = claimService.GetUserGroupId(currentUser, 2);

                    var siteParamObj = new SiteParamObj
                    {
                        GroupId = groupId
                    };

                    var tp = service.ListSites(siteParamObj);


                    if (claimException != null)
                        tp.Result.Error += Environment.NewLine + claimException.Message;

                    return tp;
                }
            );

        }
    }
}