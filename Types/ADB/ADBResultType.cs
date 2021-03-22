using GqlMovies.Api.Models;
using GraphQL.Types;

namespace Api.Types.DNAAnalyse
{
    public class ADBResultType<GraphT, ObjT> : ObjectGraphType<Results<ObjT>>
            where GraphT : IGraphType
    {
        public ADBResultType()
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

 //   public class DupeResult : ADBResultType<DupeType, Dupe> { }

}
