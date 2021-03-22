using System;
using System.Collections.Generic;

namespace AzureContext.Models
{
    public partial class SourceMappingParishs
    {
        public int Id { get; set; }
        public int? SourceMappingParishId { get; set; }
        public int? SourceMappingSourceId { get; set; }
        public DateTime? SourceMappingDateAdded { get; set; }
        public int? SourceMappingUser { get; set; }
    }
}
