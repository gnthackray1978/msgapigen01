
using System.Security;
using System.Security.Claims;
using Api.Services;
using System.Threading.Tasks;
using Api.Types.Diagrams;
using Api.Services.interfaces.services;
using Api.Types.RequestQueries;
using HotChocolate;
using HotChocolate.Types;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class DiagramQuery 
    {
        public Task<DiagramResults<AncestorNode>> ancestorsearch(DiagramParamObj pobj,
            [Service] IDiagramService repository,
            [Service] IClaimService claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.Wills))
            {
            //    return ErrorHandler.Error<AncestorNode>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.GetAncestors(pobj);
        }

        public Task<DiagramResults<DescendantNode>> descendantsearch(DiagramParamObj pobj,
            [Service] IDiagramService repository,
            [Service] IClaimService claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.Wills))
            {
                //    return ErrorHandler.Error<AncestorNode>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.GetDescendants(pobj);
        }
 
    }
}
