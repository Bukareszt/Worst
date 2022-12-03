using Backend.Console.Services;
using Backend.Persistence;
using Backend.Console.Hosts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserAuthenticationService>();
builder.Services.AddDbContext<BackendDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddHostedService<BaseHost>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();

app.UseRouting();
app.MapControllers();


app.Run();
