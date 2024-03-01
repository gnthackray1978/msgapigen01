using HotChocolate.Types;

namespace Api.Schemas;

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