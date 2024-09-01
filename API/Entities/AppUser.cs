using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class AppUser
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Username { get; set; }
    public required byte[] PasswordHash {get;set;}
    public required byte[] PasswordSalt {get;set;}
}
