using Api.Schema.SubQueries;
using GraphQL.Types;

namespace Api.Schemas
{
    public class Query : ObjectGraphType
	{
		public Query()
		{
			Name = "Query";

            Field<SiteQuery>("site").Resolve(context => new { });

			Field<ClaimQuery>("claim").Resolve(context => new { });

			Field<SiteFunctionQuery>("function").Resolve(context => new { });

			Field<WillQuery>("will").Resolve(context => new { });

			Field<DNAQuery>("dna").Resolve(context => new { });

			Field<ADBQuery>("adb").Resolve(context => new { });

			Field<ImageQuery>("image").Resolve(context => new { });

			Field<DiagramQuery>("diagram").Resolve(context => new { });

            Field<BlogQuery>("blog").Resolve(context => new { });
		}
	}
}