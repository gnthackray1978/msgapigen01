namespace MSGSharedData.Domain.Entities.Persistent.TDB
{
    public partial class ParishRecords
    {
        public int Id { get; set; }
        public int ParishId { get; set; }
        public int DataTypeId { get; set; }
        public int Year { get; set; }
        public string RecordType { get; set; }
        public bool OriginalRegister { get; set; }
        public int YearEnd { get; set; }
    }
}
