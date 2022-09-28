using System;
using System.Collections.Generic;

namespace AzureContext.Models
{
    public partial class ParishTranscriptionDetails
    {
        public int Id { get; set; }
        public int ParishId { get; set; }
        public string ParishDataString { get; set; }
    }
}
