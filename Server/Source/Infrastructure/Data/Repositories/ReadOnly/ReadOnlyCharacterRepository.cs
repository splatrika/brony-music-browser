using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Projections;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories.ReadOnly;

public class ReadOnlyCharacterRepository
    : EfReadOnlyRepositoryBase<CharacterInfo, Character, BrowserContext>
{
    public ReadOnlyCharacterRepository(BrowserContext context) : base(context)
    {
    }
}

