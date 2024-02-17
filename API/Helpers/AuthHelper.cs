using System.Security.Claims;
using System;
using Api.Services.interfaces.services;

namespace Api.Helpers
{
    public class UserResult
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }

        public string ErrorMessage { get; set; }

        public int GroupId { get; set; }

        public string UpdateError(string error)
        {
            if (ErrorMessage!="")
                error += Environment.NewLine + ErrorMessage;

            return error;
        }
    }

    //public static class ResolveFieldContextExtensions
    //{
    //    public static UserResult GetUser(this IResolveFieldContext context, IClaimService claimService)
    //    {
    //        var result = new UserResult();

    //        try
    //        {
    //            result.ClaimsPrincipal = (ClaimsPrincipal)context.UserContext["claimsprincipal"];
    //        }
    //        catch (Exception e)
    //        {
    //            result.ErrorMessage = e.Message;
    //        }

    //        if (result.ErrorMessage == "")
    //            result.GroupId = claimService.GetUserGroupId(result.ClaimsPrincipal, 2);

    //        return result;
    //    }
    //}
}
