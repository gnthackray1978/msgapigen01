using System;
using Api.Models;
using Api.Schema;
using Api.Types.Images;
using GraphQL.Types;

namespace Api.Types.Blog
{
    public class BlogType : ObjectGraphType<Blog>
    {
        public BlogType()
        {
            Field(m => m.Id);

            Field(m => m.Text);
            Field(m => m.Level);
            Field(m => m.Title);
            Field(m => m.LinkURL);
            Field(m => m.LinkDescription);
            Field(m => m.ImageURL);
            Field(m => m.ImageDescription);
            Field(m => m.DateLastEdit);
        }
    }

    public class Blog
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Level { get; set; }

        public string Title { get; set; }

        public string LinkURL { get; set; }
        public string LinkDescription { get; set; }

        public string ImageURL { get; set; }
        public string ImageDescription { get; set; }

        public DateTime DateLastEdit { get; set; }

        public string Error { get; set; }
    }


    public class BlogListType<GraphT, ObjT> : ObjectGraphType<Results<ObjT>>
        where GraphT : IGraphType
    {
        public BlogListType()
        {
            Field<ListGraphType<GraphT>>(
                "results",
                resolve: context =>
                {
                    return context.Source.results;
                }
            );
            Field(r => r.Page);
            Field(r => r.TotalResults);
            Field(r => r.TotalPages);
            Field(r => r.Error);
            Field(r => r.LoginInfo);
        }
    }

    public class BlogListResult : BlogListType<BlogType, Blog> { }
    
}
