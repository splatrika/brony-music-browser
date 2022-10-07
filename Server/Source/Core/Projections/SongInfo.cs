using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.Core.Projections;

public class SongInfo : EntityBase, IReadOnlyProjection
{
    public string Title { get; private set; }
    public string Cover { get; private set; }
    public int Year { get; private set; }
    public string YouTubeId { get; private set; }
    public IReadOnlyCollection<int> Artists { get; private set; }
    public IReadOnlyCollection<int> Genres { get; private set; }
    public IReadOnlyCollection<int> Characters { get; private set; }


    public SongInfo(Song original) : base(original.Id)
    {
        Title = original.Title;
        Cover = original.Cover;
        Year = original.Year;
        YouTubeId = original.YouTubeId;

        Artists = original.Artists
            .Select(x => x.ArtistId)
            .ToList()
            .AsReadOnly();

        Genres = original.Genres
            .Select(x => x.GenreId)
            .ToList()
            .AsReadOnly();

        Characters = original.Characters
            .Select(x => x.CharacterId)
            .ToList()
            .AsReadOnly();
    }
}

