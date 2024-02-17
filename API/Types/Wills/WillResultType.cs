//using Api.Models;
//using Api.Schema;
//using HotChocolate.Types;

//namespace Api.Types
//{
//    public class WillResultType : ObjectType<Results<WillResultType>> 
//    {
//        protected override void Configure(IObjectTypeDescriptor<WillResultType> descriptor)
//        {
//            descriptor.Field<ListGraphType<GraphT>>(
//                "results",
//                resolve: context =>
//                {
//                    return context.Source.results;
//                }
//            );
//            descriptor.Field(r => r.Page);
//            descriptor.Field(r => r.TotalResults);
//            descriptor.Field(r => r.TotalPages);
//            descriptor.Field(r => r.Error);
//            descriptor.Field(r => r.LoginInfo);
//        }
//    }
//}