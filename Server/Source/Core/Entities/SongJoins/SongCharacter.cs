namespace Splatrika.BronyMusicBrowser.Core.Entities.SongJoins;

#nullable disable

public class SongCharacter
{
    public int SongId { get; private set; }
    public int CharacterId { get; private set; }
    public Character Character { get; private set; }


    public SongCharacter(int songId, int characterId)
    {
        SongId = songId;
        CharacterId = characterId;
    }


    private SongCharacter() { } //Required by EF Core
}

