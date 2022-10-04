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
}

