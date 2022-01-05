using GraphQL.Types;

namespace Api.Types.ADB
{
    public class ADBParishDataType : ObjectGraphType<ADBParishData>
    {
        public ADBParishDataType()
        {
            Field(m => m.Id);
            Field(m => m.ParishId);
            Field(m => m.ParishDataString);
        }
    }

    public class ADBParishData
    {
        public int Id { get; set; }
        public int ParishId { get; set; }
        public string ParishDataString { get; set; }

    }
}
 