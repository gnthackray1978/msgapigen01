using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using GqlMovies.Api.Models;
using System.Security.Claims;
using Api.Models;
using Api.Types;

namespace GqlMovies.Api.Services
{
    public interface ISiteListService //: IListService<Site> 
    {
        Task<Site> GetSite(int id);

        Task<Results<Site>> ListSites(SiteParamObj siteParamObj);
    }

}
