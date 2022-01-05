using GraphQL.Types;

namespace Api.Types.ADB
{
    public class ADBISourceType : ObjectGraphType<ADBInternalSourceType>
    {
        public ADBISourceType()
        {
            Field(m => m.Id);
            Field(m => m.SourceTypeDesc);
            Field(m => m.SourceDateAdded);
        }
    }

    public class ADBInternalSourceType
    {
        public int Id { get; set; }
        public string SourceTypeDesc { get; set; }
        public string SourceDateAdded { get; set; }
    }
}
