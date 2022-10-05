namespace Splatrika.BronyMusicBrowser.Core.Entities.SongJoins;

#nullable disable

public class SongGenre
{
    public int SongId { get; private set; }
    public int GenreId { get; private set; }


    public SongGenre(int songId, int genreId)
    {
        SongId = songId;
        GenreId = genreId;
    }
}

