using AutoBogus;
using AutoBogus.Conventions;
using UserManagement.Data.Models;

namespace UserManagement.Data.Initializers;

public static class DbInitializer
{
    public static void Initialize(UserDataContext context)
    {
        if(context.Users.Any())
        {
            return;
        }

        AutoFaker.Configure(builder =>
        {
            builder.WithConventions();
        });

        var faker = AutoFaker.Create();

        var users = faker.Generate<User>(10);

        context.Users.AddRange(users);
        context.SaveChanges();
    }
}
