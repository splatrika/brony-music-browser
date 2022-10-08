using Microsoft.Extensions.DependencyInjection;
using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data;

public class BrowserContextSeed
{
    private readonly ICrudRepository<Artist, ArtistCreateArgs>
        _artistRepository;
    private readonly ICrudRepository<Character, CharacterCreateArgs>
        _characterRepository;
    private readonly ICrudRepository<Genre, GenreCreateArgs>
        _genreRepository;
    private readonly ICrudRepository<Song, SongCreateArgs>
        _songRepository;
    private readonly ICrudRepository<Album, AlbumCreateArgs>
        _albumRepository;


    public BrowserContextSeed(
        ICrudRepository<Artist, ArtistCreateArgs> artistRepository,
        ICrudRepository<Character, CharacterCreateArgs> characterRepository,
        ICrudRepository<Genre, GenreCreateArgs> genreRepository,
        ICrudRepository<Song, SongCreateArgs> songRepository,
        ICrudRepository<Album, AlbumCreateArgs> albumRepository)
    {
        _artistRepository = artistRepository;
        _characterRepository = characterRepository;
        _genreRepository = genreRepository;
        _songRepository = songRepository;
        _albumRepository = albumRepository;
    }


    public static async Task TrySeed(IServiceProvider services)
    {
        await ActivatorUtilities
            .CreateInstance<BrowserContextSeed>(services)
            .TrySeed();
    }


    public async Task TrySeed()
    {
        var hasData = await _artistRepository.Any() ||
            await _characterRepository.Any() ||
            await _genreRepository.Any() ||
            await _songRepository.Any() ||
            await _albumRepository.Any();

        if (hasData)
        {
            return;
        }

        var pinkiePie = await _characterRepository.Create(new(
            name: "Pinkie Pie",
            icon: "/img/icons/pinkie-pie.png",
            order: -1));
        var fluttershy = await _characterRepository.Create(new(
            name: "Fluttershy",
            icon: "/img/icons/fluttershy.png",
            order: -1));
        var rainbowDash = await _characterRepository.Create(new(
            name: "Rainbow Dash",
            icon: "/img/icons/rainbow-dash.png",
            order: -1));
        var appleJack = await _characterRepository.Create(new(
            name: "Apple Jack",
            icon: "/img/icons/apple-jack.png",
            order: -1));
        var rarity = await _characterRepository.Create(new(
            name: "Rarity",
            icon: "/img/icons/rarity.png",
            order: -1));
        var twilight = await _characterRepository.Create(new(
            name: "Twilight Sparkle",
            icon: "/img/icons/twilight-sparkle.png",
            order: -1));
        var sunset = await _characterRepository.Create(new(
            name: "Sunset Shimmer",
            icon: "/img/icons/sunset-shimmer.png"));
        var starlight = await _characterRepository.Create(new(
            name: "Starligh Glimmer",
            icon: "/img/icons/starlight-glimmer.png"));
        var celestia = await _characterRepository.Create(new(
            name: "Princess Celestia",
            icon: "/img/icons/princess-celestia.png"));
        var luna = await _characterRepository.Create(new(
            name: "Princess Luna",
            icon: "/img/icons/princess-luna.png"));


        var rock = await _genreRepository.Create(new(
            caption: "Rock"));
        var edm = await _genreRepository.Create(new(
            caption: "EDM"));
        var jazz = await _genreRepository.Create(new(
            caption: "Jazz"));
        var pop = await _genreRepository.Create(new(
            caption: "Pop"));
        var accoustic = await _genreRepository.Create(new(
            caption: "Accoustic"));

        var silvaHound = await _artistRepository.Create(new(
            name: "Silva Hound"));
        var everfreeBrony = await _artistRepository.Create(new(
            name: "4EverFreeBrony"));

        var magicFlicker = await _songRepository.Create(new(
            title: "The Magic Flicker (feat. EileMonty)",
            cover: "https://f4.bcbits.com/img/a1803797057_5.jpg",
            year: 2018,
            youTubeId: "VkDz9mHiimA"));
        magicFlicker.AddCharacter(sunset.Id);
        magicFlicker.AddArtist(silvaHound.Id);
        magicFlicker.AddGenre(edm.Id);

        var magicFlickerExtended = await _songRepository.Create(new(
            title: "The Magic Flicker (Extended Mix) (feat. EileMonty)",
            cover: "https://f4.bcbits.com/img/a1803797057_5.jpg",
            year: 2018,
            youTubeId: "aI-11pfGv-s"));
        magicFlickerExtended.AddCharacter(sunset.Id);
        magicFlickerExtended.AddArtist(silvaHound.Id);
        magicFlickerExtended.AddGenre(edm.Id);

        var glimmerTile = await _songRepository.Create(new(
            title: "Glimmer Time",
            cover: "https://f4.bcbits.com/img/a4009729652_5.jpg",
            year: 2018,
            youTubeId: "OznzIRmA"));
        glimmerTile.AddCharacter(starlight.Id);
        glimmerTile.AddArtist(silvaHound.Id);
        glimmerTile.AddGenre(edm.Id);

        var whoKnows = await _songRepository.Create(new(
            title: "Who Knows (feat. Milkymomo, EileMonty, & MemJ0123)",
            cover: "https://images.genius.com/858a633ca0a1e66dd243906017ed0800.1000x1000x1.jpg",
            year: 2019,
            youTubeId: "HZ4HdhKJITI"));
        whoKnows.AddArtist(everfreeBrony.Id);
        whoKnows.AddGenre(accoustic.Id);
        whoKnows.AddCharacter(celestia.Id);
        whoKnows.AddCharacter(luna.Id);
        whoKnows.AddCharacter(twilight.Id);
        whoKnows.AddCharacter(starlight.Id);

        var magicFlickerAlbum = await _albumRepository.Create(new(
            title: "The Magic Flicker",
            cover: "https://f4.bcbits.com/img/a1803797057_5.jpg",
            firstSongId: magicFlicker.Id));
        magicFlickerAlbum.AddSong(magicFlickerExtended.Id);
        magicFlickerAlbum.AddArtist(silvaHound.Id);

        await _artistRepository.SaveChanges();
        await _characterRepository.SaveChanges();
        await _genreRepository.SaveChanges();
        await _songRepository.SaveChanges();
        await _albumRepository.SaveChanges();
    }
}

