using HotChocolate.Types;

namespace Api.Models
{
    public class ApiImagesType : ObjectType<ApiImage>
    {
        protected override void Configure(IObjectTypeDescriptor<ApiImage> descriptor)
        {
            descriptor.Field(m => m.Id);
            descriptor.Field(m => m.Path);
            descriptor.Field(m => m.Title);
            descriptor.Field(m => m.Info);
            descriptor.Field(m => m.ParentImageId);
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

