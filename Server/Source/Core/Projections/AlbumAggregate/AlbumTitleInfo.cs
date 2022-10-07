using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Core.Projections.AlbumAggregate;

public class AlbumTitleInfo : EntityBase
{
    public string Title { get; set; }


    public AlbumTitleInfo(int id, string title) : base(id)
    {
        Title = title;
    }
}

