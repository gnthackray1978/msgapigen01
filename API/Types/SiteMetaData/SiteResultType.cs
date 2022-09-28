using System.Collections.Generic;
using Api.Schema;
using GraphQL.Types;

namespace Api.Types
{
    public class SiteResultType<GraphT, ObjT> : ObjectGraphType<Results<ObjT>> where GraphT : IGraphType
    {
        public SiteResultType()
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
        }
    }

    public class SiteFunctionResultType<GraphT, ObjT> : ObjectGraphType<Results<ObjT>> where GraphT : IGraphType
    {
        public SiteFunctionResultType()
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
        }
    }
}