namespace MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse
{
    public class FTMView
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }

        public int YearStart { get; set; }
        public int YearEnd { get; set; }

        public string Location { get; set; }
        public decimal BirthLat { get; set; }
        public decimal BirthLong { get; set; }

        public string AltLocationDesc { get; set; }
        public string AltLocation { get; set; }
        public decimal AltLat { get; set; }
        public decimal AltLong { get; set; }

        public string Origin { get; set; }
        public int PersonId { get; set; }

        public bool DirectAncestor { get; set; }
    }
}
