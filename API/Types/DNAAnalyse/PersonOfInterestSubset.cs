using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.DNAAnalyse
{
    public class PersonOfInterestType : ObjectGraphType<PersonOfInterestSubset>
    {
        public PersonOfInterestType()
        {
            Field(m => m.Id);
            Field(m => m.PersonId);
            Field(m => m.ChristianName);
            Field(m => m.Surname);
            Field(m => m.BirthYear);
            Field(m => m.BirthPlace);
            Field(m => m.BirthCounty);
            Field(m => m.BirthCountry);
            Field(m => m.TestDisplayName);
            Field(m => m.TestAdminDisplayName);
            Field(m => m.TreeUrl);
            Field(m => m.TestGuid);
            Field(m => m.Confidence);
            Field(m => m.SharedCentimorgans);
            Field(m => m.CreatedDate);
            Field(m => m.RootsEntry);
            Field(m => m.Memory);
            Field(m => m.KitId);
            Field(m => m.Name);
        }
    }


    public class PersonOfInterestSubset
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public string ChristianName { get; set; }
        public string Surname { get; set; }
        public int BirthYear { get; set; }
        public string BirthPlace { get; set; }
        public string BirthCounty { get; set; }
        public string BirthCountry { get; set; }
        public string TestDisplayName { get; set; }
        public string TestAdminDisplayName { get; set; }
        public string TreeUrl { get; set; }
        public Guid TestGuid { get; set; }
        public double Confidence { get; set; }
        public double SharedCentimorgans { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool RootsEntry { get; set; }
        public string Memory { get; set; }
        public Guid KitId { get; set; }
        public string Name { get; set; }
    }
}
