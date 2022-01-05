using GraphQL;
using GraphQL.Types;
using System;

namespace GqlMovies.Api.Schemas
{
	public class MainSchema : Schema
	{
		public MainSchema(IServiceProvider resolver): base(resolver)
		{
			Query = new Query();
		}
	}
}