namespace MSGSharedData.Domain.Entities.Persistent.TDB;

public partial class ImageParents
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Info { get; set; }
    public int From { get; set; }
    public int To { get; set; }
    public string Page { get; set; }
}