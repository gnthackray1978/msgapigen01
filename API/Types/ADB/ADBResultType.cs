//using Api.Types.ADB;
//using HotChocolate.Types;
//using Api.Schema;

//namespace Api.Types.DNAAnalyse
//{
//    public class ADBResultType<GraphT, ObjT> : ObjectType<Results<ObjT>>
//            where GraphT : IGraphType
//    {
//        public ADBResultType()
//        {
//            Field<ListGraphType<GraphT>>(
//                "results",
//                resolve: context =>
//                {
//                    return context.Source.results;
//                }
//            );
//            Field(r => r.Page);
//            Field(r => r.TotalResults);
//            Field(r => r.TotalPages);
//            Field(r => r.Error);
//        }
//    }

//    public class MarriageSearchResult : ADBResultType<ADBMarriageType, ADBMarriage> { }

//    public class PersonSearchResult : ADBResultType<ADBPersonType, ADBPerson> { }

//    public class ParishSearchResult : ADBResultType<ADBParishType, ADBParish> { }

//    public class SourceSearchResult : ADBResultType<ADBSourceType, ADBSource> { }

//}
