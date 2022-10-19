using System;
namespace Splatrika.BronyMusicBrowser.WebAdmin.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class SongEditTabControllerAttribute : Attribute
{
    public string TabName { get; }
    public int Order { get; }
    public string ActionName { get; }


    public SongEditTabControllerAttribute(string tabName, int order = 0,
        string actionName = "Index")
    {
        TabName = tabName;
        Order = order;
        ActionName = actionName;
    }
}

