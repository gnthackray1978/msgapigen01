namespace MSGSharedData.Domain.Entities.Persistent.TDB
{
    public partial class SourceMappingParishs
    {
        public int Id { get; set; }
        public int? SourceMappingParishId { get; set; }
        public int? SourceMappingSourceId { get; set; }
        public DateTime? SourceMappingDateAdded { get; set; }
        public int? SourceMappingUser { get; set; }
    }
}
