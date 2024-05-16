using System.Threading;
using System.Threading.Tasks;
using LoggingLib;
using MediatR;
using MSG.CommonTypes;
using MSGIdent;
using PlaceLibNet.Data.Repositories;
using PlaceLibNet.Domain.Caching;
using PlaceLibNet.Domain.Commands;

namespace PlaceLibNet.Application.Services.UpdatePlaceMetaData
{
    /// <summary>
    /// shouldn't be needed now!
    /// these fields are set when geocode has finished.
    /// 
    /// Update place cache lat long
    /// Update place cache county
    /// Update place cache bad data where appropriate
    /// </summary>
    public class UpdatePlaceMetaData : IRequestHandler<UpdatePlaceMetaDataCommand, CommandResult>
    {
        private readonly Ilog _iLog;
        private readonly IPlaceRepository _placeRepository;
        private readonly IAuth _auth;

        public UpdatePlaceMetaData(IPlaceRepository placeRepository, Ilog iLog, IAuth auth)
        {
            _iLog = iLog;
            _auth = auth;
            _placeRepository = placeRepository;
        }
         
        /// <summary>
        /// Update place cache lat long
        /// Update place cache county
        /// Update place cache bad data where appropriate
        /// </summary>
        public async Task<CommandResult> Handle(UpdatePlaceMetaDataCommand request, CancellationToken cancellationToken)
        {
            if (_auth.GetUser() == -1)
            {
                return CommandResult.Fail(CommandResultType.Unauthorized);
            }

            _iLog.WriteLine("Updating Place MetaData Started", 2);

            await Task.Run(()=>{

                _placeRepository.SetGeolocatedResult();
                _iLog.WriteLine("Geolocations set", 2);
                _placeRepository.SetCounties();
                _iLog.WriteLine("Counties set", 2);
            }, cancellationToken);
            _iLog.WriteLine("Updating Place MetaData Finished", 2);

            return CommandResult.Success();
        }
    }
}
