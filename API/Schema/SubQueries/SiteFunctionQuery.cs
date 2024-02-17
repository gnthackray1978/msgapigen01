using Api.Models;
using System.Security.Claims;
using System;
using System.Security;
using System.Threading.Tasks;
using Api.Services;
using Api.Services.interfaces.services;
using Api.Types.RequestQueries;
using HotChocolate;
using HotChocolate.Types;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class SiteFunctionQuery 
    {
        //public Task<SiteFunction> single([Service] IFunctionListService repository, int id)
        //{
        //    return repository.GetAsync(id);
        //}

        public Task<Results<SiteFunction>> searchSiteFunction( [Service] IFunctionListService repository,
             ClaimsPrincipal currentUser, int? appId)
        {
            if (appId == null || appId == 0)
            {
                return repository.ListAsync(currentUser);
            }
            else
            {
                return repository.ListAsync(appId.Value, currentUser);
            }
        }
         
    }
}