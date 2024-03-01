namespace MSGSharedData.Data.Services.interfaces.domain
{
    public interface IPreciseLocation : Ilocation
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }

    }
}