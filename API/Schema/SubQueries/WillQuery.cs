using Api.Models;
using Api.Types;
using GraphQL.Types;
using System.Collections.Generic;
using GraphQL;
using System.Security.Claims;
using System;
using Api.Services;
using System.Threading.Tasks;
using Api.Schema;
using Api.Services.interfaces.services;
using Api.Types.RequestQueries;

namespace Api.Schema.SubQueries
{

    public class WillQuery : ObjectGraphType
    {

        public WillQuery(IWillListService service, IClaimService claimService)
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

                    var refArg = context.GetArgument<string>("ref");
                    var desc = context.GetArgument<string>("desc");
                    var place = context.GetArgument<string>("place");
                    var surname = context.GetArgument<string>("surname");

                    if (!claimService.UserValid(currentUser, MSGApplications.Wills))
                    {
                        return ErrorHandler.Error<Will>(ce, claimService.GetClaimDebugString(currentUser));
                    }

                    var pobj = new WillSearchParamObj();


                    pobj.Limit = limit;
                    pobj.Offset = offset;
                    pobj.SortColumn = sortColumn;
                    pobj.SortOrder = sortOrder;
                    pobj.YearTo = yearEnd;
                    pobj.YearFrom = yearStart;
                    pobj.RefArg = refArg;
                    pobj.Desc = desc;
                    pobj.Place = place;
                    pobj.Surname = surname;

                    pobj.Meta.User = currentUser;
                    pobj.Meta.Error = ce?.Message;
                    pobj.Meta.LoginInfo = claimService.GetClaimDebugString(currentUser);

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

                    var refArg = context.GetArgument<string>("ref");
                    var desc = context.GetArgument<string>("desc");
                    var place = context.GetArgument<string>("place");
                    var surname = context.GetArgument<string>("surname");


                    if (!claimService.UserValid(currentUser, MSGApplications.Wills))
                    {
                        return ErrorHandler.Error<Will>(ce, claimService.GetClaimDebugString(currentUser));

                    }

                    var pobj = new WillSearchParamObj
                    {
                        Limit = limit,
                        Offset = offset,
                        SortColumn = sortColumn,
                        SortOrder = sortOrder,
                        YearTo = yearEnd,
                        YearFrom = yearStart,
                        RefArg = refArg,
                        Desc = desc,
                        Place = place,
                        Surname = surname
                    };
                    pobj.Meta.User = currentUser;
                    pobj.Meta.Error = ce?.Message;
                    pobj.Meta.LoginInfo = claimService.GetClaimDebugString(currentUser);


                    return service.NorfolkWillsList(pobj);
                }
            );
        }
    }
}