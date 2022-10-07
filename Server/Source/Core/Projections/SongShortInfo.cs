using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Core.Projections;

public class SongShortInfo : EntityBase
{
    public string Title { get; private set; }
    public List<int> Artists { get; private set; }


    public SongShortInfo(int id, string title, List<int> artists)
        : base(id)
    {
        Title = title;
        Artists = artists;
    }
}

