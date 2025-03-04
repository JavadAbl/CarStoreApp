using CarStoreApp.Server.Extentions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//Services--------------------------------------------------------
builder.Services.AddAppDbService(builder.Configuration);
builder.Services.AddAppServices();
builder.Services.AddAppAuth(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();




app.MapControllers();
app.Run();
