using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using ConfigHelper;
using Api.Schema;

namespace Api.Controllers
{
    //Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class GraphQLController : ControllerBase
    {
        private MainSchema _schema;
       

        private readonly IMSGConfigHelper _iMSGConfigHelper;

        public GraphQLController( IMSGConfigHelper iMSGConfigHelper)
        {
            _iMSGConfigHelper = iMSGConfigHelper;
        }

        //[HttpPost]
        //public async Task<IActionResult> PostAsync([FromBody] GraphQLQuery query)
        //{
          
            
        //    var dictionary = new Dictionary<string, object>();

        //    try
        //    {
        //        ClaimsPrincipal currentUser = User;
        //        dictionary.Add("claimsprincipal", currentUser);
        //    }
        //    catch (Exception e)
        //    {

        //    }

        //    Inputs? inputs = Inputs.Empty;


        //    var result = await _documentExecuter.ExecuteAsync(new()
        //    {
        //        Query = query.Query,
        //        RequestServices = HttpContext.RequestServices,
        //        CancellationToken = HttpContext.RequestAborted,
        //    });

        //    return new ExecutionResultActionResult(result);


        //    //try
        //    //{
        //    //    inputs = writer.ReadNode<Inputs>(query.Variables);
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    Debug.WriteLine(e);
        //    //}


        //    //var json = await _schema.ExecuteAsync(writer, _ =>
        //    // {
        //    //     _.Query = query.Query;
        //    //     _.Variables = inputs;
        //    //     _.UserContext = dictionary;
        //    // });

        //    //return new JsonResult(JsonConvert.DeserializeObject(json));
        //}
    }
}