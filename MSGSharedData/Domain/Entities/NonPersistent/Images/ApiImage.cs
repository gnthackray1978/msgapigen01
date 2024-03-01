namespace MSGSharedData.Domain.Entities.NonPersistent.Images
{


    public class ApiImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }

        public int ParentImageId { get; set; }

    }



}

