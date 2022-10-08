namespace Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;

public class AlbumSong
{
    public int AlbumId { get; private set; }
    public int SongId { get; private set; }


    public AlbumSong(int albumId, int songId)
    {
        AlbumId = albumId;
        SongId = songId;
    }


    public override bool Equals(object? obj)
    {
        if (obj is AlbumSong song)
        {
            return song.AlbumId == AlbumId &&
                song.SongId == SongId;
        }
        return base.Equals(obj);
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(AlbumId.GetHashCode(), SongId.GetHashCode());
    }
}

