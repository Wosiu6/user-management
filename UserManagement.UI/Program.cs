using Microsoft.FluentUI.AspNetCore.Components;
using UserManagement.UI.Components;
using UserManagement.UI.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

AddAdminUIServices(builder);

AddBlazorComponents(builder);

var app = builder.Build();

ConfigureBlazorComonents(app);

app.Run();

static void ConfigureBlazorComonents(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();
}

static void AddAdminUIServices(WebApplicationBuilder builder)
{
    builder.Services.AddUIServices(builder.Configuration);
}

static void AddBlazorComponents(WebApplicationBuilder builder)
{
    builder.Services.AddRazorComponents()
                    .AddInteractiveServerComponents();

    builder.Services.AddFluentUIComponents();
}
