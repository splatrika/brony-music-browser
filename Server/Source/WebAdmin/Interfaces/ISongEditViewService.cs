using Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Interfaces;

public interface ISongEditViewService
{
    IEnumerable<SongEditTabViewModel> GetTabs();
}

