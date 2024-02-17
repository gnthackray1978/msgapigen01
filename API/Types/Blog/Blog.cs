using System;
using HotChocolate.Types;

namespace Api.Types.Blog
{
    public class BlogType : ObjectType<Blog>
    {
        protected override void Configure(IObjectTypeDescriptor<Blog> descriptor)
        {
           descriptor.Field(m => m.Id);

           descriptor.Field(m => m.Text);
           descriptor.Field(m => m.Level);
           descriptor.Field(m => m.Title);
           descriptor.Field(m => m.LinkURL);
           descriptor.Field(m => m.LinkDescription);
           descriptor.Field(m => m.ImageURL);
           descriptor.Field(m => m.ImageDescription);
           descriptor.Field(m => m.DateLastEdit);
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
    
}
