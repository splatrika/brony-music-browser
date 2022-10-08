using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Core.Projections;

namespace Splatrika.BronyMusicBrowser.WebApi.Controllers;

public class ArtistsController : SimpleResourceControllerBase<ArtistInfo>
{
    public ArtistsController(IReadOnlyRepository<ArtistInfo> repository)
        : base(repository)
    {
    }
}

