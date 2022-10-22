using Api.Types;
using Api.Types.ADB;
using Api.Types.DNAAnalyse;
using Api.Services;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Services.interfaces.services;
using Api.Types.RequestQueries;

namespace Api.Schema.SubQueries
{
    public class ADBQuery : ObjectGraphType
    {

        public ADBQuery(IADBService service, IClaimService claimService)
        {
            Name = "Adb";

            #region marriagesearch
            FieldAsync<MarriageSearchResult, Results<ADBMarriage>>(
                "marriagesearch",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "query" },
                    new QueryArgument<IntGraphType> { Name = "limit" },
                    new QueryArgument<IntGraphType> { Name = "offset" },

                    new QueryArgument<StringGraphType> { Name = "sortColumn" },
                    new QueryArgument<StringGraphType> { Name = "sortOrder" },
                    new QueryArgument<IntGraphType> { Name = "yearStart" },
                    new QueryArgument<IntGraphType> { Name = "yearEnd" },
                    new QueryArgument<StringGraphType> { Name = "maleSurname" },
                    new QueryArgument<StringGraphType> { Name = "femaleSurname" },
                    new QueryArgument<StringGraphType> { Name = "location" }
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

                    var maleSurname = context.GetArgument<string>("maleSurname");
                    var femaleSurname = context.GetArgument<string>("femaleSurname");

                    var location = context.GetArgument<string>("location");

                    if (!claimService.UserValid(currentUser, MSGApplications.ThackrayDB))
                    {
                        return ErrorHandler.Error<ADBMarriage>(ce, claimService.GetClaimDebugString(currentUser));
                    }

                    var pobj = new ADBMarriageParamObj();

                    pobj.Limit = limit;
                    pobj.Offset = offset;
                    pobj.SortColumn = sortColumn;
                    pobj.SortOrder = sortOrder;
                    pobj.FemaleSurname = femaleSurname;
                    pobj.MaleSurname = maleSurname;
                    pobj.Location = location;
                    pobj.YearTo = yearEnd;
                    pobj.YearFrom = yearStart;

                    pobj.Meta.User = currentUser;
                    pobj.Meta.Error = ce?.Message;
                    pobj.Meta.LoginInfo = claimService.GetClaimDebugString(currentUser);

                    return service.MarriageList(pobj);
                }
            );

            #endregion


            #region personsearch
            FieldAsync<PersonSearchResult, Results<ADBPerson>>(
                "personsearch",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "query" },
                    new QueryArgument<IntGraphType> { Name = "limit" },
                    new QueryArgument<IntGraphType> { Name = "offset" },
                    new QueryArgument<StringGraphType> { Name = "sortColumn" },
                    new QueryArgument<StringGraphType> { Name = "sortOrder" },
                    new QueryArgument<IntGraphType> { Name = "yearStart" },
                    new QueryArgument<IntGraphType> { Name = "yearEnd" },
                    new QueryArgument<StringGraphType> { Name = "location" },
                    new QueryArgument<StringGraphType> { Name = "firstName" },
                    new QueryArgument<StringGraphType> { Name = "surname" },
                    new QueryArgument<StringGraphType> { Name = "birthLocation" },
                    new QueryArgument<StringGraphType> { Name = "deathLocation" },
                    new QueryArgument<StringGraphType> { Name = "fatherChristianName" },
                    new QueryArgument<StringGraphType> { Name = "fatherSurname" },
                    new QueryArgument<StringGraphType> { Name = "motherChristianName" },
                    new QueryArgument<StringGraphType> { Name = "motherSurname" },
                    new QueryArgument<StringGraphType> { Name = "source" },
                    new QueryArgument<StringGraphType> { Name = "deathCounty" },
                    new QueryArgument<StringGraphType> { Name = "birthCounty" },
                    new QueryArgument<StringGraphType> { Name = "occupation" },
                    new QueryArgument<StringGraphType> { Name = "spouseName" },
                    new QueryArgument<StringGraphType> { Name = "spouseSurname" },
                    new QueryArgument<StringGraphType> { Name = "fatherOccupation" },
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


                    var location = context.GetArgument<string>("location");
                    var firstName = context.GetArgument<string>("firstName");
                    var surname = context.GetArgument<string>("surname");
                    var birthLocation = context.GetArgument<string>("birthLocation");
                    var deathLocation = context.GetArgument<string>("deathLocation");
                    var fatherChristianName = context.GetArgument<string>("fatherChristianName");
                    var fatherSurname = context.GetArgument<string>("fatherSurname");
                    var motherChristianName = context.GetArgument<string>("motherChristianName");
                    var motherSurname = context.GetArgument<string>("motherSurname");
                    var source = context.GetArgument<string>("source");
                    var deathCounty = context.GetArgument<string>("deathCounty");
                    var birthCounty = context.GetArgument<string>("birthCounty");
                    var occupation = context.GetArgument<string>("occupation");
                    var spouseName = context.GetArgument<string>("spouseName");
                    var spouseSurname = context.GetArgument<string>("spouseSurname");
                    var fatherOccupation = context.GetArgument<string>("fatherOccupation");

