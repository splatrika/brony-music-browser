using System.ComponentModel.DataAnnotations;

namespace Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

#nullable disable

public class EditGenreViewModel
{
    [Required]
    [MaxLength(100)]
    public string Caption { get; init; }

    [Required]
    public int Order { get; init; }
}

