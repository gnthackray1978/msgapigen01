using System.Security.Claims;
using System;

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
    
}
