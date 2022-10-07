using Splatrika.BronyMusicBrowser.Core.Projections.AlbumAggregate;

namespace Splatrika.BronyMusicBrowser.Core.Interfaces;

public interface IReadOnlyAlbumRepository : IReadOnlyRepository<AlbumInfo>
{
    Task<AlbumTitleInfo?> GetFirstForSong(int songId);

    Task<AlbumTitleInfo> GetTitle(int id);
}

