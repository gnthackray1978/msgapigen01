using GqlMovies.Api.Models;
using GraphQL.Types;

namespace GqlMovies.Api.Types
{
    public class SiteType : ObjectGraphType<Site>
	{
		public SiteType()
		{
			Field(m => m.Id);
			Field(m => m.Name);
			Field(m => m.Description);

        }
	}
}