using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Projections;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories.ReadOnly;

public class ReadOnlyArtistReposiotory
    : EfReadOnlyRepositoryBase<ArtistInfo, Artist, BrowserContext>
{
    public ReadOnlyArtistReposiotory(BrowserContext context) : base(context)
    {
    }
}

