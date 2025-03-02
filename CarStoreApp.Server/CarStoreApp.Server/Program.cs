using CarStoreApp.Server.Data;
using CarStoreApp.Server.Interfaces;
using CarStoreApp.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDBContext>(op =>
{
    op.UseSqlite(builder.Configuration.GetConnectionString("main"));

}, ServiceLifetime.Singleton);

//Services--------------------------------------------------------
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJWTService, JWTService>();

var app = builder.Build();

app.MapControllers();
app.UseRouting();
app.Run();
