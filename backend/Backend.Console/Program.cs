using Backend.Console.Services;
using Microsoft.OpenApi.Models;
using Backend.Persistence;
using Backend.Console.Hosts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "v1",
    Title = "ToDo API",
    Description = "An ASP.NET Core Web API for managing ToDo items",
    TermsOfService = new Uri("https://example.com/terms"),
    Contact = new OpenApiContact
    {
        Name = "Example Contact",
        Url = new Uri("http://localhost:2137/contact")
    },
    License = new OpenApiLicense
    {
        Name = "Example License",
        Url = new Uri("http://localhost:2137/license")
    }
}));

builder.Services.AddScoped<UserAuthenticationService>();
builder.Services.AddDbContext<BackendDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddHostedService<BaseHost>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

//app.UseAuthorization();

app.UseRouting();
app.MapControllers();


app.Run();
