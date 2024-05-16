using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Hub;
using ConfigHelper;
using FTMContextNet.Application.Models.Read;
using FTMContextNet.Application.UserServices.GetGedList;
using FTMContextNet.Application.UserServices.GetTreeImportStatus;
using FTMContextNet.Domain.Commands;
using HotChocolate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public partial class GedController : ControllerBase
{

    private readonly IMSGConfigHelper _iMSGConfigHelper;
    private readonly OutputHandler _outputHandler; 
    private readonly IMediator _mediator;


    public GedController(IHubContext<MsgNotificationHub> hubContext, 
        IMSGConfigHelper iMSGConfigHelper, IMediator mediator)
    {
        _iMSGConfigHelper = iMSGConfigHelper;
        _outputHandler = new OutputHandler(hubContext); 
        _mediator = mediator;
    }

    [HttpPost]
    [Route("/ged/add")]
    public async Task<IActionResult> UploadFiles([FromForm] FilePayload filePayload)
    {
        string size = "0";
        string fileName = "";
        
        try
        {
            size = FilePayload.ExtractFile(filePayload, _iMSGConfigHelper.GedPath, out fileName);

            Serilog.Log.Information(fileName);

            var fullName = System.IO.Path.Combine(_iMSGConfigHelper.GedPath, fileName);

            var first100Lines = System.IO.File.ReadLines(fullName).Take(100).ToList();
            //check we have a valid GED by looking at extension and the first 100 lines
            //and seeing if they contain a ged tag (the NAME tag)
            if (!first100Lines.Any(l => l.Contains("NAME"))||!fileName.ToLower().Contains("ged"))
            {
                return StatusCode(415, "Invalid GED File");
            }
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
        
        if (size == "0")
        {
            return NoContent();
        }

        var r = await _mediator
            .Send(new CreateImportCommand(fileName, size, false),
                new CancellationToken(false));

        return this.ConvertResult(r);
         
    }

    [HttpPut]
    [Route("/ged/select")]
    public async Task<IActionResult> SelectGed([FromBody] int importId)
    {
        Serilog.Log.Information("select ged");

        var r = await  _mediator
            .Send(new UpdateImportStatusCommand(importId, false), new CancellationToken(false));
        
        return  this.ConvertResult(r);
    }

    [HttpDelete]
    [Route("/ged/delete/{importId}")]
    public async Task<IActionResult> DeleteGed([FromRoute] int importId)
    {
        Serilog.Log.Information("DeleteGed " + importId);
        //   if (importId == 42) return Ok();

        var r = await _mediator
            .Send(new DeleteTreeCommand(importId), new CancellationToken(false));

        return this.ConvertResult(r);
    }

    [HttpGet]
    [Route("/ged/selection")]
    public ImportModel Selection()
    {
        return  _mediator
            .Send(new GetGedFilesQuery(true), new CancellationToken(false)).Result.FirstOrDefault();
    }
    
}