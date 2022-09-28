using Api.Types;
using Api.Types.DNAAnalyse;
using System.Threading.Tasks;
using Api.Schema;

namespace Api.Services.interfaces
{
    public interface IDNAAnalyseListService
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
