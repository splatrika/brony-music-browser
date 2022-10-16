using System.ComponentModel.DataAnnotations;

namespace Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

#nullable disable

public class EditCharacterViewModel
{
    [Required]
    [MaxLength(100)]
    public string Name { get; init; }

    [Required]
    [MaxLength(500)]
    public string Icon { get; init; }

    [Required]
    public int Order { get; init; }
}

