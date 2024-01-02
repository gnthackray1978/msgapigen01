using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using System;

namespace ConfigHelper
{
    public class MSGConfigHelper : IMSGConfigHelper
    {
        #region props
        public string ClientURLs { get; set; }

        public string AuthServerUrl { get; set; }

        public string MSGApiGenUrl { get; set; }

        public string DNA_Match_File_FileName { get; set; }

        public string DNA_Match_File_Path { get; set; }

        public bool DNA_Match_File_IsEncrypted { get; set; }

        public string CacheData_FileName { get; set; }

        public string CacheData_Path { get; set; }

        public bool CacheData_IsEncrypted { get; set; }

        public string MSGGenDB01 { get; set; }

        public string FTMConString { get; set; }

        public string MSGGenDB01Local { get; set; }

        public string PlaceConString { get; set; }

        public string GedPath { get; set; }

        public string AzureDB { get; set; }

        public string SigRConnStr { get; set; }

        #endregion

        private bool _isDev;

        private readonly IConfiguration _configuration;

        public MSGConfigHelper(bool isDev = true)
        {
            _isDev = isDev;

            var config = new ConfigurationBuilder().AddJsonFile("config.json").Build();

            GetKeyVaultValues(config);

            FTMConString = config.GetSection("FTMConString").Value;
            
            DNA_Match_File_FileName = config.GetSection("DNA_Match_File_FileName").Value;

            DNA_Match_File_Path = config.GetSection("DNA_Match_File_Path").Value;

            var value = config.GetSection("DNA_Match_File_IsEncrypted").Value;
            
            if (value != null)
                DNA_Match_File_IsEncrypted = Boolean.Parse(value);

            CacheData_FileName = config.GetSection("CacheData_FileName").Value;

            CacheData_Path = config.GetSection("CacheData_Path").Value;
            
            var cacheData_IsEncrypted = config.GetSection("CacheData_IsEncrypted").Value;

            if(cacheData_IsEncrypted!=null)
                CacheData_IsEncrypted = Boolean.Parse(cacheData_IsEncrypted);

            PlaceConString = config.GetSection("PlaceConString").Value;

            MSGGenDB01Local = config.GetSection("MSGGenDB01Local").Value;

            AzureDB = config.GetSection("AzureDB").Value;

            SigRConnStr = config.GetSection("SigRConnStr").Value;

            GedPath = config.GetSection("GedPath").Value;
        }

        private void GetKeyVaultValues(IConfigurationRoot config)
        {
            //    var config = configBuilder.Build();
            //    var tokenProvider = new AzureServiceTokenProvider();
            //    var kvClient = new KeyVaultClient((authority, resource, scope) =>
            //        tokenProvider.KeyVaultTokenCallback(authority, resource, scope));

            //    configBuilder.AddAzureKeyVault(config["KeyVault:BaseUrl"], kvClient, new DefaultKeyVaultSecretManager());

            var keyVaultUrl = config.GetSection("KeyVaultUrl").Value;
            
            Serilog.Log.Information(keyVaultUrl);

            SecretClient client = null;

            if (_isDev)
            {
                var opts = new VisualStudioCredentialOptions
                {
                    TenantId = config.GetSection("TenantId").Value
                };

                var credential = new VisualStudioCredential(opts);

                client = new SecretClient(new Uri(keyVaultUrl), credential);
            }
            else
            {
                Serilog.Log.Information("Creating secret client");
                client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            }

           


            var TCUSecret = client.GetSecret("ClientURLs");
            ClientURLs = TCUSecret.Value.Value;

            Serilog.Log.Information("Client URLS: " + ClientURLs);

            var ASUSecret = client.GetSecret("AuthServerUrl");
            AuthServerUrl = ASUSecret.Value.Value;

            var MSGApiGenUrlSecret = client.GetSecret("MSGApiGenUrl");
            MSGApiGenUrl = MSGApiGenUrlSecret.Value.Value;

            var MSGGenDB01Secret = client.GetSecret("MSGGenDB01");
            MSGGenDB01 = MSGGenDB01Secret.Value.Value;
        }
    }
}
