using Api.Types;
using Api.Models;
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

        Task<Results<Will>> LincolnshireWillsList(WillSearchParamObj searchParams);

        Task<Results<Will>> NorfolkWillsList(WillSearchParamObj searchParams);

    }
}
