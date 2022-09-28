using Api.Services;

namespace AzureContext.Models
{
    public partial class TreeRecord : IOrigin, IGroupNumber
    {
        public int ID { get; set; }
        public string Name { get; set; } 
        public string Origin { get; set; }
        public int PersonCount { get; set; }
        public int CM { get; set; }
        public bool Located { get; set; }

        public string GroupNumber { get; set; }
    }
}
