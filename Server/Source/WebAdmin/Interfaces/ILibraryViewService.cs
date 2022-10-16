using Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Interfaces;

public interface ILibraryViewService
{
	IEnumerable<ResourceInfoViewModel> GetResources();
}

