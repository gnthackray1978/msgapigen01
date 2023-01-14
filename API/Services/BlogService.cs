using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Api.DB;
using Api.Entities.MSGCore.Auth;
using Api.Models;
using Api.Schema;
using Api.Services.interfaces.services;
using Api.Types.Blog;
using Api.Types.RequestQueries;
using ConfigHelper;
using Microsoft.Extensions.Configuration;

namespace Api.Services
{
    public class BlogService : IBlogService
    {
        private readonly IMSGConfigHelper _imsConfigHelper;
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public BlogService(HttpClient client, IConfiguration config, IMSGConfigHelper imsConfigHelper)
        {
            _client = client;
            _imsConfigHelper = imsConfigHelper;
        }

        public async Task<Blog> GetBlog(int id)
        {
            var blog = new Blog();

            try
            {
                var a = new MSGCoreContext(_imsConfigHelper.MSGGenDB01);

                var msgBlog = a.MsgBlogs.FirstOrDefault(fi => fi.Id == id);

                blog = new Blog()
                {
                    Id = msgBlog.Id, 
                    Level = msgBlog.Level,
                    DateLastEdit = msgBlog.DateLastEdit,
                    ImageDescription = msgBlog.ImageDescription ?? "",
                    ImageURL = msgBlog.ImageURL ?? "",
                    LinkDescription = msgBlog.LinkDescription ?? "",
                    LinkURL = msgBlog.LinkURL ?? "",
                    Text = msgBlog.Text ?? "",
                    Title = msgBlog.Title ?? ""
                };

            }
            catch (Exception e)
            {
                blog.Error = e.Message;
            }
            
            return blog;
        }

        public async Task<Results<Blog>> ListBlogs(BlogParamObj blogParamObj)
        {
            var blogs = new List<Blog>();

            var results = new Results<Blog>();

            try
            {
                var a = new MSGCoreContext(_imsConfigHelper.MSGGenDB01);
                
                var blogsList = blogParamObj.LevelId != 0 ? a.MsgBlogs.Where(w => w.Level == blogParamObj.LevelId).ToList() : a.MsgBlogs.ToList();

                blogs.AddRange(blogsList.Select(msgblog => new Blog()
                {
                    Id = msgblog.Id,
                    Level = msgblog.Level,
                    DateLastEdit = msgblog.DateLastEdit,
                    ImageDescription = msgblog.ImageDescription ?? "",
                    ImageURL = msgblog.ImageURL ?? "",
                    LinkDescription = msgblog.LinkDescription ?? "",
                    LinkURL = msgblog.LinkURL ?? "",
                    Text = msgblog.Text ?? "",
                    Title = msgblog.Title ?? ""
                }));
            }
            catch (Exception e)
            {
                results.Error = e.Message;
            }

            results.results = blogs;
            results.Page = 0;
            results.total_pages = 1;
            results.total_results = results.results.Count();

            return results;
        }
    }
}