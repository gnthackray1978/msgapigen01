using Api.Services.interfaces.domain;

namespace AzureContext.Models
{
    public partial class Relationships : IOrigin
    {
        
        public int Id { get; set; }

        public int GroomId { get; set; }

        public int BrideId { get; set; }


        public string Notes { get; set; }
        public string DateStr { get; set; }

        public int Year { get; set; }

        public string Location { get; set; }

        public int Origin { get; set; }
    }
}
