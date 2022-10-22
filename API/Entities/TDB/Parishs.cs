using Api.Services.interfaces.domain;
using System;
using System.Collections.Generic;

namespace AzureContext.Models
{


    public partial class Parishs : ICounty, IParishName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParishRegistersDeposited { get; set; }
        public string ParishNotes { get; set; }
        public string ParentParish { get; set; }
        public int ParishStartYear { get; set; }
        public int ParishEndYear { get; set; }
        public string County { get; set; }
        public decimal ParishX { get; set; }
        public decimal ParishY { get; set; }
    }
}
