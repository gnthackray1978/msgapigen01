using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using System;

namespace ConfigHelper
{

    public class MSGConfigHelper : IMSGConfigHelper
    {
        public string ClientURLs { get; set; }

        public string AuthServerUrl { get; set; }

        public string MSGApiGenUrl { get; set; }

        public string MSGGenDB01 { get; set; }

        private readonly IConfiguration _configuration;

        public MSGConfigHelper()  {

            var keyVaultUrl = @"https://msgvault01.vault.azure.net/";


            var opts = new VisualStudioCredentialOptions();

            opts.TenantId = "86373050-6f1c-4736-8823-7a15f7517604";


           // var credential = new VisualStudioCredential(opts);


            var credential = new DefaultAzureCredential();


            var client = new SecretClient(new Uri(keyVaultUrl), credential);


            var TCUSecret = client.GetSecret("ClientURLs");
            ClientURLs = TCUSecret.Value.Value;

            var ASUSecret = client.GetSecret("AuthServerUrl");
            AuthServerUrl = ASUSecret.Value.Value;

            var MSGApiGenUrlSecret = client.GetSecret("MSGApiGenUrl");
            MSGApiGenUrl = MSGApiGenUrlSecret.Value.Value; 

            var MSGGenDB01Secret = client.GetSecret("MSGGenDB01");
            MSGGenDB01 = MSGGenDB01Secret.Value.Value;
        }

    }


}
