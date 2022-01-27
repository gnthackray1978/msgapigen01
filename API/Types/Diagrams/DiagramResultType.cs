using GqlMovies.Api.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Types.Diagrams
{
    public class DiagramResultType<GraphT, ObjT> : ObjectGraphType<Results<ObjT>>
        where GraphT : IGraphType
    {
        public DiagramResultType()
        {
            Field<ListGraphType<GraphT>>(
                "results",
                resolve: context =>
                {
                    return context.Source.results;
                }
            );
            Field(r => r.Page);
            Field(r => r.TotalResults);
            Field(r => r.TotalPages);
            Field(r => r.Error);
            Field(r => r.LoginInfo);
        }
    }

    public class AncestorResult : DiagramResultType<AncestorNodeType, AncestorNode> { }

    public class DescendantResult : DiagramResultType<DescendantNodeType, DescendantNode> { }
}
