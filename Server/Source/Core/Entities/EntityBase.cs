namespace Splatrika.BronyMusicBrowser.Core.Entities;

public class EntityBase
{
    public int Id { get; private set; }

    public EntityBase(int id)
    {
        Id = id;
    }
}

