using CarStoreApp.Server.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDBContext>(op =>
{
    op.UseSqlite(builder.Configuration.GetConnectionString("main"));

}, ServiceLifetime.Singleton);
var app = builder.Build();

app.MapControllers();
app.UseRouting();
app.Run();
