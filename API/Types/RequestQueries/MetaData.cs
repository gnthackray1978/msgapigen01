using System;
using System.Security.Claims;

namespace Api.Types.RequestQueries
{
    public class MetaData
    {
        public ClaimsPrincipal User { get; set; }

        public Exception ClaimsException { get; set; }

        public string LoginInfo { get; set; }


        public string Error { get; set; }
    }
}