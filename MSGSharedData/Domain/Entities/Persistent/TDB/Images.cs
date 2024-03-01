namespace MSGSharedData.Domain.Entities.Persistent.TDB
{
    public partial class Images
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }

        public int ParentImageId { get; set; }
    }
}