                    if (!claimService.UserValid(currentUser, MSGApplications.ThackrayDB))
                    {
                        return ErrorHandler.Error<ADBPerson>(ce, claimService.GetClaimDebugString(currentUser));
                    }


                    var pobj = new ADBPersonParamObj();

                    pobj.Limit = limit;
                    pobj.Offset = offset;
                    pobj.SortColumn = sortColumn;
                    pobj.SortOrder = sortOrder;
                    pobj.Location = location;
                    pobj.YearTo = yearEnd;
                    pobj.YearFrom = yearStart;

                    pobj.FirstName = firstName;
                    pobj.Surname = surname;
                    pobj.BirthLocation = birthLocation;
                    pobj.DeathLocation = deathLocation;
                    pobj.FatherChristianName = fatherChristianName;
                    pobj.FatherSurname = fatherSurname;
                    pobj.MotherChristianName = motherChristianName;
                    pobj.MotherSurname = motherSurname;
                    pobj.Source = source;
                    pobj.DeathCounty = deathCounty;
                    pobj.BirthCounty = birthCounty;
                    pobj.Occupation = occupation;
                    pobj.SpouseName = spouseName;
                    pobj.SpouseSurname = spouseSurname;
                    pobj.FatherOccupation = fatherOccupation;

                    pobj.Meta.User = currentUser;
                    pobj.Meta.Error = ce?.Message;
                    pobj.Meta.LoginInfo = claimService.GetClaimDebugString(currentUser);

                    return service.PersonList(pobj);
                }
            );

            #endregion


            #region parishsearch
            FieldAsync<ParishSearchResult, Results<ADBParish>>(
                "parishsearch",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "query" },
                    new QueryArgument<IntGraphType> { Name = "limit" },
                    new QueryArgument<IntGraphType> { Name = "offset" },
                    new QueryArgument<StringGraphType> { Name = "sortColumn" },
                    new QueryArgument<StringGraphType> { Name = "sortOrder" },
                    new QueryArgument<StringGraphType> { Name = "county" },
                    new QueryArgument<StringGraphType> { Name = "parishName" }
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


                    var county = context.GetArgument<string>("county");
                    var parishName = context.GetArgument<string>("parishName");

                    if (!claimService.UserValid(currentUser, MSGApplications.ThackrayDB))
                    {

                        return ErrorHandler.Error<ADBParish>(ce, claimService.GetClaimDebugString(currentUser));
                    }

                    var pobj = new ADBParishParamObj();

                    pobj.Limit = limit;
                    pobj.Offset = offset;
                    pobj.SortColumn = sortColumn;
                    pobj.SortOrder = sortOrder;



                    pobj.ParishName = parishName;
                    pobj.County = county;

                    pobj.Meta.User = currentUser;
                    pobj.Meta.Error = ce?.Message;
                    pobj.Meta.LoginInfo = claimService.GetClaimDebugString(currentUser);

                    return service.ParishList(pobj);
                }
            );

            #endregion


            #region sourcesearch
            FieldAsync<SourceSearchResult, Results<ADBSource>>(
                "sourcesearch",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "query" },
                    new QueryArgument<IntGraphType> { Name = "limit" },
                    new QueryArgument<IntGraphType> { Name = "offset" },
                    new QueryArgument<StringGraphType> { Name = "sortColumn" },
                    new QueryArgument<StringGraphType> { Name = "sortOrder" },
                    new QueryArgument<IntGraphType> { Name = "yearStart" },
                    new QueryArgument<IntGraphType> { Name = "yearEnd" },
                    new QueryArgument<StringGraphType> { Name = "location" },
                    new QueryArgument<StringGraphType> { Name = "sourceRef" }



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

                    var location = context.GetArgument<string>("location");
                    var sourceRef = context.GetArgument<string>("sourceRef");

                    var yearEnd = context.GetArgument<int>("yearEnd");
                    var yearStart = context.GetArgument<int>("yearStart");

                    if (!claimService.UserValid(currentUser, MSGApplications.ThackrayDB))
                    {
                        return ErrorHandler.Error<ADBSource>(ce, claimService.GetClaimDebugString(currentUser));
                    }


                    var pobj = new ADBSourceParamObj();

                    pobj.Limit = limit;
                    pobj.Offset = offset;
                    pobj.SortColumn = sortColumn;
                    pobj.SortOrder = sortOrder;


                    pobj.SourceRef = sourceRef;

                    pobj.Location = location;


                    pobj.YearFrom = yearStart;
                    pobj.YearTo = yearEnd;

                    pobj.Meta.User = currentUser;
                    pobj.Meta.Error = ce?.Message;
                    pobj.Meta.LoginInfo = claimService.GetClaimDebugString(currentUser);

                    return service.SourceList(pobj);
                }
            );

            #endregion




        }
    }
}
