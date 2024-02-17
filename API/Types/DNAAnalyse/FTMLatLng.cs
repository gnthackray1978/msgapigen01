using HotChocolate.Types;

namespace Api.Types.DNAAnalyse
{
    public class FTMLatLngType : ObjectType<FTMLatLng>
    {
        protected override void Configure(IObjectTypeDescriptor<FTMLatLng> descriptor)
        {
           descriptor.Field(m => m.Id);
           descriptor.Field(m => m.Lat);
           descriptor.Field(m => m.Long);
           descriptor.Field(m => m.Weight);     
        }
    }
    
    public class FTMLatLng
    {
        public int Id { get; set; }         
        public double Lat { get; set; }
        public double Long { get; set; }  
        public int Weight { get; set; }
    }
}
