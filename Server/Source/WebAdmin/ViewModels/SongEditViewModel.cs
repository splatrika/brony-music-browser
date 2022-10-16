using System.ComponentModel.DataAnnotations;
using Splatrika.BronyMusicBrowser.Core.CreateArgs;

namespace Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

#nullable disable

public class SongEditViewModel
{
    [Required]
    [MaxLength(100)]
    public string Title { get; init; }

    [Required]
    [MaxLength(500)]
    public string Cover { get; init; }

    [Required]
    public int Year { get; init; }

    [Required]
    [MaxLength(11)]
    public string YouTubeId { get; init; }


    public SongCreateArgs ToCreateArgs()
    {
        return new(Title, Cover, Year, YouTubeId);
    }
}

