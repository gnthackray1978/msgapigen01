using System;
using System.Collections.Generic;

namespace AzureContext.Models
{
    public partial class ParishRecordSource
    {
        public int Id { get; set; }
        public string RecordTypeName { get; set; }
        public string RecordTypeDescription { get; set; }
    }
}
