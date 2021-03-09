using GqlMovies.Api.Models;
using GqlMovies.Api.Types;
using GraphQL.Types;
using System.Collections.Generic;
using GraphQL;
using System.Security.Claims;
using System;
using Api.Services.interfaces;
using Api.Types;
using Api.Types.DNAAnalyse;

namespace GqlMovies.Api.Schemas
{
    public class DNAQuery : ObjectGraphType
	{
		public DNAQuery(IDNAAnalyseListService service)
		{
			Name = "Dna";

            #region dupesearch
            FieldAsync<DupeResult, Results<Dupe>>(
				"dupesearch",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "query" },
					new QueryArgument<IntGraphType> { Name = "limit" },
					new QueryArgument<IntGraphType> { Name = "offset" },
					new QueryArgument<StringGraphType> { Name = "sortColumn" },
					new QueryArgument<StringGraphType> { Name = "sortOrder" }, 
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
					 
					var surname = context.GetArgument<string>("surname");


					var pobj = new DNASearchParamObj();

					pobj.User = currentUser;
					pobj.Limit = limit;
					pobj.Offset = offset;
					pobj.SortColumn = sortColumn;
					pobj.SortOrder = sortOrder;
				 
			 
					pobj.Surname = surname;



					return service.DupeList(pobj);
				}
			);

			#endregion

 
			#region ftmviewsearch

			FieldAsync<FTMViewResult, Results<FTMView>>(
				"ftmviewsearch",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "query" },
					new QueryArgument<IntGraphType> { Name = "limit" },
					new QueryArgument<IntGraphType> { Name = "offset" },
					new QueryArgument<StringGraphType> { Name = "sortColumn" },
					new QueryArgument<StringGraphType> { Name = "sortOrder" },
					new QueryArgument<IntGraphType> { Name = "yearStart" },
					new QueryArgument<IntGraphType> { Name = "yearEnd" },			 
					new QueryArgument<StringGraphType> { Name = "location" },
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


					var pobj = new DNASearchParamObj();

					pobj.User = currentUser;
					pobj.Limit = limit;
					pobj.Offset = offset;
					pobj.SortColumn = sortColumn;
					pobj.SortOrder = sortOrder;
					pobj.YearEnd = yearEnd;
					pobj.YearStart = yearStart;
				 
					pobj.Surname = surname;



					return service.FTMViewList(pobj);
				}
			);

            #endregion

            #region poi search

            FieldAsync<PersonOfInterestResult, Results<PersonOfInterestSubset>>(
				"poisearch",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "query" },
					new QueryArgument<IntGraphType> { Name = "limit" },
					new QueryArgument<IntGraphType> { Name = "offset" },
					new QueryArgument<StringGraphType> { Name = "sortColumn" },
					new QueryArgument<StringGraphType> { Name = "sortOrder" },
					new QueryArgument<IntGraphType> { Name = "yearStart" },
					new QueryArgument<IntGraphType> { Name = "yearEnd" },
					new QueryArgument<StringGraphType> { Name = "location" },
					new QueryArgument<StringGraphType> { Name = "surname" },
					new QueryArgument<IntGraphType> { Name = "mincm" }
 

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


					var pobj = new DNASearchParamObj();

					pobj.User = currentUser;
					pobj.Limit = limit;
					pobj.Offset = offset;
					pobj.SortColumn = sortColumn;
					pobj.SortOrder = sortOrder;
					pobj.YearEnd = yearEnd;
					pobj.YearStart = yearStart;				 
					pobj.Surname = surname;



					return service.PersonOfInterestList(pobj);
				}
			);

            #endregion

            #region treerecsearch
            FieldAsync<TreeRecResult, Results<TreeRec>>(
				"treerecsearch",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "query" },
					new QueryArgument<IntGraphType> { Name = "limit" },
					new QueryArgument<IntGraphType> { Name = "offset" },
					new QueryArgument<StringGraphType> { Name = "sortColumn" },
					new QueryArgument<StringGraphType> { Name = "sortOrder" }				 
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
					 
					var pobj = new DNASearchParamObj();

					pobj.User = currentUser;
					pobj.Limit = limit;
					pobj.Offset = offset;
					pobj.SortColumn = sortColumn;
					pobj.SortOrder = sortOrder;
		 
					return service.TreeList(pobj);
				}
			);

			#endregion
		}
	}
}