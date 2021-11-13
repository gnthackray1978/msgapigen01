using GqlMovies.Api.Models;
using GraphQL.Types;

namespace GqlMovies.Api.Types
{
    public class WillResultType<GraphT, ObjT> : ObjectGraphType<Results<ObjT>> 
        where GraphT : IGraphType
    {
        public WillResultType()
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
}