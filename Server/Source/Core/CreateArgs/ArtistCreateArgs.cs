namespace Splatrika.BronyMusicBrowser.Core.CreateArgs;

public class ArtistCreateArgs
{
    public string Name { get; set; }


    public ArtistCreateArgs(string name)
    {
        Name = name;
    }
}

