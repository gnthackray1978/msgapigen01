using GraphQL.Types;

namespace Api.Models
{

    public class ApiImagesType : ObjectGraphType<ApiImage>
    {
        public ApiImagesType()
        {
            Field(m => m.Id);
            Field(m => m.Path);
            Field(m => m.Title);
            Field(m => m.Info);
            Field(m => m.ParentImageId);

        }
    }

    public class ApiImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }

        public int ParentImageId { get; set; }

    }
        
   

}

