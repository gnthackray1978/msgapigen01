using MSGSharedData.Data.Services.interfaces.domain;

namespace MSGSharedData.Domain.Entities.NonPersistent.RequestQueries
{
    public class DNASearchParamObj : ISurname, IYearRange, ISortable, Ilocation, ITesterName
    {
        //   public MetaData Meta { get; set; } = new MetaData();
        public string Location { get; set; }
        public string Surname { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public int MinCM { get; set; }
        public string TreeName { get; set; }
      //  public string Country { get; set; }
        public string Origin { get; set; }

        public string Name { get; set; }
    }
}