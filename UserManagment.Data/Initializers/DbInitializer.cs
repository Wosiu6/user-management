using AutoBogus;
using AutoBogus.Conventions;
using UserManagment.Data.Models;

namespace UserManagment.Data.Initializers;

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
