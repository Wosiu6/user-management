using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserManagement.UserApi.Services.Contracts;
using UserManagement.Data.Extensions;

namespace UserManagement.UserApi.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services,
            IConfiguration configuration,
            bool isProduction = true)
        {
            services.AddUsersData(configuration, isProduction);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
