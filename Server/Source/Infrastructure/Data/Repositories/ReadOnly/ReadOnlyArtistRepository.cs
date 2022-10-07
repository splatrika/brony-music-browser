using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Projections;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories.ReadOnly;

public class ReadOnlyArtistRepository
    : EfReadOnlyRepositoryBase<ArtistInfo, Artist, BrowserContext>
{
    public ReadOnlyArtistRepository(BrowserContext context) : base(context)
    {
    }
}

