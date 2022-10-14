using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Identity;

public class IdentityContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public IdentityContext(DbContextOptions options) : base(options)
    {
    }
}

