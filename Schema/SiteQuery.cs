using GqlMovies.Api.Models;
using GqlMovies.Api.Types;
using GqlMovies.Api.Services;
using GraphQL.Types;
using System.Collections.Generic;
using System.Reflection;
using GraphQL;
using System.Security.Claims;
using System;

namespace GqlMovies.Api.Schemas
{
	public class SiteQuery : ObjectGraphType
	{
		

		public SiteQuery(ISiteListService service)
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
					return service.GetAsync(id);
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

					try
					{
						currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];
					}
					catch (Exception e)
					{

					}

					var obj = new Dictionary<string, string>();
					
					var query = context.GetArgument<string>("query");
                    var page = context.GetArgument<string>("page");

					if (query != null) obj.Add("query", query);

					return service.ListAsync(obj, currentUser);
				}
			);


			
		}
	}

	public class ClaimQuery : ObjectGraphType
	{
		public ClaimQuery(IClaimsListService service)
		{

			Name = "Claim";

			FieldAsync<MSGClaimType, MSGClaim>(
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
					return service.GetAsync(id);
				}
			);

			FieldAsync<ClaimResultType<MSGClaimType, MSGClaim>, Results<MSGClaim>>(
			"search",
			arguments: new QueryArguments(
				new QueryArgument<StringGraphType> { Name = "query" },
				new QueryArgument<StringGraphType> { Name = "page" }
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

				var obj = new Dictionary<string, string>();

				var query = context.GetArgument<string>("query");
				var page = context.GetArgument<string>("page");

				if (query != null) obj.Add("query", query);

				return service.ListAsync(obj, currentUser);
			}
		);
		}
	}
}