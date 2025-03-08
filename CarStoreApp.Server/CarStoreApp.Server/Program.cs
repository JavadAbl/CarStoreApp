using CarStoreApp.Server.Controllers.Filters;
using CarStoreApp.Server.Extentions;
using CarStoreApp.Server.Middlewares;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//Controllers--------------------------------------------------------
builder.Services.AddControllers(op =>
{
    op.Filters.Add<ValidationFilter>();
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
app.Run();
