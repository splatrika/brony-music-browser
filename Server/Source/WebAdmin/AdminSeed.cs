using System;
using Microsoft.AspNetCore.Identity;
using Splatrika.BronyMusicBrowser.Core.Constrants;

namespace Splatrika.BronyMusicBrowser.WebAdmin;

public class AdminSeed
{
    private readonly UserManager<IdentityUser> _manager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AdminSeed> _logger;


    public AdminSeed(UserManager<IdentityUser> manager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration, ILogger<AdminSeed> logger)
    {
        _manager = manager;
        _roleManager = roleManager;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task TrySeed()
    {
        if (!await _roleManager.RoleExistsAsync(Roles.Admin))
        {
            await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }
        if (_manager.Users.Any())
        {
            return;
        }
        var password = _configuration.GetValue<string>("AdminSeed:Password");
        if (string.IsNullOrEmpty(password))
        {
            _logger.LogWarning(
                "To seed admin, set AdminSeed:Password in configuration");
            return;
        }
        var admin = new IdentityUser("admin");
        await _manager.CreateAsync(admin);
        await _manager.AddToRoleAsync(admin, Roles.Admin);
        if ((await _manager.AddPasswordAsync(admin, password)).Succeeded)
        {
            _logger.LogInformation("Admin account has been seeded");
        }
        else
        {
            await _manager.DeleteAsync(admin);
            _logger.LogWarning("Admin account has not been seeded. " +
                "Password validation has failed");
        }
    }
}

