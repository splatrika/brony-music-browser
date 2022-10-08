using Splatrika.BronyMusicBrowser.Infrastructure;
using Splatrika.BronyMusicBrowser.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddBrowserContext(builder.Configuration);
builder.Services.AddCrudRepositories();
builder.Services.AddFilterProcessors();
builder.Services.AddReadOnlyRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        await BrowserContextSeed.TrySeed(scope.ServiceProvider);
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
