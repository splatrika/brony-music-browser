using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories;

public class CharacterCrudRepository
    : EfCrudRepositoryBase<Character, CharacterCreateArgs, BrowserContext>
{
    public CharacterCrudRepository(BrowserContext context) : base(context)
    {
    }


    protected override Character Construct(CharacterCreateArgs args)
    {
        return new(0, args.Name, args.Icon, args.Order);
    }
}

