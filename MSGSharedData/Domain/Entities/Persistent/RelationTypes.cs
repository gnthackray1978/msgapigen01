namespace MSGSharedData.Domain.Entities.Persistent
{
    public partial class RelationTypes
    {
        public int RelationTypeId { get; set; }
        public string RelationName { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
