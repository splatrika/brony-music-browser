namespace Splatrika.BronyMusicBrowser.Core.Entities.SongJoins;

#nullable disable

public class SongArtist
{
    public int SongId { get; private set; }
    public int ArtistId { get; private set; }


    public SongArtist(int songId, int artistId)
    {
        SongId = songId;
        ArtistId = artistId;
    }
}

