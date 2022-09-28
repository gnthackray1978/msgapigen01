using System;
using System.Collections.Generic;

namespace Api.Entities.System.Auth
{
    public partial class Functions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Restricted { get; set; }
    }
}
