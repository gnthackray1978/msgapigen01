namespace MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse
{
    public class FTMPersonLocation
    {
        public int Id { get; set; }

        public decimal BirthLat { get; set; }
        public decimal BirthLong { get; set; }
        public string LocationName { get; set; }

        public List<FTMPersonSummary> FTMPersonSummary { get; set; }

    }
}
