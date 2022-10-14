using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Splatrika.BronyMusicBrowser.Infrastructure.Data.Identity;
using Splatrika.BronyMusicBrowser.WebAdmin;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentityContext(builder.Configuration);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
