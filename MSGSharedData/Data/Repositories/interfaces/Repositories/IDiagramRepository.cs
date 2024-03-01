using MSGSharedData.Domain.Entities.NonPersistent.Diagrams;
using MSGSharedData.Domain.Entities.NonPersistent.RequestQueries;

namespace MSGSharedData.Data.Services.interfaces.services
{
    public interface IDiagramRepository
    {
        Task<DiagramResults<AncestorNode>> GetAncestors(DiagramParamObj searchParams);

        Task<DiagramResults<DescendantNode>> GetDescendants(DiagramParamObj searchParams);

    }
}
