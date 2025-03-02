
using CarStoreApp.Server.Entities;

namespace CarStoreApp.Server.Interfaces;

public interface IJWTService
{
    string createToken(User user);
}
