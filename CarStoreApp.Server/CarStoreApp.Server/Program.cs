using CarStoreApp.Server.Controllers.Filters;
using CarStoreApp.Server.Extentions;
using CarStoreApp.Server.Middlewares;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//Controllers--------------------------------------------------------
builder.Services.AddControllers(op =>
{
    op.Filters.Add<ValidationFilter>();

}).AddJsonOptions(op =>
{
   // Stop converting numbers
   // op.JsonSerializerOptions.NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.Strict;
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


//Services--------------------------------------------------------
builder.Services.AddAppDbService(builder.Configuration);
builder.Services.AddAppServices();
builder.Services.AddAppAuth(builder.Configuration);
// builder.Services.AddScoped<ValidationFilter>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

//App--------------------------------------------------------
var app = builder.Build();
app.UseMiddleware<ErrorMiddleware>();


app.UseCors("AllowAll");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();




app.MapControllers();

//Seed the database
/*using (var scope = app.Services.CreateScope())
{
    var sp = scope.ServiceProvider;
    var context = sp.GetRequiredService<AppDBContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(context);
}*/


app.Run();
