namespace Splatrika.BronyMusicBrowser.WebAdmin.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class LibraryResourceControllerAttribute : Attribute
{
    public string ResourceName { get; }
    public int Order { get; }


    public LibraryResourceControllerAttribute(string resourceName,
        int order = 0)
    {
        ResourceName = resourceName;
        Order = order;
    }
}

