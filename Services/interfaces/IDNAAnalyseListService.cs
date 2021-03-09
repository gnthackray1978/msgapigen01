using Api.Types;
using Api.Types.DNAAnalyse;
using GqlMovies.Api.Models;
using System.Threading.Tasks;

namespace Api.Services.interfaces
{
    public interface IDNAAnalyseListService
    {
        Task<Results<Dupe>> DupeList(DNASearchParamObj searchParams);

        Task<Results<FTMView>> FTMViewList(DNASearchParamObj searchParams);

        Task<Results<TreeRec>> TreeList(DNASearchParamObj searchParams);

        Task<Results<PersonOfInterestSubset>> PersonOfInterestList(DNASearchParamObj searchParams);

    }

    }
