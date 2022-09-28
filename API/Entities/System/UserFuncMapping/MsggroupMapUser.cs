using System;
using System.Collections.Generic;

namespace Api.Entities.System.UserFuncMapping
{
    public partial class MsggroupMapUser
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public string UserId { get; set; }

        public virtual Msggroups Group { get; set; }
    }
}
