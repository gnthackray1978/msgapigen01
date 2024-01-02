using Microsoft.AspNetCore.Mvc;
using GraphQL;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using ConfigHelper;
using Api.Schema;

namespace Api.Controllers
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }

    //Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class GraphQLController : ControllerBase
    {
        private MainSchema _schema;

        private readonly IMSGConfigHelper _iMSGConfigHelper;

        public GraphQLController(MainSchema schema, IMSGConfigHelper iMSGConfigHelper)
        {
            _schema = schema;
            _iMSGConfigHelper = iMSGConfigHelper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GraphQLQuery query)
        {
            var writer = new GraphQL.SystemTextJson.GraphQLSerializer();

            JObject variables = query.Variables;

            var dictionary = new Dictionary<string, object>();

            try
            {
                ClaimsPrincipal currentUser = User;
                dictionary.Add("claimsprincipal", currentUser);
            }
            catch (Exception e)
            {

            }

            var json = await _schema.ExecuteAsync(writer, _ =>
             {
                 _.Query = query.Query;
                 _.Variables = writer.ReadNode<Inputs>(query.Variables) ?? Inputs.Empty;
                 _.UserContext = dictionary;
             });
            
            return new JsonResult(JsonConvert.DeserializeObject(json));
        }
    }
}