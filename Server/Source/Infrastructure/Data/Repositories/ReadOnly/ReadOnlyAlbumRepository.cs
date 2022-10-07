using Microsoft.EntityFrameworkCore;
using Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Core.Projections.AlbumAggregate;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories.ReadOnly;

public class ReadOnlyAlbumRepository
    : EfReadOnlyRepositoryBase<AlbumInfo, Album, BrowserContext>,
    IReadOnlyAlbumRepository
{
    public ReadOnlyAlbumRepository(BrowserContext context) : base(context)
    {
    }


    public async Task<AlbumTitleInfo?> GetFirstForSong(int songId)
    {
        var album = await _context.Albums
            .Include(e => e.Songs)
            .FirstOrDefaultAsync(e =>
                e.Songs.Any(x => x.SongId == songId));

        if (album == null)
        {
            return null;
        }

        return new(album.Id, album.Title);
    }


    public async Task<AlbumTitleInfo> GetTitle(int id)
    {
        await CheckContains(id);

        var album = await _context.Albums
            .SingleAsync(e => e.Id == id);

        return new(album.Id, album.Title);
    }
}

