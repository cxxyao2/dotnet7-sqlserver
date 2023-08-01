using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet7_sqlserver.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = new byte[0];
    public byte[] PasswordSalt { get; set; } = new byte[0];
    public List<Character>? Characters { get; set; } = new List<Character>();
  }
}