﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LoggingLib;
using MediatR;
using PlaceLibNet.Application.Models.Read;
using PlaceLibNet.Data.Repositories;

namespace PlaceLibNet.Application.Services.GetPlaceInfoService
{
    public class GetPlaceInfoService: IRequestHandler<GetPlaceInfoQuery, PlaceInfoModel>
    {
        private readonly Ilog _iLog;
        private readonly IPlaceRepository _placeRepository;

        public GetPlaceInfoService(IPlaceRepository placeRepository, Ilog outputHandler)
        {
            _iLog = outputHandler;
            _placeRepository = placeRepository;
        }
         

        public async Task<PlaceInfoModel> Handle(GetPlaceInfoQuery request, CancellationToken cancellationToken)
        {
            _iLog.WriteLine("Refreshed Place Info",1);

            var infoModal = new PlaceInfoModel();

            await Task.Run(() =>
            {
                infoModal.Unsearched = _placeRepository.GetUnsearchedCount();
                infoModal.PlacesCount = _placeRepository.GetGeoCodeCacheSize();
            }, cancellationToken);

             
            return infoModal;
        }
    }
}
