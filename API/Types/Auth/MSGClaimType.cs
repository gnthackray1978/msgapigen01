using Api.Models;
using HotChocolate.Types;

namespace Api.Types
{
    public class MSGClaimType : ObjectType<MSGClaim>
	{
        protected override void Configure(IObjectTypeDescriptor<MSGClaim> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.Name);
           descriptor.Field(m => m.Subject);
           descriptor.Field(m => m.Type);
           descriptor.Field(m => m.Value);

		}
	}

}