using VncApp.Components;
using VncApp.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseWebsockify("/websockify");
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()    .AddInteractiveServerRenderMode();

app.Run();
