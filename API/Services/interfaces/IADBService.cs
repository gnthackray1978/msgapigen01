using Api.Types;
using Api.Types.ADB;
using System.Threading.Tasks;
using Api.Schema;

namespace Api.Services.interfaces
{
    public interface IADBService
    {   
        Task<Results<ADBInternalSourceType>> SourceTypeList(ADBSourceParamObj searchParams);

        Task<Results<ADBMarriage>> MarriageList(ADBMarriageParamObj aDBMarriageParamObj);

        Task<Results<ADBParishData>> ParishDataList(int parishId);

        Task<Results<ADBParishMap>> ParishSourceMappingsList(ADBParishParamObj aDBParishParamObj);

        Task<Results<ADBParishRec>> ParishRecList(int parishId);

        Task<Results<ADBParish>> ParishList(ADBParishParamObj aDBParishParamObj);

        Task<Results<ADBPerson>> PersonList(ADBPersonParamObj aDBPersonParamObj);

        Task<Results<ADBRecSource>> RecSourceList(ADBSourceParamObj aDBSourceParamObj);

        Task<Results<ADBSourceMap>> SourceMapList(ADBSourceParamObj aDBSourceParamObj);

        Task<Results<ADBSource>> SourceList(ADBSourceParamObj aDBSourceParamObj);
    }

}
