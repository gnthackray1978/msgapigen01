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
		}
	}
}