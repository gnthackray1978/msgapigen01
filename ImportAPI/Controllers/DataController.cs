using System.Threading;
using System.Threading.Tasks;
using ConfigHelper;
using FTMContextNet.Domain.Commands;
using ImportAPI.Hub;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;

namespace ImportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        
        private readonly IMSGConfigHelper _iMSGConfigHelper;
        private readonly OutputHandler _outputHandler;
        private readonly IMediator _mediator;

        public DataController(IHubContext<MsgNotificationHub> hubContext, IMSGConfigHelper iMSGConfigHelper, IMediator mediator)
        {
            _iMSGConfigHelper = iMSGConfigHelper;
            _outputHandler = new OutputHandler(hubContext);
            _mediator = mediator;
        }
        
        [HttpPost]
        [Route("/data/persons/locations")]
        public async Task<IActionResult> AddPersonLocations()
        {
            Serilog.Log.Information("AddPersonLocations");

            return Ok(1);

            var r = await _mediator
                .Send(new CreatePersonLocationsCommand()
                    , new CancellationToken(false));

            return this.ConvertResult(r);
        }

        [HttpPut]
        [Route("/data/persons/locations")]
        public async Task<IActionResult> UpdatePersonLocations()
        {
            Serilog.Log.Information("UpdatePersonLocations");

            return Ok(1);

            var r = await _mediator
                .Send(new UpdatePersonLocationsCommand()
                    , new CancellationToken(false));
            
            return this.ConvertResult(r);
        }

        [HttpPost]
        [Route("/data/persons/add")]
        public async Task<IActionResult> AddPersons()
        {
            Serilog.Log.Information("AddPersons");

            return Ok(1);

            var r = await _mediator
                .Send(new CreatePersonAndRelationshipsCommand()
                    , new CancellationToken(false));

            return this.ConvertResult(r);
        }
        
        [HttpPost]
        [Route("/data/dupes")]
        public async Task<IActionResult> AddDupes()
        {
            Serilog.Log.Information("AddDupes");

            return Ok(1);

            var r = await _mediator
                .Send(new CreateDuplicateListCommand(), new CancellationToken(false));

            return this.ConvertResult(r);
        }
        
      
         
         
    }
}
