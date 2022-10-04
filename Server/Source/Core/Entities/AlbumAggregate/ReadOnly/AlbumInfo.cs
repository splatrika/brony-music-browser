using System;
namespace Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate.ReadOnly;

public class AlbumInfo : EntityBase
{
    public string Title { get; private set; }
    public IReadOnlyCollection<AlbumSong> Songs { get; private set; }
    public IReadOnlyCollection<AlbumArtist> Artists { get; private set; }

    public AlbumInfo(Album original) : base(original.Id)
    {
        Title = original.Title;
        Songs = original.Songs.ToList().AsReadOnly();
        Artists = original.Artists.ToList().AsReadOnly();
    }
}
