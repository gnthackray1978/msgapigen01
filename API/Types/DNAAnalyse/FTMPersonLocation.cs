using Api.Models;
using HotChocolate.Types;
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

    public class FTMPersonLocationType : ObjectType<FTMPersonLocation>
    {
        protected override void Configure(IObjectTypeDescriptor<FTMPersonLocation> descriptor)
        {
           descriptor.Field(x => x.Id);
           descriptor.Field(x => x.BirthLat);
           descriptor.Field(x => x.BirthLong);
           descriptor.Field(x => x.LocationName);

        //   descriptor.Field<List<FTMPersonSummaryType>>("ftmPersonSummary");
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

    public class FTMPersonSummaryType : ObjectType<FTMPersonSummary>
    {
        protected override void Configure(IObjectTypeDescriptor<FTMPersonSummary> descriptor)
        {
           descriptor.Field(x => x.Id);
           descriptor.Field(x => x.TreeName);
           descriptor.Field(x => x.FirstName);
           descriptor.Field(x => x.Surname);
           descriptor.Field(x => x.YearFrom);
           descriptor.Field(x => x.YearTo);
        }
    }


}
