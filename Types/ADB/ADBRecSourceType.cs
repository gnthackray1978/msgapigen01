using GraphQL.Types;

namespace Api.Types.ADB
{
    public class ADBRecSourceType : ObjectGraphType<ADBRecSource>
    {
        public ADBRecSourceType() {
            Field(m => m.Id);
            Field(m => m.RecordTypeName);
            Field(m => m.RecordTypeDescription);
        }
    }


    public class ADBRecSource
    {
        public int Id { get; set; }
        public string RecordTypeName { get; set; }
        public string RecordTypeDescription { get; set; }
    }
}
 