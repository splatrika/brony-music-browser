using System;
namespace Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;

public class AlbumArtist
{
    public int AlbumId { get; private set; }
    public int ArtistId { get; private set; }

    public AlbumArtist(int albumId, int artistId)
    {
        AlbumId = albumId;
        ArtistId = artistId;
    }
}

