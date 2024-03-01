using MSGSharedData.Data.Services.interfaces.domain;

namespace MSGSharedData.Domain.Entities.NonPersistent.RequestQueries
{
    public class ADBMarriageParamObj : ISortable, Ilocation, IYearRange
    {
        //public MetaData Meta { get; set; } = new MetaData();

        public int Limit { get; set; }
        public int Offset { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public int YearStart { get; set; }
        public int YearEnd { get; set; }


        public string MaleSurname { get; set; }

        public string FemaleSurname { get; set; }

        public string Location { get; set; }
    }
}