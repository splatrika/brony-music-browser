using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories;

public class ArtistCrudRepository
    : EfCrudRepositoryBase<Artist, ArtistCreateArgs, BrowserContext>
{
    public ArtistCrudRepository(BrowserContext context) : base(context)
    {
    }


    protected override Artist Construct(ArtistCreateArgs args)
    {
        return new(0, args.Name);
    }
}

