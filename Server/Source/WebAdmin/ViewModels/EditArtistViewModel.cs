using System.ComponentModel.DataAnnotations;

namespace Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

#nullable disable

public class EditArtistViewModel
{
    [Required]
    public string Name { get; set; }
}

