using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class Medication
{
    [Key]
    public int MedicationId { get; set; }
    public int UserId { get; set; }
    public required string RepeatingPattern { get; set; } //we have to figure this out 
    //mislam deka mozhe da go chuvame kako cron tuka a na mobile da go translirame 
    public required string MedicationName { get; set; } // 

    // Navigation properties
    public required AppUser User { get; set; }
    public ICollection<MedicationIntake>? MedicationIntakes { get; set; }
}

