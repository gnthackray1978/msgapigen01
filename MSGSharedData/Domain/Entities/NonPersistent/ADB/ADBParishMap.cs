namespace MSGSharedData.Domain.Entities.NonPersistent.ADB;

public class ADBParishMap
{
    public int Id { get; set; }
    public int? SourceMappingParishId { get; set; }
    public int? SourceMappingSourceId { get; set; }
    public DateTime? SourceMappingDateAdded { get; set; }
    public int? SourceMappingUser { get; set; }
}