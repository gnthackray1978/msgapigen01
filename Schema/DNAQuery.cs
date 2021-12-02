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
using GqlMovies.Api.Services;
using System.Threading.Tasks;

namespace GqlMovies.Api.Schemas
{
    public class DNAQuery : ObjectGraphType
	{
		public DNAQuery(IDNAAnalyseListService service, IClaimService claimService)
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
					Exception ce = null;

					try
					{
						currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];
					}
					catch (Exception e)
					{
						ce = e;
					}

					var obj = new Dictionary<string, string>();

					var query = context.GetArgument<string>("query");
					var limit = context.GetArgument<int>("limit");
					var offset = context.GetArgument<int>("offset");

					var sortColumn = context.GetArgument<string>("sortColumn");
					var sortOrder = context.GetArgument<string>("sortOrder");
					 
					var surname = context.GetArgument<string>("surname");

					if (!claimService.UserValid(currentUser, MSGApplications.FamilyTreeAnalizer))
					{						 
						return ErrorHandler.Error<Dupe>(ce, claimService.GetClaimDebugString(currentUser));
					}


					var pobj = new DNASearchParamObj();
					 
					pobj.Limit = limit;
					pobj.Offset = offset;
					pobj.SortColumn = sortColumn;
					pobj.SortOrder = sortOrder;
				 
			 
					pobj.Surname = surname;

					pobj.Meta.User = currentUser;
					pobj.Meta.Error = ce?.Message;
					pobj.Meta.LoginInfo = claimService.GetClaimDebugString(currentUser);

