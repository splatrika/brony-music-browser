using System.Reflection;
using Splatrika.BronyMusicBrowser.WebAdmin.Attributes;
using Splatrika.BronyMusicBrowser.WebAdmin.Interfaces;
using Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Services;

public class LibraryViewService : ILibraryViewService
{
    public IEnumerable<ResourceInfoViewModel> GetResources()
    {
        var assembly = typeof(LibraryViewService).Assembly;
        var controllerClasses = assembly.GetTypes()
            .Where(x =>
                x.IsClass &&
                !x.IsAbstract &&
                IsLibraryResourceController(x));
        var result = new List<ResourceInfoViewModel>();
        foreach (var controllerClass in controllerClasses)
        {
            var attributes = controllerClass.GetCustomAttributes(
                typeof(LibraryResourceControllerAttribute));
            var controllerName = controllerClass.Name.Replace("Controller", "");
            foreach (var a in attributes)
            {
                var attribute = (LibraryResourceControllerAttribute)a;
                result.Add(new ResourceInfoViewModel
                {
                    ControllerName = controllerName,
                    ResourceName = attribute.ResourceName,
                    Order = attribute.Order
                });
            }
        }
        return result.OrderBy(x => x.Order);
    }


    private bool IsLibraryResourceController(Type x)
    {
        return x.GetCustomAttributes(typeof(LibraryResourceControllerAttribute))
            .Any();
    }
}

