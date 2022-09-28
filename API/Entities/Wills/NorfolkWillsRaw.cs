using System;
using System.Collections.Generic;

namespace Api.Models.Wills
{
    public partial class NorfolkWillsRaw
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string DateRange { get; set; }
        public string CatalogueRef { get; set; }
    }
}
