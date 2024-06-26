﻿using System;
using AutoMapper;
using FTMContextNet.Application.Models.Read;
using FTMContextNet.Domain.Entities.NonPersistent;
using System.Collections.Generic;
using System.Linq;
using FTMContextNet.Domain.Entities.Persistent.Cache;
using PlaceLibNet.Application.Models.Read;
using PlaceLibNet.Domain.Entities;

namespace FTMContextNet.Application.Mapping
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            this.CreateMap<Info, InfoModel>();
            this.CreateMap<IEnumerable<PlaceLookup>, IEnumerable<PlaceModel>>().ConvertUsing(new PlaceConverter());
            this.CreateMap<IEnumerable<TreeImport>, IEnumerable<ImportModel>>().ConvertUsing(new GedFileInfoConverter());
        }
    }

    class PlaceConverter: ITypeConverter<IEnumerable<PlaceLookup>, IEnumerable<PlaceModel>>
    {
        public IEnumerable<PlaceModel> Convert(IEnumerable<PlaceLookup> source, IEnumerable<PlaceModel> destination, ResolutionContext context)
        {
            return source
                .Select(item => 
                    new PlaceModel()
                    {
                        place = item.Place, 
                        placeformatted = item.PlaceFormatted, 
                        placeid = item.PlaceId, 
                        results = item.Results
                    }).ToList();
        }
    }

    class GedFileInfoConverter : ITypeConverter<IEnumerable<TreeImport>, IEnumerable<ImportModel>>
    {
        public IEnumerable<ImportModel> Convert(IEnumerable<TreeImport> source, IEnumerable<ImportModel> destination, ResolutionContext context)
        {
            return source
                .Select(item =>
                {
                    DateTime.TryParse(item.DateImported, out DateTime dt);
             


                    return new ImportModel
                    {
                        Id = item.Id,
                        FileName = item.FileName,
                        FileSize = item.FileSize,
                        DateImported = dt,
                        Selected = item.Selected,
                        UserId = item.UserId,
                        DupesProcessed = item.DupesProcessed,
                        MissingLocationsProcessed = item.MissingLocationsProcessed,
                        PersonsProcessed = item.PersonsProcessed,
                        CCProcessed = item.CCProcessed,
                        GeocodingProcessed = item.GeocodingProcessed
                    };
                }).ToList();
        }
    }
}
