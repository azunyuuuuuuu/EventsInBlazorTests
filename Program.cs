using EventsInBlazorTests.Components;
using EventsInBlazorTests.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<NotifyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/api/notify", ([FromServices] ILogger<Program> logger, [FromServices] NotifyService notifyService) =>
{
    logger.LogInformation("Anfrage zum Auslösen eines Ereignisses erhalten");
    try
    {
        notifyService.SendNotification();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Fehler beim Auslösen des Ereignisses");
        return Results.Problem(ex.Message);
    }
    logger.LogInformation("Ereignis erfolgreich ausgelöst");
    return Results.Ok();
});

app.Run();
