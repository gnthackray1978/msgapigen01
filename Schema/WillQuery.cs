﻿using GqlMovies.Api.Models;
using GqlMovies.Api.Types;
using GraphQL.Types;
using System.Collections.Generic;
using GraphQL;
using System.Security.Claims;
using System;
using Api.Services.interfaces;
using Api.Types;

namespace GqlMovies.Api.Schemas
{
    public class WillQuery : ObjectGraphType
	{
		public WillQuery(IWillListService service)
		{
			Name = "Will";

			FieldAsync<WillType, Will>(
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

			FieldAsync<WillResultType<WillType, Will>, Results<Will>>(
				"lincssearch",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "query" },
					new QueryArgument<IntGraphType> { Name = "limit" },
					new QueryArgument<IntGraphType> { Name = "offset" },
					new QueryArgument<StringGraphType> { Name = "sortColumn" },
					new QueryArgument<StringGraphType> { Name = "sortOrder" },
					new QueryArgument<IntGraphType> { Name = "yearStart" },
					new QueryArgument<IntGraphType> { Name = "yearEnd" },
					new QueryArgument<StringGraphType> { Name = "ref" },
					new QueryArgument<StringGraphType> { Name = "desc" },
					new QueryArgument<StringGraphType> { Name = "place" }, 
					new QueryArgument<StringGraphType> { Name = "surname" }
				

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
					var limit = context.GetArgument<int>("limit");
					var offset = context.GetArgument<int>("offset");
					
					var sortColumn = context.GetArgument<string>("sortColumn");
					var sortOrder = context.GetArgument<string>("sortOrder");

					var yearStart = context.GetArgument<int>("yearStart");
					var yearEnd = context.GetArgument<int>("yearEnd");

					var refArg = context.GetArgument<string>("ref");
					var desc = context.GetArgument<string>("desc");
					var place = context.GetArgument<string>("place");
					var surname = context.GetArgument<string>("surname");
					  

					var pobj = new WillSearchParamObj();

					pobj.User = currentUser;
					pobj.Limit = limit;
					pobj.Offset = offset;
					pobj.SortColumn = sortColumn;
					pobj.SortOrder = sortOrder;
					pobj.YearEnd = yearEnd;
					pobj.YearStart = yearStart;
					pobj.RefArg = refArg;
					pobj.Desc = desc;
					pobj.Place = place;
					pobj.Surname = surname;



					return service.LincolnshireWillsList(pobj);
				}
			);

			FieldAsync<WillResultType<WillType, Will>, Results<Will>>(
				"norfolksearch",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "query" },
					new QueryArgument<IntGraphType> { Name = "limit" },
					new QueryArgument<IntGraphType> { Name = "offset" },
					new QueryArgument<StringGraphType> { Name = "sortColumn" },
					new QueryArgument<StringGraphType> { Name = "sortOrder" },
					new QueryArgument<IntGraphType> { Name = "yearStart" },
					new QueryArgument<IntGraphType> { Name = "yearEnd" },
					new QueryArgument<StringGraphType> { Name = "ref" },
					new QueryArgument<StringGraphType> { Name = "desc" },
					new QueryArgument<StringGraphType> { Name = "place" },
					new QueryArgument<StringGraphType> { Name = "surname" }


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
					var limit = context.GetArgument<int>("limit");
					var offset = context.GetArgument<int>("offset");

					var sortColumn = context.GetArgument<string>("sortColumn");
					var sortOrder = context.GetArgument<string>("sortOrder");

					var yearStart = context.GetArgument<int>("yearStart");
					var yearEnd = context.GetArgument<int>("yearEnd");

					var refArg = context.GetArgument<string>("ref");
					var desc = context.GetArgument<string>("desc");
					var place = context.GetArgument<string>("place");
					var surname = context.GetArgument<string>("surname");


					var pobj = new WillSearchParamObj();

					pobj.User = currentUser;
					pobj.Limit = limit;
					pobj.Offset = offset;
					pobj.SortColumn = sortColumn;
					pobj.SortOrder = sortOrder;
					pobj.YearEnd = yearEnd;
					pobj.YearStart = yearStart;
					pobj.RefArg = refArg;
					pobj.Desc = desc;
					pobj.Place = place;
					pobj.Surname = surname;



					return service.NorfolkWillsList(pobj);
				}
			);
		}
	}
}