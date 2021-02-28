using Api.Types;
using GqlMovies.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Services.interfaces
{
    public interface IWillListService
    {
        Task<Will> GetAsync(int id);

        Task<Results<Will>> LincolnshireWillsList(ParamObject searchParams);

        Task<Results<Will>> NorfolkWillsList(ParamObject searchParams);

    }
}
