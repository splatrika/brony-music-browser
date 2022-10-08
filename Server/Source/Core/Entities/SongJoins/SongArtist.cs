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


    public override bool Equals(object obj)
    {
        if (obj is SongArtist artist)
        {
            return artist.SongId == SongId &&
                artist.ArtistId == ArtistId;
        }
        return base.Equals(obj);
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(SongId.GetHashCode(), ArtistId.GetHashCode());
    }
}

