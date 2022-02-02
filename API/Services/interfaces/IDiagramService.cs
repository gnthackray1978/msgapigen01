using Api.Types;
using Api.Types.Diagrams;
using Api.Models;
using System.Threading.Tasks;

namespace Api.Services.interfaces
{
    public interface IDiagramService
    {      
        Task<Results<AncestorNode>> GetAncestors(DiagramParamObj searchParams);

        Task<Results<DescendantNode>> GetDescendants(DiagramParamObj searchParams);

    }
}
