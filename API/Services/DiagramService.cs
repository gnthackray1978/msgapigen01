using Api.Models;
using Api.Services.interfaces;
using Api.Types;
using Api.Types.Diagrams;
using ConfigHelper;
using GqlMovies.Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Services
{
    public partial class DiagramService : IDiagramService
    {


        private readonly IMSGConfigHelper _imsConfigHelper;
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public DiagramService(HttpClient client, IConfiguration config, 
                                            IMSGConfigHelper imsConfigHelper)
        {
            _client = client;
            _imsConfigHelper = imsConfigHelper;
        }


        public async Task<Results<AncestorNode>> GetAncestors(DiagramParamObj searchParams)
        {
            var _wills = new List<AncestorNode>();

            var results = new Results<AncestorNode>();

            int totalRecs = 0;

            results.Error = "";


            results.LoginInfo = searchParams.PersonId.ToString();
            results.Page = 1;

            try
            {

                var c = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var a = new AncestorGraphBuilder(c);

                results.results = a.GenerateAncestorGraph(searchParams.Origin, searchParams.PersonId);
            }
            catch (Exception e)
            {
                results.Error = e.Message;
            }


            return results;
        }

        public async Task<Results<DescendantNode>> GetDescendants(DiagramParamObj searchParams)
        {
            var _wills = new List<DescendantNode>();

            var results = new Results<DescendantNode>();

            results.Error ="none";

            results.LoginInfo = searchParams.PersonId.ToString();
            results.Page = 1;

            try
            {

                var a = new AzureDBContext(_imsConfigHelper.MSGGenDB01);

                var d = new DescendantGraphBuilder(a);

                results.results = d.GenerateDescendantGraph(searchParams.PersonId, searchParams.Origin);
            }
            catch(Exception e)
            {
                results.Error = e.Message;
            }



            return results;
        }

 
    }
}
