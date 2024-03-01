using System.Security.Claims;

namespace MSGSharedData.Domain.Entities.NonPersistent.RequestQueries
{
    public class MetaData
    {
        public ClaimsPrincipal User { get; set; }

        public Exception ClaimsException { get; set; }

        public string LoginInfo { get; set; }


        public string Error { get; set; }
    }
}