﻿using System.Threading.Tasks;
using GqlMovies.Api.Models;
using System.Security.Claims;

namespace GqlMovies.Api.Services
{
    public interface IFunctionListService  {
        Task<SiteFunction> GetAsync(int id);

        Task<Results<SiteFunction>> ListAsync(int applicationId, ClaimsPrincipal user);

        Task<Results<SiteFunction>> ListAsync(ClaimsPrincipal user);
    }

}
