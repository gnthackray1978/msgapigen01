using GraphQL.Types;

namespace Api.Types.DNAAnalyse
{
    public class FTMViewType : ObjectGraphType<FTMView>
    {
        public FTMViewType()
        {
            Field(m => m.Id);
            Field(m => m.PersonId);
            Field(m => m.FirstName);
            Field(m => m.Surname);        
            Field(m => m.Origin);
            Field(m => m.YearFrom);
            Field(m => m.YearTo);

            Field(m => m.Location);
            Field(m => m.BirthLat);
            Field(m => m.BirthLong);

            Field(m => m.AltLocationDesc);
            Field(m => m.AltLocation);

            Field(m => m.AltLat);
            Field(m => m.AltLong);
            Field(m => m.DirectAncestor);
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
