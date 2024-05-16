using MediatR;
using MSG.CommonTypes;

namespace FTMContextNet.Domain.Commands;

public class UpdateImportStatusCommand : IRequest<CommandResult>
{
    public UpdateImportStatusCommand(int importId, bool geoCodeComplete)
    {
        ImportId = importId;
        GeoCodeComplete = geoCodeComplete;
    }

    public int ImportId { get; private set; }

    public bool GeoCodeComplete { get; private set; }
}