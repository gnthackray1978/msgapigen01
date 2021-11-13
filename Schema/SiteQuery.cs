using GqlMovies.Api.Models;
using GqlMovies.Api.Types;
using GqlMovies.Api.Services;
using GraphQL.Types;
using System.Collections.Generic;
using System.Reflection;
using GraphQL;
using System.Security.Claims;
using System;
using Api.Types;

namespace GqlMovies.Api.Schemas
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
					catch (Exception e) { 
					
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
					ClaimsPrincipal currentUser =null;
					int groupId=0;
					Exception claimException = null;
					try
					{
						currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];

						groupId=claimService.GetUserGroupId(currentUser);
					}
					catch (Exception e)
					{
						claimException = e;
					}

					//var obj = new Dictionary<string, string>();

					//var query = context.GetArgument<string>("query");
					//               var page = context.GetArgument<string>("page");

					///if (query != null) obj.Add("query", query);
					///
					var siteParamObj = new SiteParamObj(); 

					siteParamObj.GroupId = groupId;

					var tp= service.ListSites(siteParamObj);


					if(claimException!=null)
						tp.Result.Error += Environment.NewLine + claimException.Message;

					return tp;
				}
			);

		}
	}
}