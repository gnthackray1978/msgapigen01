using Api.Models;
using Api.Types.Diagrams;
using ConfigHelper;
using Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Api.DB;
using Api.Types.RequestQueries;
using Api.Services.interfaces.services;

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


        public async Task<DiagramResults<AncestorNode>> GetAncestors(DiagramParamObj searchParams)
        {
            var _wills = new List<AncestorNode>();

            var results = new DiagramResults<AncestorNode>();

          

            results.Error = "";


            results.LoginInfo = searchParams.PersonId.ToString();

            List<AncestorNode> gag = new List<AncestorNode>();
            try
            {
                var c = new DNAContext(_imsConfigHelper.MSGGenDB01);

                var a = new AncestorGraphBuilder(c);

                gag = a.GenerateAncestorGraph(searchParams.Origin, searchParams.PersonId);                
            }
            catch (Exception e)
            {
                results.Error = e.Message;
            }

            results.results = gag;

            if (gag.Count > 0)
            {
                results.TotalResults = gag.Count;
                int genNumber = 0;
                int genNodeNumber = 0;
                foreach(var n in gag)
                {
                    if (n.GenerationIdx > genNumber)
                        genNumber = n.GenerationIdx;

                    if (n.Index > genNodeNumber)
                        genNodeNumber = n.Index;
                }

                results.GenerationsCount = genNumber+1;
                results.MaxGenerationLength = genNodeNumber+1;
            }

            return results;
        }

        public async Task<DiagramResults<DescendantNode>> GetDescendants(DiagramParamObj searchParams)
        {
            var _wills = new List<DescendantNode>();

            var results = new DiagramResults<DescendantNode>();

            results.Error ="none";

            results.LoginInfo = searchParams.PersonId.ToString();

            List<DescendantNode> gag = new List<DescendantNode>();

            try
            {

                var a = new DNAContext(_imsConfigHelper.MSGGenDB01);

                var d = new DescendantGraphBuilder(a);


                gag= d.GenerateDescendantGraph(searchParams.PersonId, searchParams.Origin);
                 
            }
            catch(Exception e)
            {
                results.Error = e.Message;
            }

            results.results = gag;

            if (gag.Count > 0)
            {
                results.TotalResults = gag.Count;
                int genNumber = 0;
                int genNodeNumber = 0;
                foreach (var n in gag)
                {
                    if (n.GenerationIdx > genNumber)
                        genNumber = n.GenerationIdx;

                    if (n.Index > genNodeNumber)
                        genNodeNumber = n.Index;
                }

                results.GenerationsCount = genNumber+1;
                results.MaxGenerationLength = genNodeNumber+1;
            }

            return results;
        }

 
    }
}
