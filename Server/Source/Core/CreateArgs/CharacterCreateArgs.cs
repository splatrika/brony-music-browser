namespace Splatrika.BronyMusicBrowser.Core.CreateArgs;

public class CharacterCreateArgs
{
    public string Name { get; set; }
    public string? Icon { get; set; }
    public int Order { get; set; }


    public CharacterCreateArgs(string name, string? icon, int order = 0)
    {
        Name = name;
        Icon = icon;
        Order = order;
    }
}

