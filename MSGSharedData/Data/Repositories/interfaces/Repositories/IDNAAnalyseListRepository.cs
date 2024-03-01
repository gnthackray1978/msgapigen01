using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;

namespace MSGSharedData.Data.Services.interfaces.services
{
    public interface IDNAAnalyseListRepository
    {
        Task<Results<Dupe>> DupeList(DNASearchParamObj searchParams);

        Task<Results<FTMView>> FTMViewList(DNASearchParamObj searchParams);

        Task<Results<FTMLatLng>> FTMLatLngList(DNASearchParamObj searchParams);

        Task<Results<FTMPersonLocation>> FTMLocSearch(DNASearchParamObj searchParams);

        Task<Results<FTMView>> FTMViewPlaces(DNASearchParamObj searchParams);

        Task<Results<TreeRec>> TreeList(DNASearchParamObj searchParams);

        Task<Results<PersonOfInterestSubset>> PersonOfInterestList(DNASearchParamObj searchParams);



    }

}
