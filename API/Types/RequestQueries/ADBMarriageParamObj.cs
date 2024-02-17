using Api.Services.interfaces.domain;

namespace Api.Types.RequestQueries
{
    public class ADBMarriageParamObj : ISortable, Ilocation, IYearRange
    {
        //public MetaData Meta { get; set; } = new MetaData();

        public int Limit { get; set; }
        public int Offset { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public int YearFrom { get; set; }
        public int YearTo { get; set; }


        public string MaleSurname { get; set; }

        public string FemaleSurname { get; set; }

        public string Location { get; set; }
    }
}