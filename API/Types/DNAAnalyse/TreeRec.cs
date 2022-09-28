using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.DNAAnalyse
{
    public class TreeRecType : ObjectGraphType<TreeRec>
    {
        public TreeRecType()
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field(m => m.Origin);
            Field(m => m.PersonCount);
            Field(m => m.CM);
            Field(m => m.Located);
            Field(m => m.GroupNumber);
        }
    }

    public class TreeRec
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public int PersonCount { get; set; }

        public string GroupNumber { get; set; }

        public int CM { get; set; }
        public bool Located { get; set; }
    }
}
