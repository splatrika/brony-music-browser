using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories;

public class AlbumCrudRepository
    : EfCrudRepositoryBase<Album, AlbumCreateArgs, BrowserContext>
{
    public AlbumCrudRepository(BrowserContext context) : base(context)
    {
    }

    protected override Album Construct(AlbumCreateArgs args)
    {
        return new(0, args.FirstSongId, args.Title, args.Cover);
    }
}

