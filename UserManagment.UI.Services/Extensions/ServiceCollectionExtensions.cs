using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagment.UI.Services.Contracts;

namespace UserManagment.UI.Services.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUIServices(this IServiceCollection services, IConfiguration configuration)
    {
        var apiUrl = configuration["Api:Url"]!;
        services.AddHttpClient("UserApi",client =>
        {
            client.BaseAddress = new Uri(apiUrl, UriKind.Absolute);
        });
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
