using Api.Services;

namespace AzureContext.Models
{
    public partial class FTMPersonView : IYearRange, IName, IPreciseLocation, IOrigin
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
        public int? PersonId { get; set; }

        public int? FatherId { get; set; }

        public int? MotherId { get; set; }
    }
}
