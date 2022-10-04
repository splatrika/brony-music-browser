namespace Splatrika.BronyMusicBrowser.Core.Entities.ReadOnly;

public class GenreInfo : EntityBase
{
    public string Caption { get; set; }

    public GenreInfo(Genre original) : base(original.Id)
    {
        Caption = original.Caption;
    }
}

