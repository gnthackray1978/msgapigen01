using MSGSharedData.Domain.Entities.NonPersistent;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;
using MSGSharedData.Domain.Entities.NonPersistent.Wills;

namespace MSGSharedData.Data.Services.interfaces.services
{
    public interface IWillListRepository
    {
        Task<Will> GetAsync(int id);

        Task<Results<Will>> LincolnshireWillsList(WillSearchParamObj searchParams);

        Task<Results<Will>> NorfolkWillsList(WillSearchParamObj searchParams);

    }
}
