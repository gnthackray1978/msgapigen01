using Api.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.DNAAnalyse
{
    public class PersonOfInterestType : ObjectType<PersonOfInterestSubset>
    {
        protected override void Configure(IObjectTypeDescriptor<PersonOfInterestSubset> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.PersonId);
           descriptor.Field(m => m.ChristianName);
           descriptor.Field(m => m.Surname);
           descriptor.Field(m => m.BirthYear);
           descriptor.Field(m => m.BirthPlace);
           descriptor.Field(m => m.BirthCounty);
           descriptor.Field(m => m.BirthCountry);
           descriptor.Field(m => m.TestDisplayName);
           descriptor.Field(m => m.TestAdminDisplayName);
           descriptor.Field(m => m.TreeUrl);
           descriptor.Field(m => m.TestGuid);
           descriptor.Field(m => m.Confidence);
           descriptor.Field(m => m.SharedCentimorgans);
           descriptor.Field(m => m.CreatedDate);
           descriptor.Field(m => m.RootsEntry);
           descriptor.Field(m => m.Memory);
           descriptor.Field(m => m.KitId);
           descriptor.Field(m => m.Name);
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
