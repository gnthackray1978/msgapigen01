using System.Threading;
using System.Threading.Tasks;
using Api.Hub;
using ConfigHelper;
using FTMContextNet.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Api.Controllers
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
            // add place cache entry for any locations in the persons
            // table that aren't already in the place cache.
            var r = await _mediator
                .Send(new CreatePersonLocationsCommand()
                    , new CancellationToken(false));

            return this.ConvertResult(r);
        }

        [HttpPut]
        [Route("/data/persons/locations")]
        public async Task<IActionResult> UpdatePersonLocations()
        {
            //update lat and long in persons table.

            var r = await _mediator
                .Send(new UpdatePersonLocationsCommand()
                    , new CancellationToken(false));

            return this.ConvertResult(r);
        }

        [HttpPost]
        [Route("/data/persons/add")]
        public async Task<IActionResult> AddPersons()
        {
            var r = await _mediator
                .Send(new CreatePersonAndRelationshipsCommand()
                    , new CancellationToken(false));

            return this.ConvertResult(r);
        }

        [HttpPost]
        [Route("/data/dupes")]
        public async Task<IActionResult> AddDupes()
        {
            var r = await _mediator
                .Send(new CreateDuplicateListCommand(), new CancellationToken(false));

            return this.ConvertResult(r);
        }




    }
}
