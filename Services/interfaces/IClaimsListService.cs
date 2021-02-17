using GqlMovies.Api.Models;

namespace GqlMovies.Api.Services
{
    // a hack to make di work properly - it doesn't seem to like generics very well.
    public interface IClaimsListService : IListService<MSGClaim> 
    { }


}