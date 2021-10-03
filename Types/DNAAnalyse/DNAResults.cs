using GqlMovies.Api.Models;
using GraphQL.Types;

namespace Api.Types.DNAAnalyse
{

    public class DNAResultType<GraphT, ObjT> : ObjectGraphType<Results<ObjT>>
        where GraphT : IGraphType
    {
        public DNAResultType()
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

    public class DupeResult : DNAResultType<DupeType, Dupe> {}

    public class FTMViewResult : DNAResultType<FTMViewType, FTMView> {}

    public class FTMPersonLocationResult : DNAResultType<FTMPersonLocationType, FTMPersonLocation> { }


    public class PersonOfInterestResult : DNAResultType<PersonOfInterestType, PersonOfInterestSubset>  {}

    public class TreeRecResult : DNAResultType<TreeRecType, TreeRec>  {}
}
