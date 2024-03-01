namespace MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse;

public class FTMPersonSummary
{
    public int Id { get; set; }

    public string TreeName { get; set; }

    public string FirstName { get; set; }
    public string Surname { get; set; }

    public int YearStart { get; set; }
    public int YearEnd { get; set; }

}