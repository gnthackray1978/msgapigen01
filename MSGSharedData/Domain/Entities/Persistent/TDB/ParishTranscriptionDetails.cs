namespace MSGSharedData.Domain.Entities.Persistent.TDB
{
    public partial class ParishTranscriptionDetails
    {
        public int Id { get; set; }
        public int ParishId { get; set; }
        public string ParishDataString { get; set; }
    }
}
