using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Core.Projections;

namespace Splatrika.BronyMusicBrowser.WebApi.Controllers;

public class GenresController : SimpleResourceControllerBase<GenreInfo>
{
    public GenresController(IReadOnlyRepository<GenreInfo> repository)
        : base(repository)
    {
    }
}

