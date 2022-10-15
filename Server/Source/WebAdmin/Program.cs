using Microsoft.AspNetCore.Identity;
using Splatrika.BronyMusicBrowser.Infrastructure.Data.Identity;
using Splatrika.BronyMusicBrowser.WebAdmin;
using Microsoft.AspNetCore.Identity.UI.Services;
using Splatrika.BronyMusicBrowser.WebAdmin.Services;
using Splatrika.BronyMusicBrowser.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddIdentityContext(builder.Configuration);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddAuthorisationHandlers();

builder.Services.AddScoped<IEmailSender, FakeEmailSender>();

builder.Services.AddBrowserContext(builder.Configuration);

builder.Services.AddCrudRepositories();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

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


app.MapControllerRoute(name: "default",
    pattern: "{area}/{controller}/{action=Index}");

app.MapRazorPages();

app.MapGet("/", context =>
{
    context.Response.Redirect("/Library/Songs");
    return Task.CompletedTask;
});

app.Run();
