using GraphQL.Types;
using System.Collections.Generic;

namespace Api.Types.DNAAnalyse
{
    public class FTMPersonLocation
    {
        public int Id { get; set; }
         
        public double BirthLat { get; set; }
        public double BirthLong { get; set; }
        public string LocationName { get; set; }

        public List<FTMPersonSummary> FTMPersonSummary { get; set; }

    }

    public class FTMPersonLocationType : ObjectGraphType<FTMPersonLocation>
    {
        public FTMPersonLocationType()
        {
            Field(x => x.Id);
            Field(x => x.BirthLat);
            Field(x => x.BirthLong);
            Field(x => x.LocationName);
            Field<ListGraphType<FTMPersonSummaryType>>("ftmPersonSummary");
        }
    }


    public class FTMPersonSummary
    {
        public int Id { get; set; }

        public string TreeName { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }

        public int YearFrom { get; set; }
        public int YearTo { get; set; }

    }

    public class FTMPersonSummaryType : ObjectGraphType<FTMPersonSummary>
    {
        public FTMPersonSummaryType()
        {
            Field(x => x.Id);
            Field(x => x.TreeName);
            Field(x => x.FirstName);
            Field(x => x.Surname);
            Field(x => x.YearFrom);
            Field(x => x.YearTo);
        }
    }


}
