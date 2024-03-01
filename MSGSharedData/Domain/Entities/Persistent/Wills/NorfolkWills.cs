namespace MSGSharedData.Domain.Entities.Persistent.Wills;

public partial class NorfolkWills : IWill
{
    public int Id { get; set; }
    public string DateString { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Collection { get; set; } = null!;
    public string Reference { get; set; } = null!;
    public string Place { get; set; } = null!;
    public int Year { get; set; } 
    public int? Typ { get; set; }
    public string FirstName { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Occupation { get; set; } = null!;
    public string Aliases { get; set; } = null!;
}