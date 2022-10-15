using Microsoft.AspNetCore.Identity;
using Splatrika.BronyMusicBrowser.Infrastructure.Data.Identity;
using Splatrika.BronyMusicBrowser.WebAdmin;
using Microsoft.AspNetCore.Identity.UI.Services;
using Splatrika.BronyMusicBrowser.WebAdmin.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddIdentityContext(builder.Configuration);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddScoped<IEmailSender, FakeEmailSender>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var adminSeed = ActivatorUtilities
        .CreateInstance<AdminSeed>(scope.ServiceProvider);
    await adminSeed.TrySeed();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapRazorPages();

app.Run();
