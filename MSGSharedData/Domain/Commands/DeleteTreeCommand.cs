using MediatR;
using MSG.CommonTypes;

namespace FTMContextNet.Domain.Commands;

public class DeleteTreeCommand : IRequest<CommandResult>
{
    public DeleteTreeCommand(int importId)
    {
        ImportId = importId;
    }

    public int ImportId { get; private set; }
}