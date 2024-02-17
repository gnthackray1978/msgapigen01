using Api.Models;
using HotChocolate.Types;

namespace Api.Types.DNAAnalyse
{
    public class FTMViewType : ObjectType<FTMView>
    {
        protected override void Configure(IObjectTypeDescriptor<FTMView> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.PersonId);
           descriptor.Field(m => m.FirstName);
           descriptor.Field(m => m.Surname);        
           descriptor.Field(m => m.Origin);
           descriptor.Field(m => m.YearFrom);
           descriptor.Field(m => m.YearTo);

           descriptor.Field(m => m.Location);
           descriptor.Field(m => m.BirthLat);
           descriptor.Field(m => m.BirthLong);

           descriptor.Field(m => m.AltLocationDesc);
           descriptor.Field(m => m.AltLocation);

           descriptor.Field(m => m.AltLat);
           descriptor.Field(m => m.AltLong);
           descriptor.Field(m => m.DirectAncestor);
        }
    }


    public class FTMView
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }

        public int YearFrom { get; set; }
        public int YearTo { get; set; }

        public string Location { get; set; }
        public double BirthLat { get; set; }
        public double BirthLong { get; set; }

        public string AltLocationDesc { get; set; }
        public string AltLocation { get; set; }
        public double AltLat { get; set; }
        public double AltLong { get; set; }

        public string Origin { get; set; }
        public int PersonId { get; set; }

        public bool DirectAncestor { get; set; }
    }
}
