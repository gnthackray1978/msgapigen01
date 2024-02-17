using System.Collections.Generic;

namespace Api.Services.interfaces.domain
{
    public interface IHeatMapSearch : IYearRange
    {
        List<string> GetOrigins();
    }
}