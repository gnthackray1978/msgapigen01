using Api.Types.Images;
using GraphQL.Types;

namespace Api.Models
{
    public class ApiImagesType<GraphT, ObjT> : ObjectGraphType<Results<ObjT>>
      where GraphT : IGraphType
    {
        public ApiImagesType()
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

    public class ApiImagesResult : ApiImagesType<ApiImagesType, ApiImage> { }

    public class ApiParentImagesResult : ApiImagesType<ApiParentImagesType, ApiParentImages> { }


}

