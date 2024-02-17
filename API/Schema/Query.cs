using Api.Models;
using Api.Schema.SubQueries;
using HotChocolate.Types;

namespace Api.Schemas
{

    public class Query
    {
        public string SiteQuery() => "site";
        public string ClaimQuery() => "claim";
        public string SiteFunctionQuery() => "function";
        public string WillQuery() => "will";
        public string DNAQuery() => "dna";
        public string ADBQuery() => "adb";
        public string ImageQuery() => "image";
        public string DiagramQuery() => "diagram";
        public string BlogQuery() => "blog";
    }

    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            Name = "Query";

            descriptor.Field(_=>_.ADBQuery()).Resolve(context => new { });

            descriptor.Field(_ => _.ClaimQuery()).Resolve(context => new { });

            descriptor.Field(_ => _.SiteFunctionQuery()).Resolve(context => new { });

            descriptor.Field(_ => _.WillQuery()).Resolve(context => new { });

            descriptor.Field(_ => _.DNAQuery()).Resolve(context => new { });

            descriptor.Field(_ => _.ADBQuery()).Resolve(context => new { });

            descriptor.Field(_ => _.ImageQuery()).Resolve(context => new { });

            descriptor.Field(_ => _.DiagramQuery()).Resolve(context => new { });

            descriptor.Field(_ => _.BlogQuery()).Resolve(context => new { });
        }
	}
}