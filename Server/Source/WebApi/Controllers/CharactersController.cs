using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Core.Projections;

namespace Splatrika.BronyMusicBrowser.WebApi.Controllers;

public class CharactersController : SimpleResourceControllerBase<CharacterInfo>
{
    public CharactersController(IReadOnlyRepository<CharacterInfo> repository)
        : base(repository)
    {
    }
}

