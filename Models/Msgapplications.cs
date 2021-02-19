using System;
using System.Collections.Generic;

namespace Api.Models
{

    public partial class Msgapplications
    {
        public Msgapplications()
        {
            MsgapplicationMapGroup = new HashSet<MsgapplicationMapGroup>();
        }

        public int Id { get; set; }
        public string ApplicationName { get; set; }

        public string Description { get; set; }
        public int DefaultPage { get; set; }

        public bool Restricted { get; set; }

        public virtual ICollection<MsgapplicationMapGroup> MsgapplicationMapGroup { get; set; }
    }
}
