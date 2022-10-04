namespace Splatrika.BronyMusicBrowser.Core.Entities.ReadOnly;

public class ArtistInfo : EntityBase
{
    public string Name { get; private set; }

    public ArtistInfo(Artist original) : base(original.Id)
    {
        Name = original.Name;
    }
}

