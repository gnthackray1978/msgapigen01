using Api.Services;
using System;
using System.Collections.Generic;

namespace AzureContext.Models
{
    public partial class PersonsOfInterest : ISingleYear, IName, Ilocation, IShardCMs, ITesterName
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public string ChristianName { get; set; }
        public string Surname { get; set; }
        public int Year { get; set; }
        public string Location { get; set; }
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
