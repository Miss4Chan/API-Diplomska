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
    public DateTime DateOfBirth { get; set; }

    // Navigation properties
    public ICollection<HeartRate>? HeartRates { get; set; }
    public ICollection<SuddenMovement>? SuddenMovements { get; set; }
    public ICollection<MedicationIntake>? MedicationIntakes { get; set; }
    public ICollection<Medication>? Medications { get; set; }
    public ICollection<HighHeartRate>? HighHeartRates { get; set; }

}
