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


    public override bool Equals(object obj)
    {
        if (obj is SongGenre genre)
        {
            return genre.SongId == SongId &&
                genre.GenreId == GenreId;
        }
        return base.Equals(obj);
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(SongId.GetHashCode(), GenreId.GetHashCode());
    }
}

