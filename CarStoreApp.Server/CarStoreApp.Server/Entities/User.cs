using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarStoreApp.Server.Entities;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Byte[] Password { get; set; }
    public required Byte[] PasswordSalt { get; set; }
}
