using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class Medication
{
    [Key]
    public int MedicationId { get; set; }
    public int UserId { get; set; }
    public List<int> RepeatingPattern { get; set; } = new List<int>(new int[7]); // Default 0 for all 7 days
    public required string MedicationName { get; set; } // 
    public bool IsDeleted { get; set; }

    //cloudve been a timespan??
    public required TimeOnly TimeOfDay { get; set; } 
    // Navigation properties
    public required AppUser User { get; set; }
    public ICollection<MedicationIntake>? MedicationIntakes { get; set; }
}


   

