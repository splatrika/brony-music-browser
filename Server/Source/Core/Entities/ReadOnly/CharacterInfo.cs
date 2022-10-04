﻿namespace Splatrika.BronyMusicBrowser.Core.Entities.ReadOnly;

public class CharacterInfo : EntityBase
{
    public string Name { get; private set; }
    public string Icon { get; private set; }
    public int Order { get; private set; }


    public CharacterInfo(Character original) : base(original.Id)
    {
        Name = original.Name;
        Icon = original.Icon;
        Order = original.Order;
    }
}

