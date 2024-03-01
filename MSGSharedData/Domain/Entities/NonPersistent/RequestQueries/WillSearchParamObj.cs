using MSGSharedData.Data.Services.interfaces.domain;

namespace MSGSharedData.Domain.Entities.NonPersistent.RequestQueries
{


    public class WillSearchParamObj //: IYearRange, ISortable
    {
        //    public MetaData Meta { get; set; } = new MetaData();

      //  public string Error { get; set; }

        //public string LoginInfo { get; set; }


        public string RefArg { get; set; }

        public string Desc { get; set; }

        public string Place { get; set; }

        public string Surname { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }

        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public int YearFrom { get; set; }
        public int YearTo { get; set; }

    }
}
