namespace Splatrika.BronyMusicBrowser.Core.CreateArgs;

public class GenreCreateArgs
{
    public string Caption { get; set; }
    public int Order { get; set; }


    public GenreCreateArgs(string caption, int order = 0)
    {
        Caption = caption;
        Order = order;
    }
}

