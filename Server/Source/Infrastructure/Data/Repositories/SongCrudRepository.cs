using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories;

public class SongCrudRepository
    : EfCrudRepositoryBase<Song, SongCreateArgs, BrowserContext>
{
    public SongCrudRepository(BrowserContext context) : base(context)
    {
    }


    protected override Song Construct(SongCreateArgs args)
    {
        return new(0, args.Title, args.Cover, args.Year, args.YouTubeId);
    }
}

