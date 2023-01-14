using System.Threading.Tasks;
using Api.Models;
using Api.Schema;
using Api.Types.Blog;
using Api.Types.RequestQueries;

namespace Api.Services.interfaces.services
{
    public interface IBlogService
    {
        Task<Blog> GetBlog(int id);

        Task<Results<Blog>> ListBlogs(BlogParamObj blogParamObj);
    }
}