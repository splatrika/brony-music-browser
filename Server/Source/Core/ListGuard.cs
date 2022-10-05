using System.Collections;

namespace Splatrika.BronyMusicBrowser.Core;

public static class ListGuard
{
    public static void CannotBeEmptyAfterRemove(ICollection list)
    {
        if (list.Count == 1)
        {
            throw new InvalidOperationException
                ("Unable to remove item. List cannot be empty");
        }
    }


    public static void CannotRemoveNonexistent<T>(ICollection<T> list, T item)
    {
        if (!list.Contains(item))
        {
            throw new InvalidOperationException
                ("Unable to remove item because this item isnt't in list");
        }
    }


    public static void CannotAddDublicate<T>(ICollection<T> list, T adding)
    {
        if (list.Contains(adding))
        {
            throw new InvalidOperationException
                ("Unable to add item. List cannot contains dublicates");
        }
    }
}

