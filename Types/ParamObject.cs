using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Types
{
	   
	public class ParamObject
    {
        public string RefArg { get; set; }

        public string Desc { get; set; }

        public string Place { get; set; }

        public string Surname { get; set; }
        public int First { get; set; }
        public int Offset { get; set; }
        public ClaimsPrincipal User { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }

        public int YearStart { get; set; }
        public int YearEnd { get; set; }

    }
}
