using MSGSharedData.Data.Services.interfaces.domain;

namespace MSGSharedData.Domain.Entities.Persistent.TDB
{
    public partial class Sources : IYearRange, Ilocation, ISourceRef
    {
        public int Id { get; set; }
        public string SourceRef { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public string SourceDateStr { get; set; }
        public string SourceDateStrTo { get; set; }
        public string SourceDescription { get; set; }
        public string Location { get; set; }
        public bool IsCopyHeld { get; set; }
        public bool IsViewed { get; set; }
        public bool IsThackrayFound { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserId { get; set; }
        public string SourceNotes { get; set; }
        public int SourceFileCount { get; set; }
    }
}
