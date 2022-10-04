using Ardalis.GuardClauses;

namespace Splatrika.BronyMusicBrowser.Core.Entities;

#nullable disable

public class Song : EntityBase
{
    public string Title { get; private set; }
    public string Cover { get; private set; }
    public int Year { get; private set; }
    public string YouTubeId { get; private set; }


    public Song(int id, string title, int year, string youTubeId,
        string cover) : base(id)
    {
        UpdateDetails(title, year, youTubeId, cover);
    }


    private Song() { } //Required by EF Core


    public void UpdateDetails(string title, int year, string youTubeId,
        string cover)
    {
        Title = Guard.Against.NullOrEmpty(title);
        Year = Guard.Against.Negative(year);
        YouTubeId = Title = Guard.Against.NullOrEmpty(youTubeId);
        Cover = cover;
    }
}

