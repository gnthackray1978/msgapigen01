using Api.Services;

namespace AzureContext.Models
{
    public partial class DupeEntry : IYearRange , IName, Ilocation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Ident { get; set; }
        public string Origin { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public string Location { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
