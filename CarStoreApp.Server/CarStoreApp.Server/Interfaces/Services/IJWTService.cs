namespace CarStoreApp.Server.Interfaces.Services;

public interface IJWTService
{
    string createToken(string username);
}
