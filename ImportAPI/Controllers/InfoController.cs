﻿using System.Collections.Generic;
using System.Threading;
using ConfigHelper;
using FTMContextNet.Application.Models.Read;
using FTMContextNet.Application.UserServices.GetGedList;
using FTMContextNet.Application.UserServices.GetInfoList;
using ImportAPI.Hub;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PlaceLibNet.Application.Models.Read;
using PlaceLibNet.Application.Services.GetPlaceInfoService;

namespace ImportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly IHubContext<MsgNotificationHub> _hubContext;
        private readonly IMSGConfigHelper _iMSGConfigHelper;
        private readonly IMediator _mediator;

        public InfoController(IHubContext<MsgNotificationHub> hubContext, IMSGConfigHelper iMSGConfigHelper, IMediator mediator)
        {
            _hubContext = hubContext;
            _iMSGConfigHelper = iMSGConfigHelper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/info/people")]
        public InfoModel GetPeopleInfo()
        {
            return _mediator
                .Send(new GetInfoServiceQuery(), new CancellationToken(false)).Result;
        }

        [HttpGet]
        [Route("/info/places")]
        public PlaceInfoModel GetPlaceInfo()
        {
            return _mediator
                .Send(new GetPlaceInfoQuery(), new CancellationToken(false)).Result;
        }

        [HttpGet]
        [Route("/info/gedfiles")]
        public IEnumerable<ImportModel> GetGedFileInfo()
        {
            return _mediator
                .Send(new GetGedFilesQuery(false), new CancellationToken(false)).Result;
        }
    }
}
