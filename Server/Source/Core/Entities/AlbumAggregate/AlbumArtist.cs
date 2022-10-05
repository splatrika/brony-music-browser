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


    public override bool Equals(object? obj)
    {
        if (obj is AlbumArtist artist)
        {
            return artist.AlbumId == AlbumId &&
                artist.ArtistId == ArtistId;
        }
        return base.Equals(obj);
    }
}

