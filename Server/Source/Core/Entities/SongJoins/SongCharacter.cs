namespace Splatrika.BronyMusicBrowser.Core.Entities.SongJoins;

#nullable disable

public class SongCharacter
{
    public int SongId { get; private set; }
    public int CharacterId { get; private set; }


    public SongCharacter(int songId, int characterId)
    {
        SongId = songId;
        CharacterId = characterId;
    }


    public override bool Equals(object obj)
    {
        if (obj is SongCharacter character)
        {
            return character.SongId == SongId &&
                character.CharacterId == CharacterId;
        }
        return base.Equals(obj);
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(SongId.GetHashCode(),
            CharacterId.GetHashCode());
    }
}