					return service.DupeList(pobj);
				}
			);

			#endregion

			#region loc search

			FieldAsync<FTMPersonLocationResult, Results<FTMPersonLocation>>(
				"ftmlocsearch",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "query" },
					new QueryArgument<IntGraphType> { Name = "yearStart" },
					new QueryArgument<IntGraphType> { Name = "yearEnd" },
					new QueryArgument<StringGraphType> { Name = "location" },
					new QueryArgument<StringGraphType> { Name = "surname" },
					new QueryArgument<StringGraphType> { Name = "origin" }


				),
				resolve: context =>
				{
					ClaimsPrincipal currentUser = null;
					Exception ce = null;

					try
					{
						currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];
					}
					catch (Exception e)
					{
						ce = e;
					}

					var obj = new Dictionary<string, string>();

					var query = context.GetArgument<string>("query");
	

					var yearStart = context.GetArgument<int>("yearStart");
					var yearEnd = context.GetArgument<int>("yearEnd");
					var origin = context.GetArgument<string>("origin");
					var place = context.GetArgument<string>("location");
					var surname = context.GetArgument<string>("surname");

					if (!claimService.UserValid(currentUser, MSGApplications.FamilyTreeAnalizer))
					{					
						return ErrorHandler.Error<FTMPersonLocation>(ce, claimService.GetClaimDebugString(currentUser));
					}

					var pobj = new DNASearchParamObj();

				 
		
					pobj.YearEnd = yearEnd;
					pobj.YearStart = yearStart;
					pobj.Location = place;
					pobj.Surname = surname;
					pobj.Origin = origin;

					pobj.Meta.User = currentUser;
					pobj.Meta.Error = ce?.Message;
					pobj.Meta.LoginInfo = claimService.GetClaimDebugString(currentUser);

					return service.FTMLocSearch(pobj);
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
					new QueryArgument<StringGraphType> { Name = "surname" },
					new QueryArgument<StringGraphType> { Name = "origin" }


				),
				resolve: context =>
				{
					ClaimsPrincipal currentUser = null;
					Exception ce = null;

					try
					{
						currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];
					}
					catch (Exception e)
					{
						ce = e;
					}

					var obj = new Dictionary<string, string>();

					var query = context.GetArgument<string>("query");
					var limit = context.GetArgument<int>("limit");
					var offset = context.GetArgument<int>("offset");

					var sortColumn = context.GetArgument<string>("sortColumn");
					var sortOrder = context.GetArgument<string>("sortOrder");

					var yearStart = context.GetArgument<int>("yearStart");
					var yearEnd = context.GetArgument<int>("yearEnd");
					var origin = context.GetArgument<string>("origin");
					var place = context.GetArgument<string>("location");
					var surname = context.GetArgument<string>("surname");

					if (!claimService.UserValid(currentUser, MSGApplications.FamilyTreeAnalizer))
					{					 
						return ErrorHandler.Error<FTMView>(ce, claimService.GetClaimDebugString(currentUser));
					}



					var pobj = new DNASearchParamObj();
 
					pobj.Limit = limit;
					pobj.Offset = offset;
					pobj.SortColumn = sortColumn;
					pobj.SortOrder = sortOrder;
					pobj.YearEnd = yearEnd;
					pobj.YearStart = yearStart;
					pobj.Location = place;
					pobj.Surname = surname;
					pobj.Origin = origin;

					pobj.Meta.User = currentUser;
					pobj.Meta.Error = ce?.Message;
					pobj.Meta.LoginInfo = claimService.GetClaimDebugString(currentUser);

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
					new QueryArgument<IntGraphType> { Name = "mincm" },
					new QueryArgument<StringGraphType> { Name = "country" },
					new QueryArgument<StringGraphType> { Name = "name" }

				),
				resolve: context =>
				{
					ClaimsPrincipal currentUser = null;
					Exception ce = null;

					try
					{
						currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];
					}
					catch (Exception e)
					{
						ce = e;
					}

					var obj = new Dictionary<string, string>();

					var query = context.GetArgument<string>("query");
					var limit = context.GetArgument<int>("limit");
					var offset = context.GetArgument<int>("offset");
					var sortColumn = context.GetArgument<string>("sortColumn");
					var sortOrder = context.GetArgument<string>("sortOrder");
					var yearStart = context.GetArgument<int>("yearStart");
					var yearEnd = context.GetArgument<int>("yearEnd");
					var location = context.GetArgument<string>("location");
					var mincm = context.GetArgument<int>("mincm"); 
					var surname = context.GetArgument<string>("surname");
					var country = context.GetArgument<string>("country");
					var name = context.GetArgument<string>("name");


					if (!claimService.UserValid(currentUser, MSGApplications.FamilyTreeAnalizer))
					{ 
						return ErrorHandler.Error<PersonOfInterestSubset>(ce, claimService.GetClaimDebugString(currentUser));
					}


					var pobj = new DNASearchParamObj();
					 
					pobj.Limit = limit;
					pobj.Offset = offset;
					pobj.SortColumn = sortColumn;
					pobj.SortOrder = sortOrder;
					pobj.YearEnd = yearEnd;
					pobj.YearStart = yearStart;				 
					pobj.Surname = surname;
					pobj.Country = country;
					pobj.MinCM = mincm;
					pobj.Name = name;
					pobj.Location = location;

					pobj.Meta.User = currentUser;
					pobj.Meta.Error = ce?.Message;
					pobj.Meta.LoginInfo = claimService.GetClaimDebugString(currentUser);

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
					new QueryArgument<StringGraphType> { Name = "sortOrder" },
					new QueryArgument<StringGraphType> { Name = "origin" },
					new QueryArgument<IntGraphType> { Name = "groupNumber" }
				),
				resolve: context =>
				{
					ClaimsPrincipal currentUser = null;
					Exception ce = null;

					try
					{
						currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];
					}
					catch (Exception e)
					{
						ce = e;
					}

					var obj = new Dictionary<string, string>();

					var query = context.GetArgument<string>("query");
					var limit = context.GetArgument<int>("limit");
					var offset = context.GetArgument<int>("offset");

					var sortColumn = context.GetArgument<string>("sortColumn");
					var sortOrder = context.GetArgument<string>("sortOrder");

					var origin = context.GetArgument<string>("origin");
					var groupNumber = context.GetArgument<int>("groupNumber");


					if (!claimService.UserValid(currentUser, MSGApplications.FamilyTreeAnalizer))
					{						 
						return ErrorHandler.Error<TreeRec>(ce, claimService.GetClaimDebugString(currentUser));
					}

					var pobj = new DNASearchParamObj();

					 
					pobj.Limit = limit;
					pobj.Offset = offset;
					pobj.SortColumn = sortColumn;
					pobj.SortOrder = sortOrder;
					pobj.Origin = origin;
					pobj.GroupNumber = groupNumber;

					pobj.Meta.User = currentUser;
					pobj.Meta.Error = ce?.Message;
					pobj.Meta.LoginInfo = claimService.GetClaimDebugString(currentUser);

					return service.TreeList(pobj);
				}
			);

			#endregion
		}
	}
}
