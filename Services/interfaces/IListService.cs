using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using GqlMovies.Api.Models;
using System.Security.Claims;
using Api.Models;

namespace GqlMovies.Api.Services
{

    public interface IListService<T>
    {
        Task<T> GetAsync(int id);

        Task<Results<T>> ListAsync(Dictionary<string, string> input, ClaimsPrincipal user);
    }

}
