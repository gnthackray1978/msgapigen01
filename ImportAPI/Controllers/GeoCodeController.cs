using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ConfigHelper;
using FTMContextNet;
using FTMContextNet.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PlaceLibNet.Application.Models.Read;
using PlaceLibNet.Application.Models.Write;
using PlaceLibNet.Application.Services.GetPlacesNotGeoCodedService;
using PlaceLibNet.Domain.Commands;
using MSG.CommonTypes;
using ImportAPI.Hub;

namespace ImportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeoCodeController : ControllerBase
    {
        private readonly IMSGConfigHelper _iMSGConfigHelper;
        private readonly IHubContext<MsgNotificationHub> _hubContext;
        private readonly FTMFacade _facade;
        private readonly IMediator _mediator;

        public GeoCodeController(IHubContext<MsgNotificationHub> hubContext,
            IMSGConfigHelper iMSGConfigHelper, IMediator mediator)
        {
            _hubContext = hubContext;
            _iMSGConfigHelper = iMSGConfigHelper;
            _mediator = mediator;
            _facade = new FTMFacade(_iMSGConfigHelper, new OutputHandler(_hubContext));
        }

        [HttpGet]
        public ResultModel Get(string infoType)
        {         
            var result = new ResultModel();
            
            result.Results = _mediator.Send(new GetPlacesNotGeoCodedQuery(300), new CancellationToken(false)).Result;

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post(GeoCodeResultModel value)
        {
            //      _facade.WriteGeoCodedData(value);
            //Update Geocoded data to the place cache table.
            Serilog.Log.Information("GeoCodeController Post");

            return Ok(1);

            var r = await _mediator.Send(new UpdatePlaceGeoDataCommand(value.Amount, value.Delay),
              new CancellationToken(false));

            return this.ConvertResult(r);
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            // Update place cache lat long
            // Update place cache county
            // Update place cache bad data where appropriate
            Serilog.Log.Information("GeoCodeController Put");

            return Ok(1);


            var r = await _mediator.Send(new UpdatePlaceMetaDataCommand(),
                new CancellationToken(false));

            return this.ConvertResult(r);
        }
        
    }
}
