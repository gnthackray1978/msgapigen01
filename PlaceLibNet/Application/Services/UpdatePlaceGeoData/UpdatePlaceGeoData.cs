using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Geocoder;
using GoogleMapsGeocoding;
using GoogleMapsGeocoding.Common;
using GoogleMapsHelpers;
using LoggingLib;
using MediatR;
using MSG.CommonTypes;
using MSGIdent;
using PlaceLibNet.Application.Models.Read;
using PlaceLibNet.Data.Repositories; 
using PlaceLibNet.Domain.Commands;
using PlaceLibNet.Domain.Entities;
using PlaceLibNet.Domain.Entities.Persistent;


namespace PlaceLibNet.Application.Services.UpdatePlaceGeoData
{
    public class UpdatePlaceGeoData : IRequestHandler<UpdatePlaceGeoDataCommand, CommandResult>
    {
        private readonly Ilog _iLog;
        private readonly IPlaceRepository _placeRepository;
        private readonly IMapper _iMapper;
        private readonly IAuth _auth;
        private readonly IGeocoder _geocoder;

        public UpdatePlaceGeoData(IPlaceRepository placeRepository, IGeocoder geocoder,
            Ilog iLog, IMapper iMapper, IAuth auth)
        {
            _iLog = iLog;
            _placeRepository = placeRepository;
            _iMapper = iMapper;
            _auth = auth;
            _geocoder = geocoder;
        }
         

        /// <summary>
        /// Updates place entry in cacheData.PlaceCache with result we got back from google geocode.
        /// </summary>
        /// <returns></returns>
        public async Task<CommandResult> Handle(UpdatePlaceGeoDataCommand request, CancellationToken cancellationToken)
        {
            if (_auth.GetUser() == -1)
            {
                return CommandResult.Fail(CommandResultType.Unauthorized);
            }

            _iLog.WriteLine("Updating cacheData.FTMPlaceCache with geocode result",2);

            IEnumerable<PlaceLookup> locations = new List<PlaceLookup>();

            await Task.Run(() =>
            {
                locations = _placeRepository
                    .GetUnknownPlacesIgnoreSearchedAlready().Take(request.Amount);
            }, cancellationToken);

            // we've got the stuff that needs looking up now.

            List<PlaceCache> updatedCacheEntries = new List<PlaceCache>();

            foreach (var location in locations)
            {
                _iLog.WriteLine("Geocoding: " + location.PlaceFormatted, 2);

                var result = _geocoder.Geocode(location.PlaceFormatted);

                Thread.Sleep(request.Delay);

                if (result.Status == GlobalConstants.OK_STATUS)
                {
                    var locationInfo = GeocodeResponse.GetLocationInfo(result);

                    updatedCacheEntries.Add(new PlaceCache()
                    {
                        Country = locationInfo.Country,
                        County = locationInfo.County,
                        DateCreated = DateTime.Today,
                        JSONResult = "[]",
                        Searched = true,
                        Name = location.Place,
                        NameFormatted = location.PlaceFormatted,
                        Src = "google_internal",
                        Long = locationInfo.lng.ToString(),
                        Lat = locationInfo.lat.ToString(),
                        BadData = false,
                        Id = location.PlaceId
                    });
                }

                if (result.Status == GlobalConstants.ZERO_RESULTS_STATUS)
                {
                    _iLog.WriteLine("Zero Results", 2);

                    updatedCacheEntries.Add(new PlaceCache()
                    {
                        Country = "",
                        County = "",
                        DateCreated = DateTime.Today,
                        JSONResult = "[]",
                        Searched = true,
                        Name = location.Place,
                        NameFormatted = location.PlaceFormatted,
                        Src = "google_internal",
                        Long = "0",
                        Lat = "0",
                        BadData = true,
                        Id = location.PlaceId
                    });
                }

                if (result.Status == GlobalConstants.INVALID_REQUEST_STATUS)
                {
                    _iLog.WriteLine("Invalid Request", 2);
                }

                if (result.Status == GlobalConstants.OVER_QUERY_LIMIT_STATUS)
                {
                    _iLog.WriteLine("Over Query Limit", 2);
                    break;
                }


            }

            await Task.Run(() => { _placeRepository.UpdateCacheEntries(updatedCacheEntries); }, cancellationToken);

            _iLog.WriteLine("Update Finished", 2);

            return CommandResult.Success();
        }
    }
}
