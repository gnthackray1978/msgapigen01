using GqlMovies.Api.Models;
using GqlMovies.Api.Types;
using GqlMovies.Api.Services;
using GraphQL.Types;
using System.Collections.Generic;
using GraphQL;
using System.Security.Claims;
using System;

namespace GqlMovies.Api.Schemas
{
    public class SiteFunctionQuery : ObjectGraphType
	{
		public SiteFunctionQuery(IFunctionListService service)
		{
			Name = "Function";

			FieldAsync<SiteFunctionType, SiteFunction>(
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
					 
					var id = context.GetArgument<int>("id");

					return service.GetAsync(id);
				}
			);

			FieldAsync<SiteFunctionResultType<SiteFunctionType, SiteFunction>, Results<SiteFunction>>(
				"search",
				arguments: new QueryArguments(
					new QueryArgument<IntGraphType> { Name = "appid" }
				),
				resolve: context =>
				{
					ClaimsPrincipal currentUser = null;

					try
					{
						currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];
					}
					catch (Exception e)
					{

					}
				 
					var appId = context.GetArgument<int?>("appid");

					if (appId == null || appId == 0)
					{
						return service.ListAsync(currentUser);
					}
					else
					{
						return service.ListAsync(appId.Value, currentUser);
					}
				}
			);

		}
	}
}