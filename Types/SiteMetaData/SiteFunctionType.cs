using GqlMovies.Api.Models;
using GraphQL.Types;

namespace GqlMovies.Api.Types
{
    public class SiteFunctionType : ObjectGraphType<SiteFunction>
	{
		public SiteFunctionType()
		{
			Field(m => m.Id);
			Field(m => m.Name);
			Field(m => m.Description);
			Field(m => m.PageName);
			Field(m => m.PageTitle);
		}
	}

}