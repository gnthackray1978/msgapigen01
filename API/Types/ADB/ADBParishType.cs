using HotChocolate.Types;

namespace Api.Types.ADB
{
    public class ADBParishType : ObjectType<ADBParish>
    {
        protected override void Configure(IObjectTypeDescriptor<ADBParish> descriptor)
        {

           descriptor.Field(m => m.Id);

           descriptor.Field(m => m.ParishName);
           descriptor.Field(m => m.ParishRegistersDeposited);
           descriptor.Field(m => m.ParishNotes);
           descriptor.Field(m => m.ParentParish);
           descriptor.Field(m => m.ParishStartYear);
           descriptor.Field(m => m.ParishEndYear);
           descriptor.Field(m => m.ParishCounty);
           descriptor.Field(m => m.ParishX);
           descriptor.Field(m => m.ParishY);
        }

    }

    public class ADBParish
    {
        public int Id { get; set; }
        public string ParishName { get; set; }
        public string ParishRegistersDeposited { get; set; }
        public string ParishNotes { get; set; }
        public string ParentParish { get; set; }
        public int ParishStartYear { get; set; }
        public int ParishEndYear { get; set; }
        public string ParishCounty { get; set; }
        public decimal ParishX { get; set; }
        public decimal ParishY { get; set; }
    }
}