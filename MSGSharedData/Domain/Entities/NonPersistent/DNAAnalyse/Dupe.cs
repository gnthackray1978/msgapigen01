namespace MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse
{
    public class Dupe
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Ident { get; set; }
        public string Origin { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public string Location { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
