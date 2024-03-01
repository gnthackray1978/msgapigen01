
using System.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using MSGSharedData.Data.Services.interfaces.services;
using MSGSharedData.Domain.Entities.NonPersistent.Diagrams;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;
using MSGSharedData.Domain.Enumerations;

namespace Api.Schema.SubQueries
{
    [ExtendObjectType("Query")]
    public class DiagramQuery 
    {
        public Task<DiagramResults<AncestorNode>> ancestorsearch(DiagramParamObj pobj,
            [Service] IDiagramRepository repository,
            [Service] IClaimRepository claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.Diagrams))
            {
            //    return ErrorHandler.Error<AncestorNode>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.GetAncestors(pobj);
        }

        public Task<DiagramResults<DescendantNode>> descendantsearch(DiagramParamObj pobj,
            [Service] IDiagramRepository repository,
            [Service] IClaimRepository claimService, ClaimsPrincipal currentUser)
        {
            if (!claimService.UserValid(currentUser, MSGApplications.Diagrams))
            {
                //    return ErrorHandler.Error<AncestorNode>(new SecurityException(), claimService.GetClaimDebugString(currentUser));
            }

            return repository.GetDescendants(pobj);
        }
 
    }
}
