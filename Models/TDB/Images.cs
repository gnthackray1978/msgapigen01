namespace AzureContext.Models
{
    public partial class Images 
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Info { get; set; } 
     
        public int ParentImageId { get; set; }
    }

    public partial class ImageParents
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Info { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Page { get; set; }
    }
}
