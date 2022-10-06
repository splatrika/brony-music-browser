using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories;

public class GenreCrudRepository
    : EfCrudRepositoryBase<Genre, GenreCreateArgs, BrowserContext>
{
    public GenreCrudRepository(BrowserContext context) : base(context)
    {
    }


    protected override Genre Construct(GenreCreateArgs args)
    {
        return new(0, args.Caption, args.Order);
    }
}

