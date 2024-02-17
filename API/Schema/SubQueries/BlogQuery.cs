using System;
using System.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Models;
using Api.Services;
using Api.Services.interfaces.services;
using Api.Types;
using Api.Types.Blog;
using Api.Types.RequestQueries;
using HotChocolate;
using HotChocolate.Types;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class BlogQuery 
    {
        //public Task<Blog> single(int id, [Service] IBlogService repository,
        //    [Service] IClaimService claimService)
        //{
        //    return repository.GetBlog(id);
        //}

        public Task<Results<Blog>> searchBlog(BlogParamObj pobj, [Service] IBlogService repository,
            [Service] IClaimService claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.Blog))
            {
                return ErrorHandler.Error<Blog>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.ListBlogs(pobj);
        }
         
    }
}
