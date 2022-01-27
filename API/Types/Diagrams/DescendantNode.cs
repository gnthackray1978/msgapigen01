using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.Diagrams
{

    public class DescendantNodeType : ObjectGraphType<DescendantNode>
    {
        public DescendantNodeType()
        {
            Field(m => m.Id);
            Field(m => m.GenerationIdx);
            Field(m => m.Index);

        }
    }


    public class DescendantNode
    {
        public int Id { get; set; }
        public int GenerationIdx { get; set; } 
        public int Index { get; set; } 
    }
}
