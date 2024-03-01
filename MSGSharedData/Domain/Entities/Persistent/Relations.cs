namespace MSGSharedData.Domain.Entities.Persistent
{
    public partial class Relations
    {
        public int RelationId { get; set; }
        public Guid? PersonA { get; set; }
        public Guid? PersonB { get; set; }
        public int? RelationType { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
