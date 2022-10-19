using System.Reflection;
using Splatrika.BronyMusicBrowser.WebAdmin.Attributes;
using Splatrika.BronyMusicBrowser.WebAdmin.Interfaces;
using Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Services;

public class SongEditViewService : ISongEditViewService
{
    public IEnumerable<SongEditTabViewModel> GetTabs()
    {
        var assembly = typeof(SongEditViewService).Assembly;
        var tabControllers = assembly.GetTypes()
            .Where(x =>
                x.IsClass &&
                !x.IsAbstract &&
                IsTabController(x));
        return tabControllers.SelectMany(type =>
        {
            return type
                .GetCustomAttributes(typeof(SongEditTabControllerAttribute))
                .Select(a =>
                {
                    var attribute = (SongEditTabControllerAttribute)a;
                    return new SongEditTabViewModel
                    {
                        TabName = attribute.TabName,
                        ControllerName = GetControllerName(type),
                        ActionName = attribute.ActionName,
                        Order = attribute.Order
                    };
                });
        })
        .OrderBy(x => x.Order);
    }


    public bool IsTabController(Type type)
    {
        return type.GetCustomAttributes(typeof(SongEditTabControllerAttribute))
            .Any();
    }


    public string GetControllerName(Type type)
    {
        return type.Name.Replace("Controller", "");
    }
}

