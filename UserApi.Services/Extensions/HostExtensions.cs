using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserManagement.Data.Initializers;

namespace UserManagement.UserApi.Services.Extensions;

public static class HostExtensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<UserDataContext>();
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }
    }
}
