using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Api.Models;
using System.Security.Claims;
using Api.Schema;
using Api.Types.RequestQueries;

namespace Api.Services.interfaces.services
{
    public interface ISiteListService //: IListService<Site> 
    {
        Task<Site> GetSite(int id);

        Task<Results<Site>> ListSites(SiteParamObj siteParamObj);
    }

}
