using System;
using System.Collections.Generic;

namespace Api.Entities.System.Auth
{
    public partial class ClientIdPrestrictions
    {
        public int Id { get; set; }
        public string Provider { get; set; }
        public int ClientId { get; set; }

        public virtual Clients Client { get; set; }
    }
}
