using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Splatrika.BronyMusicBrowser.Infrastructure.Data;

namespace Splatrika.BronyMusicBrowser.Tests.Integration.Infrastructure.Builders;

public static class BrowserContextBuilder
{
    public static BrowserContext BuildTesting()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets(typeof(BrowserContextBuilder).Assembly)
            .Build();

        var connectionString = configuration
            .GetConnectionString("BrowserTestingConnection");

        var options = new DbContextOptionsBuilder<BrowserContext>()
            .UseSqlServer(connectionString)
            .Options;

        return new BrowserContext(options);
    }
}

