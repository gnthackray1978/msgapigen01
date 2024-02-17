using Api.Services.interfaces.domain;

namespace Api.Types.RequestQueries
{
    public class ADBSourceParamObj : IYearRange, ISortable, Ilocation
    {

    //    public MetaData Meta { get; set; } = new MetaData();

        public string SourceRef { get; set; }

        public string Location { get; set; }


        public int Limit { get; set; }
        public int Offset { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public int YearFrom { get; set; }
        public int YearTo { get; set; }
    }
}