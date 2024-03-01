using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.SiteMetaData;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;

namespace MSGSharedData.Data.Services.interfaces.services
{
    public interface ISiteListRepository
    {
        Task<Site> GetSite(int id);

        Task<Results<Site>> ListSites(SiteParamObj siteParamObj);
    }
}
