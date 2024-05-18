using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagment.Data.Contracts;
using UserManagment.Data.Repositories;

namespace UserManagment.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUsersData(this IServiceCollection services, 
        IConfiguration configuration,
        bool isProduction = true)
    {
        var conString = configuration["ConnectionStrings:Users"];

        services.AddDbContext<UserDataContext>(options =>
        {
            options.UseSqlServer(conString);
            //If we are not in production, log to console
            if(!isProduction)
            {
                options.LogTo(Console.WriteLine);
            }
        });
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
