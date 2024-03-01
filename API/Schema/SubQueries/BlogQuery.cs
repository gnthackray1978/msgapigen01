using System;
using System.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Models;
using Api.Types;
using HotChocolate;
using HotChocolate.Types;
using MSGSharedData.Data.Services.interfaces.services;
using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.Blog;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;
using MSGSharedData.Domain.Enumerations;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class BlogQuery 
    {
        //public Task<Blog> single(int id, [Service] IBlogRepositoryrepository,
        //    [Service] IClaimRepository claimService)
        //{
        //    return repository.GetBlog(id);
        //}

        public Task<Results<Blog>> searchBlog(BlogParamObj pobj, [Service] IBlogRepository repository,
            [Service] IClaimRepository claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.Blog))
            {
                return ErrorHandler.Error<Blog>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.ListBlogs(pobj);
        }
         
    }
}
