using Api.Models;
using HotChocolate.Types;

namespace Api.Types.ADB
{
    public class ADBParishRecType : ObjectType<ADBParishRec>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBParishRec> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.ParishId);
           descriptor.Field(m => m.DataTypeId);
           descriptor.Field(m => m.Year);
           descriptor.Field(m => m.RecordType);
           descriptor.Field(m => m.OriginalRegister);
           descriptor.Field(m => m.YearEnd);
        }
    }

    public class ADBParishRec
    {
        public int Id { get; set; }
        public int ParishId { get; set; }
        public int DataTypeId { get; set; }
        public int Year { get; set; }
        public string RecordType { get; set; }
        public bool OriginalRegister { get; set; }
        public int YearEnd { get; set; }
    }
}
