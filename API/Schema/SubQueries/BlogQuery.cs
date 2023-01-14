using System;
using System.Security.Claims;
using Api.Models;
using Api.Services.interfaces.services;
using Api.Types;
using Api.Types.Blog;
using Api.Types.RequestQueries;
using GraphQL;
using GraphQL.Types;

namespace Api.Schema.SubQueries
{
    public class BlogQuery : ObjectGraphType
    {
        public BlogQuery(IBlogService service, IClaimService claimService)
        {
            Name = "Blog";

            FieldAsync<BlogType, Blog>(
                "single",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }
                ),
                resolve: context =>
                {
                    try
                    {
                        var currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];

                    }
                    catch (Exception e)
                    {

                    }


                    //
                    var id = context.GetArgument<int>("id");
                    return service.GetBlog(id);
                }
            );

            FieldAsync<BlogListResult, Results<Blog>>(
                "search",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "query" },
                    new QueryArgument<IntGraphType> { Name = "level" }
                ),
                resolve: context =>
                {
                    ClaimsPrincipal currentUser = null;
               
                    Exception claimException = null;
                    try
                    {
                        currentUser = (ClaimsPrincipal)context.UserContext["claimsprincipal"];
                    }
                    catch (Exception e)
                    {
                        claimException = e;
                    }

                    var id = context.GetArgument<int>("level");

                    var blogParamObj = new BlogParamObj() { LevelId = id };
                    
                    var tp = service.ListBlogs(blogParamObj);


                    if (claimException != null)
                        tp.Result.Error += Environment.NewLine + claimException.Message;

                    return tp;
                }
            );

        }
    }
}
