using UserManagement.UserApi.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Register App Services
AddApplicationServices(builder);

//Register MVC Services
AddMvcServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureMvcServices(app);

app.CreateDbIfNotExists();

app.Run();


static void ConfigureMvcServices(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

static void AddMvcServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

static void AddApplicationServices(WebApplicationBuilder builder)
{
    builder.Services.AddUserServices(builder.Configuration, builder.Environment.IsProduction());
}