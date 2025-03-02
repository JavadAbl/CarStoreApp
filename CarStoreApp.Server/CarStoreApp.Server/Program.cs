using CarStoreApp.Server.Extentions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//Services--------------------------------------------------------
builder.Services.AddAppDbService(builder.Configuration);
builder.Services.AddAppServices();
builder.Services.AddAppAuth(builder.Configuration);

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
