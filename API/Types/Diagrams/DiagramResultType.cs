using Api.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.Diagrams
{
    public class DiagramResults<T>
    {
        public IEnumerable<T> rows { get; set; }
        
        public int TotalRows { get; set; }

        public int GenerationsCount { get; set; }

        public int MaxGenerationLength { get; set; }

        public string Error { get; set; }

        public string LoginInfo { get; set; }

        public string Title { get; set; }

    }

    //public class DiagramResultType<GraphT, ObjT> : ObjectType<DiagramResults<ObjT>>
    //    where GraphT : IGraphType
    //{
    //    public DiagramResultType()
    //    {
    //        Field<ListGraphType<GraphT>>(
    //            "results",
    //            resolve: context =>
    //            {
    //                return context.Source.results;
    //            }
    //        );
    //        Field(r => r.GenerationsCount);
    //        Field(r => r.TotalResults);
    //        Field(r => r.MaxGenerationLength);
    //        Field(r => r.Error);
    //        Field(r => r.LoginInfo);
    //    }
    //}

    //public class AncestorResult : DiagramResultType<AncestorNodeType, AncestorNode> { }

    //public class DescendantResult : DiagramResultType<DescendantNodeType, DescendantNode> { }
}
