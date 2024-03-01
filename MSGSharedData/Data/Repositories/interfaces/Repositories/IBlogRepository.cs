using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.Blog;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;

namespace MSGSharedData.Data.Services.interfaces.services
{
    public interface IBlogRepository
    {
        Task<Blog> GetBlog(int id);

        Task<Results<Blog>> ListBlogs(BlogParamObj blogParamObj);
    }
}