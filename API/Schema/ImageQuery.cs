using Api.Models;
using Api.Types;
using GraphQL.Types;
using System.Collections.Generic;
using GraphQL;
using System.Security.Claims;
using System;
using Api.Services.interfaces;
using Api.Types;
using Api.Services;
using Api.Types.Images;

namespace Api.Schema
{
    public class ImageQuery : ObjectGraphType
    {

        public ImageQuery(IPhotoListService service, IClaimService claimService)
        {
            Name = "Image";



            FieldAsync<ApiImagesResult, Results<ApiImage>>(
                "imagesearch",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "page" }),
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

                    var query = context.GetArgument<string>("page");

                    var results = service.ImagesList("", query);
                    results.Result.Error = "None";
                    results.Result.LoginInfo = query;

                    if (!claimService.UserValid(currentUser, MSGApplications.FamilyHistoryPhotos))
                    {
                        results.Result.LoginInfo = "No User";
                        results.Result.Error += Environment.NewLine + "No Valid User found";
                        //	return ErrorHandler.Error<ApiImage>(ce, claimService.GetClaimDebugString(currentUser));
                    }



                    return results;
                }
            );

            FieldAsync<ApiParentImagesResult, Results<ApiParentImages>>(
                "imageparentsearch",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "page" }),
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


                    var query = context.GetArgument<string>("page");

                    var results = service.ParentImagesList("", query);

                    results.Result.LoginInfo = query;

                    if (!claimService.UserValid(currentUser, MSGApplications.FamilyHistoryPhotos))
                    {
                        results.Result.LoginInfo = query;
                        results.Result.Error += Environment.NewLine + "No Valid User found";
                        //	return ErrorHandler.Error<ApiImage>(ce, claimService.GetClaimDebugString(currentUser));
                    }

                    return results;
                }
            );
        }
    }
}