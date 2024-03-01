namespace MSGSharedData.Domain.Entities.NonPersistent.ADB;

public class ADBSourceMap
{
    public int Id { get; set; }
    public int? SourceId { get; set; }
    public int? MarriageRecordId { get; set; }
    public int? PersonRecordId { get; set; }
    public DateTime? DateAdded { get; set; }
    public int? MapTypeId { get; set; }
}