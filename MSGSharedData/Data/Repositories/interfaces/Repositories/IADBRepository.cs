using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.ADB;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;

namespace MSGSharedData.Data.Services.interfaces.services
{
    public interface IADBRepository
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
