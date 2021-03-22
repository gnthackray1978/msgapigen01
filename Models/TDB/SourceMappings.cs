using System;
using System.Collections.Generic;

namespace AzureContext.Models
{
    public partial class SourceMappings
    {
        public int Id { get; set; }
        public int? SourceId { get; set; }
        public int? MarriageRecordId { get; set; }
         
        public int? PersonRecordId { get; set; }
         
        public DateTime? DateAdded { get; set; }
        public int? MapTypeId { get; set; }
    }
}
