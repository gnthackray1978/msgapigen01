using Api.Types.Diagrams;
using Api.Models;
using System.Threading.Tasks;
using Api.Types.RequestQueries;

namespace Api.Services.interfaces.services
{
    public interface IDiagramService
    {
        Task<DiagramResults<AncestorNode>> GetAncestors(DiagramParamObj searchParams);

        Task<DiagramResults<DescendantNode>> GetDescendants(DiagramParamObj searchParams);

    }
}
