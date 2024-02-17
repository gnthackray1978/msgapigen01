using Api.Models;
using HotChocolate.Types;

namespace Api.Types.ADB
{
    public class ADBISourceType : ObjectType<ADBInternalSourceType>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBInternalSourceType> descriptor)
        {
            descriptor.Field(m => m.Id);
            descriptor.Field(m => m.SourceTypeDesc);
            descriptor.Field(m => m.SourceDateAdded);
        }
    }

    public class ADBInternalSourceType
    {
        public int Id { get; set; }
        public string SourceTypeDesc { get; set; }
        public string SourceDateAdded { get; set; }
    }
}
