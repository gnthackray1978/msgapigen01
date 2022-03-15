using Api.Types;
using Api.Types.Diagrams;
using Api.Models;
using System.Threading.Tasks;

namespace Api.Services.interfaces
{
    public interface IDiagramService
    {      
        Task<DiagramResults<AncestorNode>> GetAncestors(DiagramParamObj searchParams);

        Task<DiagramResults<DescendantNode>> GetDescendants(DiagramParamObj searchParams);

    }
}
