using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Field(m => m.BirthFrom);
            Field(m => m.BirthTo);

            Field(m => m.BirthLocation);
            Field(m => m.BirthLat);
            Field(m => m.BirthLong);

            Field(m => m.AltLocationDesc);
            Field(m => m.AltLocation);

            Field(m => m.AltLat);
            Field(m => m.AltLong);
             
        }
    }

    public class FTMView
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }

        public int BirthFrom { get; set; }
        public int BirthTo { get; set; }

        public string BirthLocation { get; set; }
        public double BirthLat { get; set; }
        public double BirthLong { get; set; }

        public string AltLocationDesc { get; set; }
        public string AltLocation { get; set; }
        public double AltLat { get; set; }
        public double AltLong { get; set; }

        public string Origin { get; set; }
        public int PersonId { get; set; }
    }
}
