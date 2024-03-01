namespace MSGSharedData.Data.Services.interfaces.domain
{
    public interface IHeatMapSearch : IYearRange
    {
        List<string> GetOrigins();
    }
}