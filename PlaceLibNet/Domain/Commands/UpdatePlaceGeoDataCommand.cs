using MediatR;
using MSG.CommonTypes;
using PlaceLibNet.Domain.Caching;

namespace PlaceLibNet.Domain.Commands;

public class UpdatePlaceGeoDataCommand : IRequest<CommandResult>
{
    public UpdatePlaceGeoDataCommand(int amount, int delay)
    {
        Amount = amount;
        Delay = delay;
    }

    public int Amount { get; private set; }

    public int Delay { get; private set; }
}