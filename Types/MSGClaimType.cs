using GqlMovies.Api.Models;
using GraphQL.Types;

namespace GqlMovies.Api.Types
{
    public class MSGClaimType : ObjectGraphType<MSGClaim>
	{
		public MSGClaimType()
		{
			Field(m => m.Id);
			Field(m => m.Name);
			Field(m => m.Subject);
			Field(m => m.Type);
			Field(m => m.Value);

		}
	}
}