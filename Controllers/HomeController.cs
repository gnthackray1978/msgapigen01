using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        IMSGConfigHelper _MSGConfigHelper;
        public HomeController(IMSGConfigHelper mSGConfigHelper) {
            _MSGConfigHelper = mSGConfigHelper;

        }
        public IActionResult Get()
        {
            string payload = "API running - "
                + Environment.NewLine + _MSGConfigHelper.AuthServerUrl
                + Environment.NewLine + _MSGConfigHelper.MSGGenDB01;

            return new JsonResult(new { payload = payload});


        }
    }
}