using Api.Schema;
using GraphQL.Types;

namespace GqlMovies.Api.Schemas
{
	public class Query : ObjectGraphType
	{
		public Query()
		{
			Name = "Query";

			Field<SiteQuery>( "site", resolve: context => new{ });

			Field<ClaimQuery>("claim", resolve: context => new { });

			Field<SiteFunctionQuery>("function", resolve: context => new { });

			Field<WillQuery>("will", resolve: context => new { });

			Field<DNAQuery>("dna", resolve: context => new { });

			Field<ADBQuery>("adb", resolve: context => new { });
		}
	}
}