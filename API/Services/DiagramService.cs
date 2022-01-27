using Api.Services.interfaces;
using Api.Types;
using Api.Types.Diagrams;
using GqlMovies.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class DiagramService : IDiagramService
    {
        public async Task<Results<AncestorNode>> GetAncestors(DiagramParamObj searchParams)
        {
            var _wills = new List<AncestorNode>();

            var results = new Results<AncestorNode>();

            int totalRecs = 0;

            results.Error = "";

            return results;
        }

        public async Task<Results<DescendantNode>> GetDescendants(DiagramParamObj searchParams)
        {
            var _wills = new List<DescendantNode>();

            var results = new Results<DescendantNode>();

            int totalRecs = 0;

            results.Error = "";

            return results;
        }
    }
}
