namespace MSGSharedData.Domain.Entities.NonPersistent.ADB;

public class ADBParish
{
    public int Id { get; set; }
    public string ParishName { get; set; }
    public string ParishRegistersDeposited { get; set; }
    public string ParishNotes { get; set; }
    public string ParentParish { get; set; }
    public int ParishStartYear { get; set; }
    public int ParishEndYear { get; set; }
    public string ParishCounty { get; set; }
    public decimal ParishX { get; set; }
    public decimal ParishY { get; set; }
}