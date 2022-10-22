namespace Api.Services.interfaces.domain
{
    public interface IPreciseLocation : Ilocation
    {
        public double BirthLat { get; set; }
        public double BirthLong { get; set; }

    }
}