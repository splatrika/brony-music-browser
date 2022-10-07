using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Projections;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories.ReadOnly;

public class ReadOnlyGenreRepository
    : EfReadOnlyRepositoryBase<GenreInfo, Genre, BrowserContext>
{
    public ReadOnlyGenreRepository(BrowserContext context) : base(context)
    {
    }
}

