using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public interface IMSGConfigHelper
    {
        string TestClientUrl { get; set; }
        string AuthServerUrl { get; set; }

        string MSGApiGenUrl { get; set; }
    }

    public class MSGConfigHelper : IMSGConfigHelper
    {
        public string TestClientUrl { get; set; }

        public string AuthServerUrl { get; set; }

        public string MSGApiGenUrl { get; set; }
         

        private readonly IConfiguration _configuration;

        public MSGConfigHelper(IConfiguration configuration)
        {
            _configuration = configuration;

            TestClientUrl = configuration["TestClientUrl"];

            AuthServerUrl = configuration["AuthServerUrl"];

            MSGApiGenUrl = configuration["MSGApiGenUrl"];
        }

        
    }

     
}
